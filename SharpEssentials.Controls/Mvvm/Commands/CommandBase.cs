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
using System.Windows.Input;

namespace SharpEssentials.Controls.Mvvm.Commands
{
	/// <summary>
	/// Provides a base class for commands.
	/// </summary>
	public abstract class CommandBase : ICommand
	{
		/// <see cref="ICommand.CanExecute"/>
		public virtual bool CanExecute(object parameter) => true;

	    /// <see cref="ICommand.Execute"/>
		public abstract void Execute(object parameter);

		/// <see cref="ICommand.CanExecuteChanged"/>
		public virtual event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
		    remove => CommandManager.RequerySuggested -= value;
		}

		/// <summary>
		/// Raises the CanExecuteChanged event.
		/// </summary>
		protected virtual void OnCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
	}
}