using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SE_4220_HW4_WPF
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Enter text here...";
                resultList.Visibility = Visibility.Collapsed;
            }
            resultList.Visibility = Visibility.Collapsed;
        }

        private void SearchBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (searchBox.Text != "Enter Text here...")
            {
                searchBox.Text = "";
            }
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            resultList.Visibility = Visibility.Visible;

            if (e.Key != Key.Down)
                foreach (ListBoxItem listItem in resultList.Items)
                {
                    String val = listItem.Content as String;

                    listItem.Visibility = System.Text.RegularExpressions.Regex.IsMatch(val.ToLower(), searchBox.Text.ToLower()) ? Visibility.Visible : Visibility.Collapsed;
                }
            else
                foreach (ListBoxItem listItem in resultList.Items)
                {
                    if (listItem.Visibility == Visibility.Visible)
                    {
                        listItem.Focus();
                        resultList.Visibility = Visibility.Visible;
                        break;
                    }
                }
        }

        private void ListBoxItem_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                Clipboard.SetText(instructions.Text as string);
            }
        }

        private void ListBoxItem_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                System.Windows.Application.Current.Shutdown();
        }
    }
}
