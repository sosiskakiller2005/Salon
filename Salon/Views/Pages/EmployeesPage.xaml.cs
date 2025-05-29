using Salon.Model;
using Salon.Views.Windows;
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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private SityStarDbEntities _context = App.GetContext();
        public EmployeesPage()
        {
            InitializeComponent();
            EmployeesLb.ItemsSource = _context.Employees.ToList();
        }

        private void EmployeesLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow(EmployeesLb.SelectedItem as Employees);
            addEditEmployeeWindow.ShowDialog();
            if (addEditEmployeeWindow.DialogResult == true)
            {
                EmployeesLb.ItemsSource = _context.Employees.ToList();
            }
        }

    }
}
