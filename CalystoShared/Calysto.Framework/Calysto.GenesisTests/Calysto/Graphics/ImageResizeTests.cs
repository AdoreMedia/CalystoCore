using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Calysto.Genesis.Tests.EnvDTE;
using Calysto.UnitTesting;

namespace Calysto.Graphics.Tests
{
	[TestClass()]
	public class ImageResizeTests
	{
		static string _input1 = "image1.jpg";
		static string _input2 = "image2.jpg";

		private void ResizeImage(string methodName, string imageName, ImageResize.ResizeModeEnum mode, int width, int height)
		{
			ImageResize resizer = new ImageResize()
			{
				BackColor = System.Drawing.Brushes.Orange,
				OutputFormat = ImageResize.OutputFormatEnum.PNG,
				Width = width,
				Height = height,
				Mode = mode	
			};

			string fileName = methodName + "-" + mode + "-" + imageName;

			TestFilesProvider2 provider2 = new TestFilesProvider2("Calysto\\Graphics\\Input\\" + fileName);

			byte[] inputData = provider2.ReadInputBytes(imageName);
			byte[] actualData = resizer.Resize(inputData);
			provider2.Assert(Assert.AreEqual, actualData);
		}

		[TestMethod()]
		public void Test0011()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Fit, 400, 300);
		}

		[TestMethod()]
		public void Test0012()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Fit, 400, 300);
		}

		[TestMethod()]
		public void Test0013()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Fit, 800, 700);
		}

		[TestMethod()]
		public void Test0014()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Fit, 800, 700);
		}

		[TestMethod()]
		public void Test0021()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Crop, 400, 300);
		}

		[TestMethod()]
		public void Test0022()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Crop, 400, 300);
		}

		[TestMethod()]
		public void Test0023()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Crop, 800, 700);
		}

		[TestMethod()]
		public void Test0024()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Crop, 800, 700);
		}

		[TestMethod()]
		public void Test0031()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Exact, 400, 300);
		}

		[TestMethod()]
		public void Test0032()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Exact, 400, 300);
		}

		[TestMethod()]
		public void Test0033()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Exact, 800, 700);
		}

		[TestMethod()]
		public void Test0034()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Exact, 800, 700);
		}

		[TestMethod()]
		public void Test0041()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Stretch, 400, 300);
		}

		[TestMethod()]
		public void Test0042()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Stretch, 400, 300);
		}

		[TestMethod()]
		public void Test0043()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Stretch, 800, 700);
		}

		[TestMethod()]
		public void Test0044()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Stretch, 800, 700);
		}


		[TestMethod()]
		public void Test0051()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Reduce, 500, 400);
		}

		[TestMethod()]
		public void Test0052()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Reduce, 400, 300);
		}

		[TestMethod()]
		public void Test0053()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input1, ImageResize.ResizeModeEnum.Reduce, 800, 700);
		}

		[TestMethod()]
		public void Test0054()
		{
			ResizeImage(MethodInfo.GetCurrentMethod().Name, _input2, ImageResize.ResizeModeEnum.Reduce, 800, 700);
		}
	}
}
