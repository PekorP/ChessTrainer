using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Команда закрытия приложения

        private RelayCommand closeApplication;
        public RelayCommand CloseApplication
        {
            get
            {
                return closeApplication ?? (closeApplication = new RelayCommand(obj =>
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

        public AuthorizationViewModel authorizationViewModel { get; }

        private string user;
        public string User
        {
            get => user;
            set 
            { 
                user = value;
                OnPropertyChanged();
            }
        } 

        public MainWindowViewModel()
        {
            authorizationViewModel = new AuthorizationViewModel();
            authorizationViewModel.OnAuthorize += AuthorizationViewModelOnOnAuthorize;
            CurrentContent = authorizationViewModel;
        }

        private BaseViewModel currentContent;
        public BaseViewModel CurrentContent
        {
            get => currentContent;
            set { currentContent = value; OnPropertyChanged(); }
        }

        private void AuthorizationViewModelOnOnAuthorize(object sender, LoginEventArgs e)
        {
            CurrentContent = e.IsAuthorized ? (BaseViewModel)new ChessTrainerViewModel(e.User) : authorizationViewModel;
            User = e.IsAuthorized ? e.User.Login : null;
        }
    }
}
