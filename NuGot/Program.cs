/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using System.Globalization;
using System.IO;

namespace NuGot
{
	static public partial class Program
	{
		static void Main(string[] args)
		{
			try
			{
				goo();
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
			}
		}

		static public void goo()
		{
			if (!Repository.Current.Check(@"c:\nuget\g4"))
				return;

			var ls = Depository.GetItems();

			foreach (var pi in ls)
			{
				if (!File.Exists(Path.Combine(pi.Path, pi.Name + ".ps1")))
				{
					Console.WriteLine($"ps file not found at {pi.Path},");
					break;
				}
				Console.WriteLine($"updating script in -> {pi.Path}");
				var scriptCreator = new ScriptCreator(pi.Path);
				scriptCreator.Process(Path.Combine(pi.Path, pi.Name + ".ps1"));
			}

			Console.WriteLine();
			Console.WriteLine("press any key to exit.");
			Console.ReadLine();
		}

		static public void foo()
		{
			string path;
			while (true)
			{
				if (GetArgument("<Depository Path>", out path))
					break;
			}

			Console.Clear();
			Console.WriteLine(path);
		}

		static private bool GetArgument(string name, out string value)
		{
			try
			{
				Console.WriteLine($"please enter {name}");
				value = Console.ReadLine();
				return true;
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
				value = null;
				return false;
			}
		}
	}
}
