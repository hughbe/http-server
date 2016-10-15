using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers
{
	public class HomeController : Controller
	{
		public string RootDirectory { get; set; } = "C:/Users/hughb/";

        [Authorize]
		public IActionResult Index(string path)
        {
            string fullPath = Path.Combine(RootDirectory, path ?? string.Empty);
            if (!fullPath.StartsWith(RootDirectory))
            {
                ViewData["ErrorOccured"] = true;
                ViewData["ErrorMesage"] = $"Access was denied reading file or folder at the path {fullPath}";
                return View();
            }
            try
			{
				ViewResult directoryContents = GetDirectoryContents(fullPath);
				if (directoryContents != null)
				{
					return directoryContents;
				}

				PhysicalFileResult fileContents = GetFileContents(fullPath);
				if (fileContents != null)
				{
					return fileContents;
				}

                ViewData["ErrorOccured"] = true;
                ViewData["ErrorMessage"] = $"No such file or folder exists at the path {fullPath}";
                return View();
			}
			catch (SecurityException)
            {
                ViewData["ErrorOccured"] = true;
                ViewData["ErrorMesage"] = $"Access was denied reading file or folder at the path {fullPath}";
                return View();
            }
			catch (UnauthorizedAccessException)
            {
                ViewData["ErrorOccured"] = true;
                ViewData["ErrorMesage"] = $"Access was denied reading file or folder at the path {fullPath}";
                return View();
            }
		}

		private ViewResult GetDirectoryContents(string path)
		{
			if (!Directory.Exists(path))
			{
				return null;
			}
			if (!path.EndsWith("/"))
			{
				path += '/';
			}
			if (!path.StartsWith(RootDirectory))
			{
				return null;
			}
			List<string> paths = new List<string>();
			foreach (var directoryPath in Directory.GetDirectories(path))
			{
				var objectPath = directoryPath.Replace(path, "") + "/";
				paths.Add(objectPath);
			}

			foreach (var filePath in Directory.GetFiles(path))
			{
				var objectPath = filePath.Replace(path, "");
				paths.Add(objectPath);
			}
			bool isRootDirectory = path == RootDirectory;
			string relativeDirectory = path.Substring(RootDirectory.Length);
			string previousRelativeDirectory = isRootDirectory ? null : Path.GetFullPath(Path.Combine(path, @"..\")).Substring(RootDirectory.Length);
			ViewData["IsRootDirectory"] = path == RootDirectory;
			ViewData["RootDirectory"] = RootDirectory;
			ViewData["CurrentDirectory"] = path;
			ViewData["CurrentRelativeDirectory"] = relativeDirectory;
			ViewData["PreviousRelativeDirectory"] = previousRelativeDirectory;
			ViewData["FilesAndDirectories"] = paths;
			return View();
		}

		private PhysicalFileResult GetFileContents(string path)
		{
			if (!System.IO.File.Exists(path))
			{
				return null;
			}
			return new PhysicalFileResult(path, "application/unknown");
		}
	}
}
