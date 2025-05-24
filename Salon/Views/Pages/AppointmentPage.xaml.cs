using Salon.AppData;
using Salon.Model;
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

namespace Salon.Views.Pages
{
    /// <summary>  
    /// Логика взаимодействия для AppointmentPage.xaml  
    /// </summary>  
    public partial class AppointmentPage : Page
    {
        private SityStarDbEntities _context = App.GetContext();
        private DateTime _appointmentDateTime;

        public AppointmentPage()
        {
            InitializeComponent();

            #region заполнение комбобоксов  
            ServiceCmb.ItemsSource = _context.Services.ToList();
            ServiceCmb.SelectedIndex = 0;
            ServiceCmb.DisplayMemberPath = "Name";

            MasterCmb.ItemsSource = _context.Employees.ToList();
            MasterCmb.SelectedIndex = 0;
            MasterCmb.DisplayMemberPath = "Fullname";
            #endregion
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentDp.SelectedDate != null && AppointmentTp.Time != null)
            {
                DateTime AppointmentDateTime = new DateTime(AppointmentDp.SelectedDate.Value.Year, AppointmentDp.SelectedDate.Value.Month,
                    AppointmentDp.SelectedDate.Value.Day, AppointmentTp.Time.Hour, AppointmentTp.Time.Minute, 0);
                _appointmentDateTime = AppointmentDateTime;

                Services selectedService = ServiceCmb.SelectedItem as Services;
                Employees selectedEmployee = MasterCmb.SelectedItem as Employees;
                if (CheckDate(selectedEmployee))
                {
                    FrameHelper.selectedFrame.Navigate(new ClientInfoPage(selectedService, selectedEmployee, AppointmentDateTime));
                }
            }
            else
            {
                MessageBoxHelper.Error("Заполните все поля для ввода.");
            }
        }

        private bool CheckDate(Employees selectedMaster)
        {
            List<Appointment> appointments = _context.Appointment.ToList();
            if (appointments.Any(a => a.Employees.Id == selectedMaster.Id &&
                a.DateTime >= _appointmentDateTime.AddHours(-1) &&
                a.DateTime < _appointmentDateTime.AddHours(1)))
            {
                MessageBoxHelper.Error("На данное время или в течение часа уже существует запись. Выберите другое время.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
