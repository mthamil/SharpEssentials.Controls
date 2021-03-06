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
using System.Threading;
using System.Windows;

namespace SharpEssentials.Controls.Localization
{
    /// <summary>
    /// Provides the ability to change the UICulture for WPF Windows and controls
    /// dynamically.  
    /// </summary>
    /// <remarks>
    /// XAML elements that use the <see cref="LocalizeExtension"/> are automatically
    /// updated when the <see cref="CultureManager.UICulture"/> property is changed.
    /// </remarks>
    public class CultureManager : ICultureManager
    {
        /// <summary>
        /// The default culture manager instance.
        /// </summary>
        public static ICultureManager Default => DefaultInstance;

        /// <summary>
        /// Sets the UICulture for a <see cref="CultureManager"/> and raises the <see cref="UICultureChanged"/>
        /// event causing any XAML elements using the <see cref="LocalizeExtension"/> to automatically
        /// update.
        /// </summary>
        public CultureInfo UICulture
        {
            get
            {
                return _uiCulture ?? (_uiCulture = Thread.CurrentThread.CurrentUICulture);
            }
            set
            {
                if (value != UICulture)
                {
                    _uiCulture = value;
                    Thread.CurrentThread.CurrentUICulture = value;
                    if (KeepThreadCurrentCultureInSync)
                    {
                        UpdateThreadCulture(value);
                    }

                    OnUICultureChanged();
                }
            }
        }

        /// <summary>
        /// Raised when the <see cref="UICulture"/> is changed.
        /// </summary>
        /// <remarks>
        /// It is advisable to use a <see cref="WeakEventManager"/> to subscribe to this event since a <see cref="CultureManager"/>
        /// will often far outlive its multitude of listeners.
        /// </remarks>
        public event EventHandler<EventArgs> UICultureChanged;

        private void OnUICultureChanged()
        {
            UICultureChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// If set to true then the <see cref="Thread.CurrentCulture"/> property is changed
        /// to match the current <see cref="UICulture"/>.
        /// </summary>
        public bool KeepThreadCurrentCultureInSync
        {
            get { return _keepThreadCurrentCultureInSync; }
            set
            {
                _keepThreadCurrentCultureInSync = value;
                if (value)
                {
                    UpdateThreadCulture(UICulture);
                }
            }
        }

        /// <summary>
        /// Sets the thread culture to the given culture.
        /// </summary>
        /// <param name="value">The culture to set</param>
        /// <remarks>If the culture is neutral then a specific culture is created.</remarks>
        private void UpdateThreadCulture(CultureInfo value)
        {
            Thread.CurrentThread.CurrentCulture = value.IsNeutralCulture
                ? CultureInfo.CreateSpecificCulture(value.Name) 
                : value;
        }

        /// <summary>
        /// The current UICulture of the manager.
        /// </summary>
        private CultureInfo _uiCulture;

        /// <summary>
        /// Whether the <see cref="Thread.CurrentCulture"/> should be changed 
        /// when the <see cref="UICulture"/> changes.
        /// </summary>
        private bool _keepThreadCurrentCultureInSync = true;

        private static readonly CultureManager DefaultInstance = new CultureManager();
    }
}
