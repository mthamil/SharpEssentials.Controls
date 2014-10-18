// Sharp Essentials
// Copyright 2014 Matthew Hamilton - matthamilton@live.com
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
// 
using SharpEssentials.Controls.Mvvm.Commands.Builder;

namespace SharpEssentials.Controls.Mvvm.Commands
{
	public static class AsyncCommandBuilderExtensions
	{
		/// <summary>
		/// Indicates that a command executes an asynchronous operation.
		/// </summary>
		public static IAsyncCommandCompleter Asynchronously(this ICommandCompleter completer)
		{
			return new AsyncCommandCompleterWrapper(completer);
		}
	}
}