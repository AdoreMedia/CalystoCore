using Calysto.Converter;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Calysto.Web
{
	public class CalystoPhysicalPaths
	{
		/// <summary>
		/// Tilde absolute path (~/)
		/// </summary>
		public string ContentRoot { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contentRootAbsolutePath">Tilde absolute path (~/)</param>
		public CalystoPhysicalPaths(string contentRootAbsolutePath)
		{
			this.ContentRoot = contentRootAbsolutePath;
		}

		public class SearchLocation
		{
			public Assembly Assembly;
			public string Path;
			public bool IsAbsolute;

			public string GetHashKey() => this.Assembly?.ManifestModule.ModuleVersionId.ToString() ?? (this.IsAbsolute + "$" + this.Path);
		}

		Dictionary<string, SearchLocation> _searchLocations = new Dictionary<string, SearchLocation>();

		public IEnumerable<SearchLocation> Locations => _searchLocations.Select(o => o.Value);

		/// <summary>
		/// Register path where static files will be searched for.<br/>
		/// Accepts: <br/>
		/// - relative path starting with ~/ <br/>
		/// - absolute path without ~/ </br>
		/// </summary>
		/// <param name="path"></param>
		public void RegisterSearchDirectory(string path, bool isAbsolute = false)
		{
			if (!isAbsolute)
			{
				// rooted on win:
				// C:\dir1\dir2
				// \\server.name\dir1
				// /dir1/dir2
				isAbsolute = path.Contains(":") && Path.IsPathRooted(path);
			}

			if (!isAbsolute && !path.StartsWith("~/"))
				throw new ArgumentException($"Relative path \"{path}\" should start with ~/ and end with /");
			else if (isAbsolute && path.Contains("~/"))
				throw new ArgumentException($"Absolute path \"{path}\" should not contain ~/");

			SearchLocation loc1 = new SearchLocation() { Path = path, IsAbsolute = isAbsolute };
			string key1 = loc1.GetHashKey();

			if (!_searchLocations.ContainsKey(key1))
			{
				_searchLocations.Add(key1, loc1);
			}
		}

		private string CalculateSignature()
		{
			// assemblies signature has to be calculated again
			string str1 = _searchLocations.Select(o => o.Value.Assembly?.ManifestModule.ModuleVersionId.ToString())
				.Where(o => o != null)
				.ToStringJoined("#");

			return CalystoBase64Encoder.Base64RndEncoder.EncodeToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str1)));
		}

		public string AssembliesSignature { get; private set; }

		/// <summary>
		/// Assembly with embedded resources.
		/// </summary>
		/// <param name="assembly"></param>
		public void RegisterSearchAssembly(Assembly assembly)
		{
			SearchLocation loc1 = new SearchLocation() { Assembly = assembly };
			string key1 = loc1.GetHashKey();

			if (!_searchLocations.ContainsKey(key1))
			{
				_searchLocations.Add(key1, loc1);

				this.AssembliesSignature = this.CalculateSignature();
			}
		}

		public static CalystoPhysicalPaths Current { get; private set; }

		public CalystoPhysicalPaths SetAsCurrent()
		{
			if (Current != null)
				throw new InvalidOperationException("Current already created!");

			Current = this;

			return this;
		}
	}
}
