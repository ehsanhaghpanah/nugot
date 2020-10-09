/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace NuGot
{
	/// <summary>
	/// 
	/// </summary>
	public sealed partial class Depository
	{
		public static List<Item> GetItems()
		{
			try
			{
				var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
				if (string.IsNullOrEmpty(path))
					throw new Exception("depository-path-not-correct");

				path = Path.Combine(path, "Depository.xml");

				var ls = new List<Item>();
				var ds = new DataSet();
				ds.ReadXml(path);
				var dt = ds.Tables[0];
				foreach (DataRow dr in dt.Rows)
				{
					ls.Add(new Item(dr));
				}
				return ls;
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
				return null;
			}
		}

		public static List<string> GetNames()
		{
			return GetItems().Select(o => o.Name).ToList();
		}
	}
}