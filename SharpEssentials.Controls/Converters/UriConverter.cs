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
using System.Windows.Data;

namespace SharpEssentials.Controls.Converters
{
	/// <summary>
	/// Converts between strings and URIs.
	/// </summary>
	[ValueConversion(typeof(string), typeof(Uri))]
	public class UriConverter : IValueConverter
	{
		#region Implementation of IValueConverter

		/// <see cref="IValueConverter.Convert"/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string uriPath = value as string;
			if (String.IsNullOrEmpty(uriPath))
				return null;

			if (Uri.TryCreate(uriPath, UriKind.RelativeOrAbsolute, out var uri))
				return uri;

			return null;
		}

		/// <see cref="IValueConverter.ConvertBack"/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var uri = value as Uri;
			if (uri == null)
				return string.Empty;

			if (uri.IsFile)
				return uri.LocalPath;

			return uri.ToString();
		}

		#endregion
	}
}