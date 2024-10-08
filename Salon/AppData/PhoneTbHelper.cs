using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.AppData
{
    internal class PhoneTbHelper
    {
        public static bool CheckNumber(string number)
        {
            if (number.Count() < 11)
            {
                MessageBoxHelper.Error("Номер должен содержать 11 цифр.");
                return false;
            }
            else
            {
                if (number[0] != '8')
                {
                    MessageBoxHelper.Error("Номер должен начинаться с 8.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
