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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SharpEssentials.Controls.Localization
{
    public partial class LocalizeExtension
    {
        /// <summary>
        /// The associated binding for the extension.
        /// </summary>
        public Binding Binding => _binding.Value;

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ElementName"/>.
        /// </summary>
        [DefaultValue(null)]
        public string BindingElementName
        {
            get => Binding.ElementName;
            set => Binding.ElementName = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.Path"/>.
        /// </summary>
        [DefaultValue(null)]
        public PropertyPath BindingPath
        {
            get => Binding.Path;
            set => Binding.Path = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.RelativeSource"/>.
        /// </summary>
        [DefaultValue(null)]
        public RelativeSource BindingRelativeSource
        {
            get => Binding.RelativeSource;
            set => Binding.RelativeSource = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.Source"/>.
        /// </summary>
        [DefaultValue(null)]
        public object BindingSource
        {
            get => Binding.Source;
            set => Binding.Source = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.XPath"/>.
        /// </summary>
        [DefaultValue(null)]
        public string BindingXPath
        {
            get => Binding.XPath;
            set => Binding.XPath = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.Converter"/>.
        /// </summary>
        [DefaultValue(null)]
        public IValueConverter BindingConverter
        {
            get => Binding.Converter;
            set => Binding.Converter = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.BindingBase.BindingGroupName"/>.
        /// </summary>
        [DefaultValue(null)]
        public string BindingGroupName
        {
            get => Binding.BindingGroupName;
            set => Binding.BindingGroupName = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ConverterCulture"/>.
        /// </summary>
        [DefaultValue(null)]
        public CultureInfo BindingConverterCulture
        {
            get => Binding.ConverterCulture;
            set => Binding.ConverterCulture = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ConverterParameter"/>.
        /// </summary>
        [DefaultValue(null)]
        public object BindingConverterParameter
        {
            get => Binding.ConverterParameter;
            set => Binding.ConverterParameter = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.BindsDirectlyToSource"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindsDirectlyToSource
        {
            get => Binding.BindsDirectlyToSource;
            set => Binding.BindsDirectlyToSource = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.Mode"/>.
        /// </summary>
        [DefaultValue(BindingMode.Default)]
        public BindingMode BindingMode
        {
            get => Binding.Mode;
            set => Binding.Mode = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.NotifyOnSourceUpdated"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingNotifyOnSourceUpdated
        {
            get => Binding.NotifyOnSourceUpdated;
            set => Binding.NotifyOnSourceUpdated = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.NotifyOnTargetUpdated"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingNotifyOnTargetUpdated
        {
            get => Binding.NotifyOnTargetUpdated;
            set => Binding.NotifyOnTargetUpdated = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.NotifyOnValidationError"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingNotifyOnValidationError
        {
            get => Binding.NotifyOnValidationError;
            set => Binding.NotifyOnValidationError = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.AsyncState"/>.
        /// </summary>
        [DefaultValue(null)]
        public object BindingAsyncState
        {
            get => Binding.AsyncState;
            set => Binding.AsyncState = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.IsAsync"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingIsAsync
        {
            get => Binding.IsAsync;
            set => Binding.IsAsync = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.BindingBase.FallbackValue"/>.
        /// </summary>
        [DefaultValue(null)]
        public object BindingFallbackValue
        {
            get => Binding.FallbackValue;
            set => Binding.FallbackValue = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.BindingBase.TargetNullValue"/>.
        /// </summary>
        [DefaultValue(null)]
        public object BindingTargetNullValue
        {
            get => Binding.TargetNullValue;
            set => Binding.TargetNullValue = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ValidatesOnDataErrors"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingValidatesOnDataErrors
        {
            get => Binding.ValidatesOnDataErrors;
            set => Binding.ValidatesOnDataErrors = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ValidatesOnExceptions"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool BindingValidatesOnExceptions
        {
            get => Binding.ValidatesOnExceptions;
            set => Binding.ValidatesOnExceptions = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.UpdateSourceTrigger"/>.
        /// </summary>
        [DefaultValue(UpdateSourceTrigger.Default)]
        public UpdateSourceTrigger BindingUpdateSourceTrigger
        {
            get => Binding.UpdateSourceTrigger;
            set => Binding.UpdateSourceTrigger = value;
        }

        /// <summary>
        /// Use the Resx value to format bound data.  See <see cref="System.Windows.Data.Binding.ValidationRules"/>.
        /// </summary>
        [DefaultValue(false)]
        public Collection<ValidationRule> BindingValidationRules => Binding.ValidationRules;
    }
}