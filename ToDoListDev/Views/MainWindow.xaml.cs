﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace ToDoListDev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnRight.IsEnabled = false;
            BtnRight.Visibility = Visibility.Hidden;
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            var BlackColor = (SolidColorBrush) this.FindResource("MainBlackBrush");
            var WhiteColor = (SolidColorBrush) this.FindResource("MainWhite");

            SwitchBorder.Background = BlackColor;
            SwitchBorder.BorderBrush = WhiteColor;

            BtnRight.IsEnabled = true;
            BtnRight.Visibility = Visibility.Visible;

            Button ThisButton = sender as Button;
            ThisButton.IsEnabled = false;
            ThisButton.Visibility = Visibility.Hidden;

            const string STYLENAME = "StylesDark";

            var Uri = new Uri($"Styles/{STYLENAME}.xaml", UriKind.Relative);

            ResourceDictionary ResourceDict = Application.LoadComponent(Uri) as ResourceDictionary;

            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(ResourceDict);
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            var BlackColor = (SolidColorBrush) this.FindResource("MainBlackBrush");
            var WhiteColor = (SolidColorBrush) this.FindResource("MainWhite");

            SwitchBorder.Background = WhiteColor;
            SwitchBorder.BorderBrush = BlackColor;

            BtnLeft.IsEnabled = true;
            BtnLeft.Visibility = Visibility.Visible;

            Button ThisButton = sender as Button;
            ThisButton.IsEnabled = false;
            ThisButton.Visibility = Visibility.Hidden;

            const string STYLENAME = "Styles";

            var Uri = new Uri($"Styles/{STYLENAME}.xaml", UriKind.Relative);

            ResourceDictionary ResourceDict = Application.LoadComponent(Uri) as ResourceDictionary;

            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(ResourceDict);
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}