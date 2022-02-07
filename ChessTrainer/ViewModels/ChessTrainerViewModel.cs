using ChessTrainer.Commands;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    internal class ChessTrainerViewModel : BaseViewModel
    {

        #region Команды

        #region Команда закрытия приложения

        private RelayCommand closeApplication;
        public RelayCommand CloseApplication
        {
            get { return closeApplication ?? (closeApplication = new RelayCommand(obj =>
                 {
                     Application.Current.MainWindow.Close();
                 }));
            }
        }

        #endregion

        #region Команда сворачивания приложения

        private RelayCommand minimizeAppllicatiom;
        public RelayCommand MinimizeAppllicatiom
        {
            get
            {
                return minimizeAppllicatiom ?? (minimizeAppllicatiom = new RelayCommand(obj =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                }));
            }
        }

        #endregion
        #endregion
        public ChessTrainerViewModel()
        {
        }
    }
}
