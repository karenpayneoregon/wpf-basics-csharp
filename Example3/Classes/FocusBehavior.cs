using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Example3.Classes
{
    /// <summary>
    /// attached behavior for selecting first control in a window
    /// </summary>
    public static class FocusBehavior
    {
        public static readonly DependencyProperty GiveInitialFocusProperty =
            DependencyProperty.RegisterAttached("GiveInitialFocus",typeof(bool),typeof(FocusBehavior),
                new PropertyMetadata(false, OnFocusFirstPropertyChanged));

        public static bool GetGiveInitialFocus(Control control) => (bool)control.GetValue(GiveInitialFocusProperty);
        public static void SetGiveInitialFocus(Control control, bool value) => control.SetValue(GiveInitialFocusProperty, value);

        private static void OnFocusFirstPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (!(sender is Control control) || !(args.NewValue is bool))
            {
                return;
            }

            if ((bool)args.NewValue)
            {
                control.Loaded += OnControlLoaded;
            }
            else
            {
                control.Loaded -= OnControlLoaded;
            }
        }

        private static void OnControlLoaded(object sender, RoutedEventArgs e) => 
            ((Control)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    }
}