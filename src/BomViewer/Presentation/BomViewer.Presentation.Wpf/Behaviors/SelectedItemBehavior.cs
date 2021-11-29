using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace BomViewer.Presentation.Wpf.Behaviors
{
    /// <summary>
    /// TreeViewItem selection behavior
    /// </summary>
    public class SelectedItemBehavior : Behavior<TreeView>
    {
        #region Properties

        #region SelectedItem

        /// <summary>
        /// Selected Item
        /// </summary>
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is TreeViewItem item)
            {
                item.SetValue(TreeViewItem.IsSelectedProperty, true);
            }
        }

        #endregion


        #region Command

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(SelectedItemBehavior), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Selected item changed command
        /// </summary>
        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion

        #endregion


        #region Methods

        /// <summary>
        /// See <see cref="Behavior.OnAttached"/>
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        /// <summary>
        /// See <see cref="Behavior.OnDetaching"/>
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        /// <summary>
        /// See <see cref="TreeView.SelectedItemChanged"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;

            if (Command?.CanExecute(e.NewValue) == true)
            {
                Command?.Execute(e.NewValue);
            }
        }

        #endregion
    }
}