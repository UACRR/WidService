using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace LanguageService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GridView_OnCopyingCellClipboardContent(object sender, GridViewCellClipboardEventArgs e)
        {
            var selectedColumn = ((Telerik.Windows.Controls.GridView.GridViewDataControl)e.OriginalSource).CurrentColumn.UniqueName;
            if (e.Cell.Column.UniqueName != selectedColumn)
            {
                e.Cancel = true;
            }
        }
    }
    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                    result *= (double)values[i];
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
}
