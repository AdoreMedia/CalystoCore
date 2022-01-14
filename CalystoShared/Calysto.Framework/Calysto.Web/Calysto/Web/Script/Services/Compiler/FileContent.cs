using System;
using System.Security.Cryptography;
using System.Text;

namespace Calysto.Web.Script.Services.Compiler
{
	class FileContent
	{
		public FileContent(string content, bool isCss = false, string appRelativeVirtualPath = null, bool isInline = false)
		{
			this.Content = content;
			this.IsCss = isCss;
			this.AppRelativeVirtualPath = appRelativeVirtualPath;
			this.IsInline = isInline;
		}

		public string Content { get; private set; }
		public bool IsCss { get; private set; }
		public string AppRelativeVirtualPath { get; private set; }
		public bool IsInline { get; private set; }

		private string _uniqueContentKey;

		public string GetUniqueContentKey()
		{
			return _uniqueContentKey ?? (_uniqueContentKey = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(this.Content))));
		}

	}
}