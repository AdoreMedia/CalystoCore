using System;

namespace Calysto.Graphics
{
	public class CalystoCssHelper
	{
		public static string Base64EncodeImage(byte[] imgBytes, string mime)
		{
			// data:[<MIME-type>][;charset=<encoding>][;base64],<data>
			// background-image: url(data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABj6UAf/Z);
			// <img alt="" src="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/2wBD" />
			return "data:" + mime + ";base64," + Convert.ToBase64String(imgBytes);
		}
	}
}
