using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Calysto.Graphics
{
	public class ImageResize
	{
		public enum CropPositionEnum
		{
			/// <summary>
			/// Default
			/// </summary>
			Center = 0,

			/// <summary>
			/// Start from left side and take width
			/// </summary>
			Left = 1,

			/// <summary>
			/// Start from right side and take width
			/// </summary>
			Right = 2
		}

		public enum ResizeModeEnum
		{
			/// <summary>
			/// Default. Reduce or enlarge image to fit into the rectangle without overflowing. Keep AR.
			/// </summary>
			Fit = 0,

			/// <summary>
			/// Reduce or enlarge image to fit and overflow the rectangle bounds if required. Overflowing part of the image is croped. Keep AR.
			/// </summary>
			Crop = 1,

			/// <summary>
			/// Reduce or enlarge image to fit into rectangle without overflowing rectangle dimensions. Add background to create exact width and height. Keep AR
			/// </summary>
			Exact = 2,

			/// <summary>
			/// Stretch to exact width and height, destroy AR
			/// </summary>
			Stretch = 3,

			/// <summary>
			/// Reduce image if larger to fit into the rectangle without overflowing. Smaller images are left as-is without processing. Keep AR.
			/// </summary>
			Reduce = 4
		}

		/// <summary>
		/// Max output width.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Max output height.
		/// </summary>
		public int Height { get; set; }

		public ResizeModeEnum Mode { get; set; }

		/// Default is Center. Used with Crop == true or ExactDimensions == true.
		/// </summary>
		public CropPositionEnum CropPosition { get; set; }

		/// <summary>
		/// Force conversion.
		/// </summary>
		public bool AlwaysConvert { get; set; }

		Brush _backColor = Brushes.White;
		public Brush BackColor { get; set; } = Brushes.White;

		/// <summary>
		/// Output quality 0 - 100. Default 100.
		/// </summary>
		public int Quality { get; set; } = 100;

		public System.Drawing.Drawing2D.InterpolationMode Interpolation { get; set; } = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

		/// <summary>
		/// Make thumb larger or smaller than canvas. Pozitive number will make thumb larger, negative will make it smaller.
		/// </summary>
		public int Overscan { get; set; }

		public enum OutputFormatEnum
		{
			/// <summary>
			/// Default
			/// </summary>
			Original = 0,
			GIF,
			BMP,
			JPEG,
			PNG,
			TIFF
		}

		/// <summary>
		/// Default output is the same as input format.
		/// </summary>
		public OutputFormatEnum OutputFormat { get; set; }

		public ImageResize()
		{
		}

		/// <summary>
		/// Resize image using current settings and return resized byte[].
		/// </summary>
		public byte[] Resize(byte[] imgData)
		{
			if (imgData == null)
				throw new ArgumentException(nameof(imgData));

			System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData);
			System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
			System.Drawing.Imaging.ImageFormat rawformat = img.RawFormat;

			decimal thumbWidth = img.Width;
			decimal thumbHeight = img.Height;
			decimal ar = thumbWidth / thumbHeight;
			decimal canvasWidth = this.Width;
			decimal canvasHeight = this.Height;

			if (this.Mode == ResizeModeEnum.Stretch)
			{
				thumbWidth = this.Width;
				thumbHeight = this.Height;
			}
			else if (this.Mode == ResizeModeEnum.Reduce)
			{
				if (thumbHeight > this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.Round(thumbHeight * ar);
				}

				if (thumbWidth > this.Width)
				{
					thumbWidth = this.Width;
					thumbHeight = Math.Round(thumbWidth / ar);
				}

				canvasWidth = thumbWidth;
				canvasHeight = thumbHeight;
			}
			else if (this.Mode == ResizeModeEnum.Exact || this.Mode == ResizeModeEnum.Fit)
			{
				thumbWidth = this.Width;
				thumbHeight = Math.Round(thumbWidth / ar);

				if (thumbHeight > this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.Round(thumbHeight * ar);
				}

				if (this.Mode == ResizeModeEnum.Fit)
				{
					canvasWidth = thumbWidth;
					canvasHeight = thumbHeight;
				}
			}
			else if (this.Mode == ResizeModeEnum.Crop)
			{
				thumbWidth = this.Width;
				thumbHeight = Math.Round(thumbWidth / ar);

				if (thumbHeight < this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.Round(thumbHeight * ar);
				}
			}

			thumbHeight += this.Overscan;
			thumbWidth += this.Overscan;

			if (this.Overscan == 0 && (int)thumbWidth == img.Width && (int)thumbHeight == img.Height && !this.AlwaysConvert)
			{
				// conversion is not required
				// warning: animated gif loses animation if processed, so don't process unless required
				// if the picture has the same size, don't convert it at all, return original stream
				ms.Close();
				ms.Dispose();
				img.Dispose();
				return imgData;
			}

			System.Drawing.Rectangle rect = new Rectangle();
			switch (this.CropPosition)
			{
				case CropPositionEnum.Center:
					rect = new System.Drawing.Rectangle((int)Math.Round((canvasWidth - thumbWidth) / 2), (int)Math.Round((canvasHeight - thumbHeight) / 2), (int)(thumbWidth), (int)(thumbHeight));
					break;
				case CropPositionEnum.Left:
					rect = new System.Drawing.Rectangle(0, (int)Math.Round((canvasHeight - thumbHeight) / 2), (int)(thumbWidth), (int)(thumbHeight));
					break;
				case CropPositionEnum.Right:
					rect = new System.Drawing.Rectangle((int)((canvasWidth - thumbWidth)), (int)Math.Round((canvasHeight - thumbHeight) / 2), (int)(thumbWidth), (int)(thumbHeight));
					break;
			}

			System.Drawing.Bitmap thumb = new System.Drawing.Bitmap((int)canvasWidth, (int)canvasHeight);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(thumb);
			g.InterpolationMode = this.Interpolation;

			if (this.Mode == ResizeModeEnum.Exact)
			{
				g.FillRectangle(this.BackColor, 0, 0, (int)canvasWidth, (int)canvasHeight);
			}

			g.DrawImage(img, rect.X, rect.Y, rect.Width, rect.Height);

			byte[] data = GetImageData(thumb, GetImageCodecInfo(rawformat));

			thumb.Dispose();
			g.Dispose();
			ms.Close();
			ms.Dispose();
			img.Dispose();

			return data;
		}

		private ImageCodecInfo GetImageCodecInfo(ImageFormat format)
		{
			switch (this.OutputFormat)
			{
				// warning: diferent windows versions has different codec GUID
				case OutputFormatEnum.Original:
					return ImageCodecInfo.GetImageEncoders().Where(o => o.FormatID == format.Guid).First();
				default:
					return ImageCodecInfo.GetImageEncoders().Where(o => o.FormatDescription == this.OutputFormat.ToString()).First();
			}
		}

		private byte[] GetImageData(System.Drawing.Image img, ImageCodecInfo ici)
		{
			// .net default quality is 70%, but pictures are blured
			if (img == null)
			{
				return null;
			}

			// img.Save(...) sometimes throw GDI+ exception, try different approach:
			System.Drawing.Bitmap newimg = new System.Drawing.Bitmap(img.Width, img.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newimg);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(img, 0, 0, img.Width, img.Height);

			EncoderParameters ep = new EncoderParameters();
			ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)this.Quality);
			MemoryStream ms = new MemoryStream();
			img.Save(ms, ici, ep);

			return ms.ToArray();
		}

	}
}
