using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System.Collections.Generic;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    internal class ChessTrainerViewModel : BaseViewModel
    {
        public User User { get; set; }

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
            {"RulesViewModel", new RulesViewModel()}
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

        public ChessTrainerViewModel(User user)
        {
            CurrentContentVM = new RulesViewModel();
            this.User = user;           
        }
    }
}
