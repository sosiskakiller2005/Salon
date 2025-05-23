using Microsoft.Win32;
using Salon.AppData;
using Salon.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private SityStarDbEntities _context = App.GetContext();
        private byte[] _photoBytes;
        public Registration()
        {
            InitializeComponent();
            RoleCmb.ItemsSource = _context.Position.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.SelectedIndex = 0;
        }

        
        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double currentLeft = this.Left;
            double currentTop = this.Top;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();


            mainWindow.Left = currentLeft;
            mainWindow.Top = currentTop;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAgreedChB.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(WorkerTextBox.Text) && !string.IsNullOrEmpty(SurnameTb.Text) && !string.IsNullOrEmpty(loginTextBox.Text) && RoleCmb.SelectedItem != null && 
                    !string.IsNullOrEmpty(ExperienceTb.Text) && !string.IsNullOrEmpty(PhoneTb.Text) && _photoBytes != null && !string.IsNullOrEmpty(passwordBox.Password))
                {
                    try
                    {
                        Employees newEmployee = new Employees()
                        {
                            Name = WorkerTextBox.Text,
                            Surname = SurnameTb.Text,
                            Lastname = LastnameTb.Text,
                            Position = (RoleCmb.SelectedItem as Position),
                            Expirience = Convert.ToInt32(ExperienceTb.Text),
                            Phone = PhoneTb.Text,
                            Photo = _photoBytes,
                            Login = loginTextBox.Text,
                            Password = passwordBox.Password,
                        };
                        _context.Employees.Add(newEmployee);
                        _context.SaveChanges();
                        MessageBoxHelper.Information("Вы успешно зарегистрировались");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBoxHelper.Error("Ошибка регистрации. Проверьте введенные данные.\n" + exc.Message);
                    }
                }
                else
                {
                    MessageBoxHelper.Error("Ошибка регистрации, пожалуйста, заполните все поля.");
                }
            }
            else
            {
                MessageBoxHelper.Error("Пожалуйста, примите условия соглашения.");
            }
        }

        private void ExperienceTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }
        private bool IsTextNumeric(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }

        private void SelectPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _photoBytes = File.ReadAllBytes(openFileDialog.FileName);
                PhotoFileNameTb.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
            }
        }

        private void SurnameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameTb.Text))
            {
                surnamePlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void SurnameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            surnamePlaceholder.Visibility = Visibility.Hidden;
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

        private void LastnameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            lastnamePlaceHolder.Visibility = Visibility.Hidden;
        }

        private void LastnameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastnamePlaceHolder.Text))
            {
                lastnamePlaceHolder.Visibility = Visibility.Visible;
            }
        }
    }
}
