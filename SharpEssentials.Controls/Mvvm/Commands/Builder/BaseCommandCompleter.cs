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
using System.Threading.Tasks;
using System.Windows.Input;

namespace SharpEssentials.Controls.Mvvm.Commands.Builder
{
    /// <summary>
    /// Convenient base class for command completers.
    /// </summary>
    public abstract class BaseCommandCompleter : ICommandCompleter
    {
        /// <summary>
        /// Sets the operation that a command will execute.
        /// </summary>
        /// <param name="operation">The parameterless operation to be executed</param>
        /// <returns>A new command</returns>
        public ICommand Executes(Action operation) => Executes<object>(_ => operation());

        /// <summary>
        /// Sets the operation that a command will execute.
        /// </summary>
        /// <param name="operation">The operation to be executed</param>
        /// <returns>A new command</returns>
        public ICommand Executes<T>(Action<T> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            var command = new TriggeredRelayCommand<T>(operation, CanExecute<T>());
            return Configure(command);
        }

        /// <summary>
        /// Sets the asynchronous operation that a command will execute.
        /// </summary>
        /// <param name="operation">The parameterless, asynchronous operation to be executed</param>
        /// <returns>A new command</returns>
        public IAsyncCommand ExecutesAsync(Func<Task> operation) => ExecutesAsync<object>(_ => operation());

        /// <summary>
        /// Sets the asynchronous operation that a command will execute.
        /// </summary>
        /// <param name="operation">The asynchronous operation to be executed</param>
        /// <returns>A new command</returns>
        public IAsyncCommand ExecutesAsync<T>(Func<T, Task> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            var command = new TriggeredAsyncRelayCommand<T>(operation, CanExecute<T>());
            return Configure(command);
        }

        /// <summary>
        /// When overridden, provides a predicate that determines whether a command can be executed.
        /// </summary>
        protected abstract Predicate<T> CanExecute<T>(); 

        /// <summary>
        /// When overridden, configures a command.
        /// </summary>
        /// <param name="command">The command to configure.</param>
        protected virtual TCommand Configure<TCommand>(TCommand command) where TCommand : ITriggerableCommand => command;
    }
}