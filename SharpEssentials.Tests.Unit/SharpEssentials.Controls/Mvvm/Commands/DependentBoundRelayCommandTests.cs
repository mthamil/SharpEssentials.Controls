﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using SharpEssentials.Controls.Mvvm.Commands;
using SharpEssentials.Observable;
using SharpEssentials.Testing;
using Xunit;

namespace SharpEssentials.Tests.Unit.SharpEssentials.Controls.Mvvm.Commands
{
	public class DependentBoundRelayCommandTests
	{
		[Theory]
		[InlineData(true, new [] { true, true })]
		[InlineData(true, new[] { true, false })]
		[InlineData(true, new[] { false, true })]
		[InlineData(false, new[] { false, false })]
		public void Test_CanExecute(bool expected, bool[] values)
		{
			// Arrange.
			var parent = new TestParent();
			foreach (var value in values)
			{
				var child = new TestItem { BoolValue = value };
				parent.Items.Add(child);
			}

			var command = Command.For(parent)
			                     .DependsOnCollection(p => p.Items)
			                     .Where(p => p.DependentBoolValue)
			                     .DependsOn(c => c.BoolValue)
			                     .Executes(() => { });

			// Act.
			bool actual = command.CanExecute(null);
			
			// Assert.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Test_CanExecuteChanged()
		{
			// Arrange.
			var parent = new TestParent();
			var child1 = new TestItem();
			var child2 = new TestItem();

			var command = Command.For(parent)
								 .DependsOnCollection(p => p.Items)
								 .Where(p => p.DependentBoolValue)
								 .DependsOn(c => c.BoolValue)
								 .Executes(() => { });

			parent.Items.Add(child1);
			parent.Items.Add(child2);

			// Act/Assert.
			foreach (var child in parent.Items)
			{
				var localChild = child;
				AssertThat.Raises(command, c => c.CanExecuteChanged += null, () => localChild.BoolValue = true);
				AssertThat.DoesNotRaise(command, c => c.CanExecuteChanged += null, () => localChild.BoolValue = true);
			}
		}

		[Fact]
		public void Test_CanExecuteChanged_CollectionCleared()
		{
			// Arrange.
			var parent = new TestParent();
			var child1 = new TestItem();
			var child2 = new TestItem();

			var command = Command.For(parent)
								 .DependsOnCollection(p => p.Items)
								 .Where(p => p.DependentBoolValue)
								 .DependsOn(c => c.BoolValue)
								 .Executes(() => { });

			parent.Items.Add(child1);
			parent.Items.Add(child2);

			// Act/Assert.
			parent.Items.Clear();

			foreach (var child in new [] { child1, child2 })
			{
				var localChild = child;
				AssertThat.DoesNotRaise(command, c => c.CanExecuteChanged += null, () => localChild.BoolValue = true);
			}
		}

		[Fact]
		public void Test_CanExecuteChanged_ItemRemoved()
		{
			// Arrange.
			var parent = new TestParent();
			var child = new TestItem();

			var command = Command.For(parent)
								 .DependsOnCollection(p => p.Items)
								 .Where(p => p.DependentBoolValue)
								 .DependsOn(c => c.BoolValue)
								 .Executes(() => { });

			parent.Items.Add(child);

			// Act/Assert.
			parent.Items.Remove(child);
			AssertThat.DoesNotRaise(command, c => c.CanExecuteChanged += null, () => child.BoolValue = true);
		}

		[Fact]
		public void Test_Execute()
		{
			// Arrange.
			var parent = new TestParent();

			bool executed = false;
			var command = Command.For(parent)
								 .DependsOnCollection(p => p.Items)
								 .Where(p => p.DependentBoolValue)
								 .DependsOn(c => c.BoolValue)
								 .Executes(() => executed = true);

			// Act.
			command.Execute(null);

			// Assert.
			Assert.True(executed);
		}

		[Fact]
		public void Test_ParentProperty_MustBeGetOnly()
		{
			// Arrange.
			var parent = new TestParent();

			var builder = Command.For(parent)
			                     .DependsOnCollection(p => p.Items);

			// Act/Assert.
			Assert.Throws<ArgumentException>(() =>
				builder
					.Where(p => p.IndependentBoolValue)
					.DependsOn(c => c.BoolValue)
					.Executes(() => { }));
		}

		private class TestParent : ObservableObject
		{
			public TestParent()
			{
				_items = Property.New(this, p => p.Items, OnPropertyChanged);
				_items.Value = new ObservableCollection<TestItem>();
			}

			public ObservableCollection<TestItem> Items => _items.Value;

		    public bool IndependentBoolValue { get; set; }

			public bool DependentBoolValue => Items.Any(i => i.BoolValue);

		    private readonly Property<ObservableCollection<TestItem>> _items;
		}

		private class TestItem : ObservableObject
		{
			public TestItem()
			{
				_boolValue = Property.New(this, p => BoolValue, OnPropertyChanged);
			}

			public bool BoolValue
			{
				get { return _boolValue.Value; }
				set { _boolValue.Value = value; }
			}

			private readonly Property<bool> _boolValue;
		}
	}
}
