﻿using System.Windows;

namespace STEP_PAY.Helpers
{
    internal class CloseDialogBehavior
    {
        public static readonly DependencyProperty CloseDialogProperty
            = DependencyProperty.RegisterAttached("CloseDialog", typeof(bool), typeof(CloseDialogBehavior), new PropertyMetadata(false, OnCloseDialogPropertyChanged));

        public static bool GetCloseDialog(Window dlg)
        {
            return (bool)dlg.GetValue(CloseDialogProperty);
        }

        public static void SetCloseDialog(Window dlg, bool value)
        {
            dlg.SetValue(CloseDialogProperty, value);
        }

        private static void OnCloseDialogPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window dlg = d as Window;
            bool isClose = (bool)e.NewValue;
            if (dlg == null || !isClose)
            {
                return;
            }

            dlg.Close();
        }
    }
}
