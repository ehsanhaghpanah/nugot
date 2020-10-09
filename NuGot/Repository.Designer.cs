/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace NuGot
{
	partial class Repository
	{
		public class Item
		{
			public string Title { get; set; }
			public int Order { get; set; }

			public Item()
			{
			}

			public Item(DataRow dataRow)
			{
				Title = dataRow["Title"].ToString();
				Order = Convert.ToInt32(fromBase: 16, value: dataRow["Order"].ToString());
			}
		}

		private static Repository _Current;

		public static Repository Current
		{
			get
			{
				return _Current ?? (_Current = new Repository());
			}
		}

		public List<Item> Items { get; }

		private Repository()
		{
			Items = new List<Item>();

			try
			{
				var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
				if (string.IsNullOrEmpty(path))
					throw new Exception("repository-path-not-correct");

				path = Path.Combine(path, "Repository.xml");

				var ds = new DataSet();
				ds.ReadXml(path);
				var dt = ds.Tables[0];
				foreach (DataRow dr in dt.Rows)
				{
					Items.Add(new Item(dr));
				}
			}
			catch (Exception p)
			{
				Console.WriteLine(p);
			}
		}
	}
}