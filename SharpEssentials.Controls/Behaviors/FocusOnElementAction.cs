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
using System.Windows;
using System.Windows.Interactivity;

namespace SharpEssentials.Controls.Behaviors
{
	/// <summary>
	/// An action that focuses on a given UI element.
	/// </summary>
	public class FocusOnElementAction : TriggerAction<UIElement>
	{
		#region Overrides of TriggerAction

		/// <see cref="System.Windows.Interactivity.TriggerAction.Invoke"/>
		protected override void Invoke(object parameter)
		{
			Dispatcher.BeginInvoke(new Action(() => ElementToFocus.Focus()));
		}

		#endregion

		/// <summary>
		/// The element to focus on.
		/// </summary>
		public UIElement ElementToFocus
		{
			get => (UIElement)GetValue(ElementToFocusProperty);
		    set => SetValue(ElementToFocusProperty, value);
		}

		/// <summary>
		/// The ElementToFocus dependency property.
		/// </summary>
		public static readonly DependencyProperty ElementToFocusProperty =
			DependencyProperty.Register(nameof(ElementToFocus),
			typeof(UIElement),
			typeof(FocusOnElementAction),
			new UIPropertyMetadata(default(UIElement)));
	}
}