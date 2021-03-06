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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SharpEssentials.Controls.Converters
{
	/// <summary>
	/// Converts a URI source to a bitmap image.
	/// </summary>
	[ValueConversion(typeof(Uri), typeof(ImageSource))]
	public class UriToCachedImageConverter : IValueConverter
	{
		/// <see cref="IValueConverter.Convert"/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			var imageUri = (Uri)value;
			var bitmap = new BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = imageUri;
			bitmap.CacheOption = CacheOption;
			bitmap.CreateOptions = InitOptions;
			try
			{
				bitmap.EndInit();
				return bitmap;
			}
			catch
			{
				return default(BitmapImage);
			}
		}

		/// <see cref="IValueConverter.ConvertBack"/>
		/// <exception cref="NotImplementedException">Always throws</exception>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Two way conversion is not supported.");
		}

		/// <summary>
		/// Bitmap initialization options.
		/// </summary>
		public BitmapCreateOptions InitOptions { get; set; }

		/// <summary>
		/// Bitmap cache options.
		/// </summary>
		public BitmapCacheOption CacheOption { get; set; }
	}
}