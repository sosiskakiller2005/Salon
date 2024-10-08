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
using System.Windows.Shapes;

namespace Salon.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        private SityStarDbEntities _context = App.GetContext();
        public ClientListWindow()
        {
            InitializeComponent();
            ClientsLb.ItemsSource = _context.Client.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Transporter.selectedClient = null;
            DialogResult = false;
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsLb.SelectedItem != null)
            {
                Transporter.selectedClient = ClientsLb.SelectedItem as Client;
                DialogResult = true;
            }
            else
            {
                MessageBoxHelper.Error("Выберите клиента.");
            }
        }
    }
}
