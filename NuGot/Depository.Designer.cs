/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System.Data;

namespace NuGot
{
	partial class Depository
	{
		public class Item
		{
			public Item()
			{
			}

			public Item(DataRow dataRow)
			{
				Name = dataRow["Name"].ToString();
				Path = dataRow["Path"].ToString();
			}

			public string Name { get; set; }
			public string Path { get; set; }
		}
	}
}