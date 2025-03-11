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
using System.Windows.Shapes;

namespace ToDoListDev.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowDeleteTask.xaml
    /// </summary>
    public partial class WindowDeleteTask : Window
    {
        public WindowDeleteTask()
        {
            InitializeComponent();
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
        }
    }
}
