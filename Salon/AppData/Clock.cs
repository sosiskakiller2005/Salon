using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Salon.AppData
{
    /// <summary>
    /// Класс для отображения текущего времени
    /// </summary>
    internal class Clock
    {
        private static DispatcherTimer timer;
        private static string currentTime;

        public static string CurrentTime
        {
            get { return currentTime; }
            private set { currentTime = value; }
        }

        static Clock()
        {
            StartClock();
        }

        public static void StartClock()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
