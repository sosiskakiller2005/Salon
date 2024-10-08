using Salon.AppData;
using Salon.Model;
using Salon.Views.Windows;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Salon.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientInfoPage.xaml
    /// </summary>
    public partial class ClientInfoPage : Page
    {
        DateTime _appointmentDateTime;
        Services _selectedService;
        Employees _selectedEmployee;
        private SityStarDbEntities _context = App.GetContext();
        public ClientInfoPage(Services selectedService, Employees selectedMaster, DateTime AppointmentDateTime)
        {
            InitializeComponent();

            _selectedService = selectedService;
            _selectedEmployee = selectedMaster;
            _appointmentDateTime = AppointmentDateTime;
        }


        private void PhoneNumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void SelectClientHl_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.ShowDialog();
            if (clientListWindow.DialogResult == true)
            {
                Appointment newAppointment = new Appointment()
                {
                    DateTime = _appointmentDateTime,
                    Services = _selectedService,
                    Client = Transporter.selectedClient,
                    Employees = _selectedEmployee
                };
                _context.Appointment.Add(newAppointment);
                _context.SaveChanges();
                MessageBoxHelper.Information("Запись добавлена.");
                FrameHelper.selectedFrame.Navigate(new HomePage());
            }
            else
            {
                SelectTbl.Text = "Выбрать существующего";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastnameTb.Text) || string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(SurnameTb.Text)
                || string.IsNullOrEmpty(PhoneNumberTb.Text) || string.IsNullOrEmpty(EmailTb.Text) || BirthdayDp.SelectedDate == null)
            {
                MessageBoxHelper.Error("Заполните все поля для ввода");
            }
            else
            {
                if (PhoneTbHelper.CheckNumber(PhoneNumberTb.Text))
                {
                    Client newClient = new Client()
                    {
                        Lastname = LastnameTb.Text,
                        Name = NameTb.Text,
                        Surname = SurnameTb.Text,
                        Phone = PhoneNumberTb.Text,
                        Email = EmailTb.Text,
                        DateOfBirth = (DateTime)BirthdayDp.SelectedDate,
                        DateOfRegistration = DateTime.Now
                    };
                    _context.Client.Add(newClient);
                    Appointment newAppointment = new Appointment()
                    {
                        DateTime = _appointmentDateTime,
                        Services = _selectedService,
                        Client = _context.Client.ToList().Last(),
                        Employees = _selectedEmployee
                    };
                    _context.Appointment.Add(newAppointment);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Новый клиент и записб добавлены.");
                    FrameHelper.selectedFrame.Navigate(new HomePage());
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.GoBack();
        }
    }
}
