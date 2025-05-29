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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Salon.AppData;
using Salon.Model;
using Salon.Views.Pages;
using Salon.Views.Windows;

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для SuperMainWindow.xaml
    /// </summary>
    public partial class SuperMainWindow : Window
    {
        private SityStarDbEntities _context = App.GetContext();
        private List<Employees> employees = App.GetContext().Employees.ToList();
        public SuperMainWindow()
        {
            InitializeComponent();
            HomePage homePage = new HomePage();
            MainFrm.Navigate(homePage);

            #region Отображение текущего времени
            AppData.Clock.StartClock();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
            {
                TimeTbl.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();
            #endregion

            RoleTbl.Text = AuthoriseHelper.selectedUser.Position.Name;

            EmployeesLb.ItemsSource = _context.Employees.ToList();

            FrameHelper.selectedFrame = MainFrm;
        }

        private void EmployeesLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow(EmployeesLb.SelectedItem as Employees);
            addEditEmployeeWindow.ShowDialog();
            if (addEditEmployeeWindow.DialogResult == true)
            {
                EmployeesLb.ItemsSource = _context.Employees.ToList();
                Filter();
            }
        }

        #region навигация
        private void HomeBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrm.Navigate(homePage);
        }

        private void EmployeesBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EmployeesPage employeesPage = new EmployeesPage();
            MainFrm.Navigate(employeesPage);
        }

        private void ServicesBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ServicesPage servicesPage = new ServicesPage();
            MainFrm.Navigate(servicesPage);
        }

        private void FileBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            MainFrm.Navigate(appointmentPage);
        }

        private void AppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            MainFrm.Navigate(appointmentPage);
        }

        private void EmptyDaysBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Фильтрация
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            string searchString = SearchTb.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                EmployeesLb.ItemsSource = employees.Where(em =>
                    (em.Name != null && em.Name.ToLower().Contains(searchString)) ||
                    (em.Lastname != null && em.Lastname.ToLower().Contains(searchString)) ||
                    (em.Surname != null && em.Surname.ToLower().Contains(searchString))
                ).ToList();
                if (EmployeesLb.Items.Count == 0)
                {
                    if (AuthoriseHelper.selectedUser.Position.Id == 1)
                    {
                        EmployeesLb.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        EmployeesLb.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    EmployeesLb.Visibility = Visibility.Visible;
                }
            }
            else
            {
                EmployeesLb.ItemsSource = employees;
            }
            if (string.IsNullOrWhiteSpace(SearchTb.Text))
            {
                EmployeesLb.ItemsSource = employees;
            }
        }
        #endregion

        private void AddEmployeeHl_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            addEditEmployeeWindow.ShowDialog();
            if (addEditEmployeeWindow.DialogResult == true)
            {
                EmployeesLb.ItemsSource = _context.Employees.ToList();
                Filter();
            }   
        }
    }
}
