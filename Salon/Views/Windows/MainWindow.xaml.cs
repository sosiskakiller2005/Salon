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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            loginPlaceholder.Visibility = Visibility.Hidden;
        }

        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                loginPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = Visibility.Hidden;
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double currentLeft = this.Left;
            double currentTop = this.Top;

            

            Registration registrationWindow = new Registration();
            registrationWindow.Show();
            this.Close();

            registrationWindow.Left = currentLeft;
            registrationWindow.Top = currentTop;
        }
    }
}
