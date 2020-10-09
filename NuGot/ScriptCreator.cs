/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NuGot
{
	/// <summary>
	/// 
	/// </summary>
	public sealed partial class ScriptCreator
	{
		public List<DirectoryInfo> Directorys { get; }
		public DirectoryInfo Root { get; }
		public List<Entry> Entrys { get; }

		private void Traverse(DirectoryInfo d)
		{
			//Console.WriteLine($"traversing -> {d.Name}");

			if (d.GetFiles().Any(f => f.Name.Contains(@"packages.config")))
				Directorys.Add(d);

			foreach (var s in d.GetDirectories())
			{
				Traverse(s);
			}
		}

		public ScriptCreator(string path)
		{
			try
			{
				Root = new DirectoryInfo(path);
				Directorys = new List<DirectoryInfo>();
				Traverse(Root);

				Entrys = new List<Entry>();
				foreach (var directory in Directorys)
				{
					var name = directory.FullName.Substring(Root.FullName.Length + 1);
					Entrys.Add(new Entry(directory.FullName + @"\packages.config", name));
				}
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name">.ps1 file in solution root path,</param>
		public bool AreEqual(string name)
		{
			try
			{
				var ascending = new StringBuilder();
				var decending = new StringBuilder();

				foreach (var entry in Entrys)
				{
					ascending.Append(entry.Format(true));
					decending.Append(entry.Format(false));
				}

				//
				// creating script body,
				var t = ResourceObjects.String1;
				t = t.Replace("{0}", decending.ToString());
				t = t.Replace("{1}", ascending.ToString());
				t = t.Trim();

				//
				// writing into file
				var f = new FileStream(name, FileMode.Open);
				var r = new StreamReader(f);
				var u = r.ReadToEnd().Trim();
				r.Close();
				f.Close();

				t = t.Trim();
				u = u.Trim();

				return u.Equals(t, StringComparison.OrdinalIgnoreCase);
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
				return false;
			}
		}

		public void Process(string name)
		{
			try
			{
				var ascending = new StringBuilder();
				var decending = new StringBuilder();

				foreach (var entry in Entrys)
				{
					ascending.Append(entry.Format(true));
					decending.Append(entry.Format(false));
				}

				//
				// creating script body,
				var t = ResourceObjects.String1;
				t = t.Replace("{0}", decending.ToString());
				t = t.Replace("{1}", ascending.ToString());
				t = t.Trim();

				//
				// writing into file
				var w = new StreamWriter(name, false, Encoding.UTF8);
				w.Write(t);
				w.Close();
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
			}
		}
	}
}