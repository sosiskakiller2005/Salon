using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Salon.AppData
{
    internal class MessageBoxHelper
    {
        public static void Error(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Показывает сообщение об Sошибке.
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        /// <param name="title">Заголовок ошибки</param>
        public static void Error(string text, string title = "Ошибка")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Показывает сообщение для информирования.
        /// </summary>
        /// <param name="text">Информация</param>
        /// <param name="title">Заголовок информации</param>
        public static void Information(string text, string title = "Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Возвращает результат ответа пользователя при возникновении окна.
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="title">Заголовок сообщения</param>
        /// <returns>Результат ответа в формате true или false</returns>
        public static bool Question(string text, string title = "Вопрос")
        {
            return MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
        /// <summary>
        /// Показывает окно для предупреждения пользователя.
        /// </summary>
        /// <param name="text">Текст предупреждения</param>
        /// <param name="title">Заголовок предупреждения</param>
        public static void Warning(string text, string title = "Предупреждение")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
