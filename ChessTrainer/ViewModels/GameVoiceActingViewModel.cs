using ChessTrainer.Commands;
using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    class GameVoiceActingViewModel : BaseViewModel
    {

        #region Команды

        #region Команда изменения цвета доски

        private RelayCommand addChessMove;
        public RelayCommand AddChessMove
        {
            get
            {
                return addChessMove ??
                  (addChessMove = new RelayCommand(obj =>
                  {
                      Moves.Add(new ChessMove(AddedChessMove.NumberOfMove, AddedChessMove.WhiteMove, AddedChessMove.BlackMove));
                      AddedChessMove.WhiteMove = "";
                      AddedChessMove.BlackMove = "";
                      AddedChessMove.NumberOfMove++;
                  }));
            }
        }

        #endregion

        #endregion

        public ObservableCollection<ChessMove> Moves { get; set; }

        private ChessMove addedChessMove;
        public ChessMove AddedChessMove
        {
            get { return addedChessMove; }
            set { addedChessMove = value; OnPropertyChanged(); }
        }

        public GameVoiceActingViewModel()
        {
            AddedChessMove = new ChessMove();
            Moves = new ObservableCollection<ChessMove>();
        }
    }
}
