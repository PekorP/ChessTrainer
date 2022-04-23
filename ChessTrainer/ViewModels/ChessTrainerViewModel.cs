using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    public class ChessTrainerViewModel : BaseViewModel
    {

        #region Команды

        #region Команда смены страницы

        private RelayCommand changePage;
        public RelayCommand ChangePage
        {
            get
            {
                return changePage ??
                  (changePage = new RelayCommand(obj =>
                  {
                      var viewModelName = obj.ToString().Split('.')[2];
                      CurrentContentVM = ViewModels[viewModelName];
                      OnChangeTrainer.Invoke(this, new VMEventArgs(viewModelName.Substring(0, viewModelName.Length - 9), User));
                  }));
            }
        }

        #endregion
        #endregion

        public User User { get; set; }

        Dictionary<string, object> ViewModels;

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

        public event EventHandler<VMEventArgs> OnChangeTrainer;
        

        public ChessTrainerViewModel(User user)
        {
            User = user;
            ViewModels = new Dictionary<string, object>()
            {
                {"CoordinatesViewModel", new CoordinatesViewModel(User) },
                {"BlackAndWhiteViewModel", new BlackAndWhiteViewModel()},
                {"GameVoiceActingViewModel", new GameVoiceActingViewModel()},
                {"IsCanBeatViewModel", new IsCanBeatViewModel()},
                {"MaterialAdvantageViewModel", new MaterialAdvantageViewModel()},
                {"RulesViewModel", new RulesViewModel()}
            };
            CurrentContentVM = new RulesViewModel();
        }
    }

    public class VMEventArgs : EventArgs
    {
        public string Trainer{ get; }
        public User User { get; }
        public VMEventArgs(string trainer, User user)
        {
            Trainer = trainer;
            User = user;
        }
    }
}
