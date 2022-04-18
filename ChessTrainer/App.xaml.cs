using ChessTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTrainer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow Window { get; set; }
        public MainWindowViewModel MainViewModel { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainViewModel = new MainWindowViewModel();
            Window = new MainWindow { DataContext = MainViewModel };
            Window.Show();
        }
    }
}
