using ChessTrainer.Commands;
using System.Collections.Generic;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    internal class ChessTrainerViewModel : BaseViewModel
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

        public ChessTrainerViewModel()
        {
            CurrentContentVM = new RulesViewModel();
        }
    }
}
