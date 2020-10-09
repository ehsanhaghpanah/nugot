/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using System.IO;
using System.Linq;

namespace NuGot
{
	/// <summary>
	/// moniüs NuGet repository,
	/// manages list of packages and their indices,
	/// </summary>
	public sealed partial class Repository
	{
		/// <summary>
		/// checks if there is any package in repository path that does not exist in repository database (XML),
		/// </summary>
		/// <param name="path"></param>
		public bool Check(string path)
		{
			try
			{
				var di = new DirectoryInfo(path);
				var ls = di.GetFiles("moniüs*");
				var ns = Items.Select(o => o.Title + ".0.4.0.0.nupkg").ToList();

				foreach (var fi in ls)
				{
					if (!ns.Contains(fi.Name))
					{
						Console.WriteLine("package {0} not found in XML database.", fi.Name);
						return false;
					}
				}

				return true;
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
				return false;
			}
		}
	}
}