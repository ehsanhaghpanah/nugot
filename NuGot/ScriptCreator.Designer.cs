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
	partial class ScriptCreator
	{
		public class Entry
		{
			public Entry(string path, string name)
			{
				Path = path;
				Name = name;

				Packages = new List<Repository.Item>();
				Process();
			}

			public string Path { get; set; }
			public string Name { get; set; }

			public List<Repository.Item> Packages { get; private set; }

			private void Process()
			{
				try
				{
					var t = Repository.Current.Items;

					var stream = new FileStream(Path, FileMode.Open);
					var reader = new StreamReader(stream);
					var l = reader.ReadToEnd().Split('\n');
					reader.Close();
					stream.Close();

					foreach (var s in l)
					{
						if (s.Contains("moniüs."))
						{
							var na = s.IndexOf("id=", StringComparison.OrdinalIgnoreCase);
							var nb = s.IndexOf("version", StringComparison.OrdinalIgnoreCase);
							var entryName = s.Substring(na + 3, nb - na - 3).Trim().Trim(' ').Trim('\"');

							var pn = t.SingleOrDefault(o => o.Title.Equals(entryName, StringComparison.OrdinalIgnoreCase));
							if (pn == null)
							{
								throw new Exception($"Package {entryName} Not Found In Repository");
							}
							Packages.Add(pn);
						}
					}
				}
				catch (Exception p)
				{
					Console.WriteLine("unable to create entry,");
					Console.WriteLine(p);
				}
			}

			public List<string> GetAscending()
			{
				return Packages.OrderBy(o => o.Order).ToList().Select(o => o.Title).ToList();
			}

			public List<string> GetDecending()
			{
				return Packages.OrderByDescending(o => o.Order).ToList().Select(o => o.Title).ToList();
			}

			public string Format(bool ascending)
			{
				var builder = new StringBuilder();
				var list = ascending ? GetAscending() : GetDecending();
				if (list.Count == 0)
					return string.Empty;
				builder.Append("\t");
				builder.Append("\t");
				builder.Append("\"");
				builder.Append(Name);
				builder.Append("\"=@(");
				foreach (var item in list)
				{
					builder.Append("\n");
					builder.Append("\t");
					builder.Append("\t");
					builder.Append("\t");
					builder.Append("\"");
					builder.Append(item.Trim());
					builder.Append("\"");
					builder.Append(",");
				}

				var n = builder.Length;
				if (n > 0)
				{
					n--;
					if (builder[n] == ',')
					{
						builder.Remove(n, 1);
					}
				}
				builder.Append("\n\t\t);\n");
				return builder.ToString();
			}
		}
	}
}