using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    class GameVoiceActingViewModel : BaseViewModel
    {

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
            Moves.Add(new ChessMove(1, "Pe2-e4", "Pe7-e5"));
            Moves.Add(new ChessMove(2, "Ng1-f3", "Nb8-c6"));
            Moves.Add(new ChessMove(3, "Bf1-c4", "Ng8-f6"));
            Moves.Add(new ChessMove(4, "Bf1-c4", "Ng8-f6"));
            Moves.Add(new ChessMove(5, "Bf1-c4", "Ng8-f6"));
            Moves.Add(new ChessMove(6, "Bf1-c4", "Ng8-f6"));
            Moves.Add(new ChessMove(7, "Bf1-c4", "Ng8-f6"));   
        }
    }
}
