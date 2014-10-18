﻿// Sharp Essentials
// Copyright 2014 Matthew Hamilton - matthamilton@live.com
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace SharpEssentials.Controls.Converters
{
	/// <summary>
	/// Converts between strings and DirectoryInfos.
	/// </summary>
	[ValueConversion(typeof(DirectoryInfo), typeof(string))]
	public class DirectoryInfoConverter : IValueConverter
	{
		#region Implementation of IValueConverter

		/// <see cref="IValueConverter.Convert"/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var directory = value as DirectoryInfo;
			if (directory == null)
				return string.Empty;

			return directory.FullName;
		}

		/// <see cref="IValueConverter.ConvertBack"/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string path = value as string;
			if (String.IsNullOrEmpty(path))
				return null;

			return new DirectoryInfo(path);
		}

		#endregion
	}
}