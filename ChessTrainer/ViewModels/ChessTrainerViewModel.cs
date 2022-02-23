using ChessTrainer.Commands;
using System.Collections.Generic;
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

        #region

        private RelayCommand changePage;
        public RelayCommand ChangePage
        {
            get
            {
                return changePage ??
                  (changePage = new RelayCommand(obj =>
                  {         
                      CurrentContentVM = ViewModels[obj.ToString().Split('.')[2]];
                  }));
            }
        }

        #endregion
        #endregion

        Dictionary<string, object> ViewModels = new Dictionary<string, object>()
        {
            {"CoordinatesViewModel", new CoordinatesViewModel()},
            {"BlackAndWhiteViewModel", new BlackAndWhiteViewModel()},
            {"GameVoiceActingViewModel", new GameVoiceActingViewModel()},
            {"IsCanBeatViewModel", new IsCanBeatViewModel()},
            {"MaterialAdvantageViewModel", new MaterialAdvantageViewModel()},
        };

        object currentContentVM;
        public object CurrentContentVM
        {
            get => currentContentVM;
            set
            {
                currentContentVM = value;
                OnPropertyChanged();
            }
        }

        public ChessTrainerViewModel()
        {
        }
    }
}
