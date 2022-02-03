using ChessTrainer.Commands;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    internal class ChessTrainerViewModel : BaseViewModel
    {
        private RelayCommand closeApplication;
        public RelayCommand CloseApplication
        {
            get {return closeApplication ?? (closeApplication = new RelayCommand(obj =>
                {
                    Application.Current.MainWindow.Close();
                }));
                }
        }
        public ChessTrainerViewModel()
        {
        }
    }
}
