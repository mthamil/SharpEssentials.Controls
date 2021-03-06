﻿// Sharp Essentials Controls
// Copyright 2017 Matthew Hamilton - matthamilton@live.com
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

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace SharpEssentials.Controls.Converters
{
	/// <summary>
	/// Converts between <see cref="FileInfo"/>s and <see cref="Uri"/>s.
	/// </summary>
	[ValueConversion(typeof(FileInfo), typeof(Uri))]
	public class FileInfoToUriConverter : IValueConverter
	{
		/// <see cref="IValueConverter.Convert"/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var file = value as FileInfo;
			return file == null ? null : new Uri(file.FullName);
		}
		
		/// <see cref="IValueConverter.ConvertBack"/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var uri = value as Uri;
			return uri == null ? null : new FileInfo(uri.LocalPath);
		}
	}
}