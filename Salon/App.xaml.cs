using Salon.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SityStarDbEntities _context;
        public static SityStarDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new SityStarDbEntities();
            }
            return _context;
        }
    }
}
