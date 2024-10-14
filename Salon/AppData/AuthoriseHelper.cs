using Salon.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.AppData
{
    internal class AuthoriseHelper
    {
        private static SityStarDbEntities _context = App.GetContext();
        public static Employees selectedUser;
        /// <summary>
        /// Авторизует пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public static bool Authorise(string login, string password)
        {
            List<Employees> users = _context.Employees.ToList();

            if (login == string.Empty || password == string.Empty)
            {
                MessageBoxHelper.Error("Не все поля для ввода были заполнены.");
                return false;
            }
            else
            {
                foreach (Employees user in users)
                {
                    if (user.Login == login && user.Password == password)
                    {
                        selectedUser = user;
                        return true;
                    }
                }
                if (selectedUser != null)
                {
                    return true;
                }
                else
                {
                    MessageBoxHelper.Error("Неправильно введен логин или пароль.");
                    return false;
                }
            }
        }
    }
}
