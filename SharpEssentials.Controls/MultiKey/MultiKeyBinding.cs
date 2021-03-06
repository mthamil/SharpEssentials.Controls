// Sharp Essentials Controls
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
using System.ComponentModel;
using System.Windows.Input;

namespace SharpEssentials.Controls.MultiKey
{
	/// <summary>
	/// Provides a multi-key input binding.
	/// </summary>
	public class MultiKeyBinding : InputBinding
	{
		/// <see cref="InputBinding.Gesture"/>
		[TypeConverter(typeof(MultiKeyGestureConverter))]
		public override InputGesture Gesture
		{
			get { return base.Gesture as MultiKeyGesture; }
			set
			{
				if (!(value is MultiKeyGesture))
					throw new ArgumentException(@"Gesture does not support multiple keys.", nameof(value));

				base.Gesture = value;
			}
		}
	}
}