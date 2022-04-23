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
        public ChessTrainerViewModel chessTrainerViewModel { get; set; }

        private string userLogin;
        public string UserLogin
        {
            get => userLogin;
            set 
            {
                userLogin = value;
                OnPropertyChanged();
            }
        }

        private int? userRecord;
        public int? UserRecord
        {
            get => userRecord;
            set
            {
                userRecord = value;
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
            chessTrainerViewModel = new ChessTrainerViewModel(e.User);
            chessTrainerViewModel.OnChangeTrainer += ChessTrainerViewModelOnChangeTrainer;

            CurrentContent = e.IsAuthorized ? (BaseViewModel)chessTrainerViewModel : authorizationViewModel;
            UserLogin = e.IsAuthorized ? e.User.Login : null;
        }

        private void ChessTrainerViewModelOnChangeTrainer(object sender, VMEventArgs e)
        {
            using (ChessTrainerContext chessTrainerContext = new ChessTrainerContext())
            {
                var trainer = chessTrainerContext.Trainers.Where(t => t.TrainerName == e.Trainer).FirstOrDefault();
                if ((trainer != null) && chessTrainerContext.Records.Where(r => r.IdTrainer == trainer.ID && r.IdUser == e.User.ID).Any())
                {
                    UserRecord = chessTrainerContext.Records.Where(r => r.IdTrainer == trainer.ID && r.IdUser == e.User.ID).First().Result;
                }
                else
                    UserRecord = null;
            }
        }
    }
}
