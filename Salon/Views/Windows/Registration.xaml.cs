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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void WorkerTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            workerPlaceholder.Visibility = Visibility.Hidden;
        }

        private void WorkerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WorkerTextBox.Text))
            {
                workerPlaceholder.Visibility = Visibility.Visible;
            }
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
    }
}
