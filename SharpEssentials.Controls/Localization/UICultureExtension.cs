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
using System.Windows.Markup;
using SharpEssentials.Controls.Weak;

namespace SharpEssentials.Controls.Localization
{
    /// <summary>
    /// Markup Extension used to dynamically set the Language property of a markup element to the
    /// the current <see cref="CultureManager.UICulture"/> property value.
    /// </summary>
    /// <remarks>
    /// The culture used for displaying data bound items is based on the Language property.  This
    /// extension allows you to dynamically change the language based on the current 
    /// <see cref="CultureManager.UICulture"/>.
    /// </remarks>
    [MarkupExtensionReturnType(typeof(XmlLanguage))]
    public class UICultureExtension : ManagedMarkupExtension
    {
        /// <summary>
        /// Initializes an instance of the extension to set the language property for an
        /// element to the current <see cref="ICultureManager.UICulture"/> property value.
        /// </summary>
        public UICultureExtension()
            : this(MarkupExtensionManager.For<UICultureExtension>(2), CultureManager.Default)  { }

        /// <summary>
        /// Initializes an instance of the extension to set the language property for an
        /// element to the current <see cref="ICultureManager.UICulture"/> property value.
        /// </summary>
        internal UICultureExtension(MarkupExtensionManager markupExtensionManager, ICultureManager cultureManager)
            : base(markupExtensionManager)
        {
            _cultureManager = cultureManager;

            _cultureManager.AddWeakHandler<ICultureManager, EventArgs>(nameof(ICultureManager.UICultureChanged), cultureManager_UICultureChanged);
        }

        private void cultureManager_UICultureChanged(object sender, EventArgs eventArgs)
        {
            UpdateTargets();
        }

        /// <summary>
        /// Return the <see cref="XmlLanguage"/> to use for the associated Markup element.
        /// </summary>
        /// <returns>
        /// The <see cref="XmlLanguage"/> corresponding to the current 
        /// <see cref="ICultureManager.UICulture"/> property value
        /// </returns>
        protected override object GetValue() => XmlLanguage.GetLanguage(_cultureManager.UICulture.IetfLanguageTag);

        private readonly ICultureManager _cultureManager;
    }
}
