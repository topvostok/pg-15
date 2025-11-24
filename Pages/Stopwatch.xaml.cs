using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Time_Lord_Peshin.Pages
{
    public partial class Stopwatch : Page
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int fullSeconds = 0;
        private bool isRunning = false;

        public Stopwatch()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            UpdateDisplay();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            fullSeconds++;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            int hours = fullSeconds / 3600;
            int minutes = (fullSeconds % 3600) / 60;
            int seconds = fullSeconds % 60;

            time.Content = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (!isRunning)
            {
                // Запускаем таймер
                dispatcherTimer.Start();
                isRunning = true;
                start.Content = "Стоп";
                start.Background = new SolidColorBrush(Colors.LightCoral);
            }
            else
            {
                // Останавливаем таймер
                dispatcherTimer.Stop();
                isRunning = false;
                start.Content = "Начать";
                start.Background = new SolidColorBrush(Colors.White);
            }
        }
        private void ResetStopwatch(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            fullSeconds = 0;
            isRunning = false;
            start.Content = "Начать";
            start.Background = new SolidColorBrush(Colors.White);
            UpdateDisplay();
        }
    }
}