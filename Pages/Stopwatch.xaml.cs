using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Time_Lord_Peshin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public float full_second = 0;
        public bool start_stopwatch = false;

        public Stopwatch()
        {
            InitializeComponent();
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            full_second++;

            float hours = (int)(full_second / 3600);
            float minutes = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 3600) - (minutes * 60);

            string s_seconds = seconds.ToString("00");
            string s_minutes = minutes.ToString("00");
            string s_hours = hours.ToString("00");

            time.Content = $"{s_hours}:{s_minutes}:{s_seconds}";
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (!start_stopwatch)
            {
                // Если таймер не запущен - запускаем
                dispatcherTimer.Start();
                start_stopwatch = true;
                start.Content = "Стоп";
            }
            else
            {
                // Если таймер запущен - останавливаем
                dispatcherTimer.Stop();
                start_stopwatch = false;
                start.Content = "Начать";
            }
        }
    }
}