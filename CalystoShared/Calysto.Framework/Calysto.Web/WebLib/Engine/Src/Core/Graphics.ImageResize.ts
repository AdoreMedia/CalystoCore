namespace Calysto.Graphics
{
	export enum ResizeModeEnum
	{
		/** Default. Resize image to fit into rectangle without overflowing. Keep AR. */
		Fit = 0,

		/** Resize image to fit and overflow the rectangle bounds if required. Overflowing part of the image is croped. Keep AR.*/
		Crop = 1,

		/** Resize image to fit into rectangle without overflowing rectangle dimensions. Add background to create exact width and height. Keep AR */
		Exact = 2,

		/** Stretch to exact width and height, destroy AR */
		Stretch = 3,

		/** Reduce image if larger to fit into the rectangle without overflowing. Smaller images are left as-is without processing. Keep AR. */
		Reduce = 4
	}

	export class ImageResize
	{
		public constructor()
		{
		}

		/** max width */
		public Width: number = 500;

		/** max height */
		public Height: number = 500;

		public Mode: keyof typeof ResizeModeEnum = "Fit";

		/* Make thumb larger or smaller than canvas. Pozitive number will make thumb larger, negative will make it smaller.*/
		public Overscan = 0;

		/** */
		public BackColor: string;

		/** */
		public OutputMime: string = "image/jpeg";

		public Quality?: number;

		/**
		 * Resize image and return dataURL
		 */
		public Resize(source: HTMLImageElement | HTMLCanvasElement | HTMLVideoElement)
		{
			var thumbWidth = source.width;
			var thumbHeight = source.height;
			var ar = source.width / source.height;
			var canvasWidth = this.Width;
			var canvasHeight = this.Height;

			if (this.Mode == "Stretch")
			{
				thumbWidth = this.Width;
				thumbHeight = this.Height;
			}
			else if (this.Mode == "Reduce")
			{
				if (thumbHeight > this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.round(thumbHeight * ar);
				}

				if (thumbWidth > this.Width)
				{
					thumbWidth = this.Width;
					thumbHeight = Math.round(thumbWidth / ar);
				}

				canvasWidth = thumbWidth;
				canvasHeight = thumbHeight;
			}
			else if (this.Mode == "Exact" || this.Mode == "Fit")
			{
				thumbWidth = this.Width;
				thumbHeight = Math.round(thumbWidth / ar);

				if (thumbHeight > this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.round(thumbHeight * ar);
				}

				if (this.Mode == "Fit")
				{
					canvasWidth = thumbWidth;
					canvasHeight = thumbHeight;
				}
			}
			else if (this.Mode == "Crop")
			{
				thumbWidth = this.Width;
				thumbHeight = Math.round(thumbWidth / ar);

				if (thumbHeight < this.Height)
				{
					thumbHeight = this.Height;
					thumbWidth = Math.round(thumbHeight * ar);
				}
			}

			thumbHeight += this.Overscan;
			thumbWidth += this.Overscan;

			var c22 = document.createElement("canvas");
			var cx22 = c22.getContext("2d");
			if (!cx22)
			{
				throw new Error("Can not create 2d context");
			}

			c22.width = canvasWidth;
			c22.height = canvasHeight;

			if (this.BackColor && this.BackColor != "transparent")
			{
				cx22.fillStyle = this.BackColor;
				cx22.fillRect(0, 0, c22.width, c22.height);
			}

			var left1 = Math.round((canvasWidth - thumbWidth) / 2);
			var top1 = Math.round((canvasHeight - thumbHeight) / 2);

			cx22.drawImage(source, left1, top1, thumbWidth, thumbHeight);

			return c22.toDataURL(this.OutputMime || "image/png", this.Quality);
		}
	}
}


