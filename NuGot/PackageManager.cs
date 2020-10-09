/**
 * Copyright (C) moniüs, 2015.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

namespace NuGot
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class PackageManager
	{
		private PackageManager()
		{

		}

		private static PackageManager _Current;

		public static PackageManager Current
		{
			get
			{
				return _Current ?? (_Current = new PackageManager());
			}
		}
	}
}