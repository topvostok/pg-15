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
using Time_Lord_Peshin.Pages; // Добавьте эту строку

namespace Time_Lord_Peshin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPages(pages.stopwatch);
        }

        public enum pages
        {
            stopwatch
        }


        public void OpenPages(pages _page)
        {
            if (_page == pages.stopwatch)
                freme.Navigate(new Stopwatch()); 
        }
    }
}