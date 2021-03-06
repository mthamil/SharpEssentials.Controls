﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using SharpEssentials.Controls.Behaviors;
using SharpEssentials.Observable;
using Xunit;

namespace SharpEssentials.Tests.Unit.SharpEssentials.Controls.Behaviors
{
    public class TreeViewBindableSelectedItemTests
    {
        [WpfFact]
        public void Test_BindableSelectedItem_View_To_ViewModel()
        {
            // Arrange.
            var selectedItemWatcher = new SelectedItemWatcher();
            var child = new TestViewModel();
            selectedItemWatcher.Children.Add(child);

            var childView = new TreeViewItem { DataContext = child };
            var isSelectedBinding = new Binding(nameof(TreeViewItem.IsSelected)) { Mode = BindingMode.TwoWay };
            childView.SetBinding(TreeViewItem.IsSelectedProperty, isSelectedBinding);

            var treeView = new TreeView { DataContext = selectedItemWatcher };
            treeView.Items.Add(childView);

            var behavior = new TreeViewBindableSelectedItem();
            behavior.Attach(treeView);

            // Act.
            childView.IsSelected = true;

            // Assert.
            Assert.True(child.IsSelected);
            Assert.Equal(childView, behavior.SelectedItem);	// SelectedItem is a TreeViewItem because the 
                                                            // TreeView's ItemsSource isn't set.  Couldn't get 
                                                            // items to generate in the test.
        }

        public class TestViewModel : ObservableObject
        {
            public TestViewModel()
            {
                _isSelected = Property.New(this, p => p.IsSelected, OnPropertyChanged);
            }

            public bool IsSelected
            {
                get { return _isSelected.Value; }
                set { _isSelected.Value = value; }
            }

            private readonly Property<bool> _isSelected;
        }

        public class SelectedItemWatcher : ObservableObject
        {
            public SelectedItemWatcher()
            {
                _selectedItem = Property.New(this, p => p.SelectedItem, OnPropertyChanged);
                _children = Property.New(this, p => p.Children, OnPropertyChanged);
                _children.Value = new ObservableCollection<TestViewModel>();
            }

            public object SelectedItem
            {
                get { return _selectedItem.Value; }
                set { _selectedItem.Value = value; }
            }
            private readonly Property<object> _selectedItem;

            public ICollection<TestViewModel> Children => _children.Value;
            private readonly Property<ICollection<TestViewModel>> _children;
        }
    }
}
