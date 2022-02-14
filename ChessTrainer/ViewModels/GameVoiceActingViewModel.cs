using ChessTrainer.Commands;
using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
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

        private RelayCommand gameVoiceActing;
        public RelayCommand GameVoiceActing
        {
            get
            {
                return gameVoiceActing ??
                  (gameVoiceActing = new RelayCommand(obj =>
                  {
                      foreach(var move in Moves)
                      {
                          speechSynthesizer.Speak(ChessMove.MoveParser(move.WhiteMove));
                          speechSynthesizer.Speak(ChessMove.MoveParser(move.BlackMove));
                      }
                  }));
            }
        }

        #endregion

        #endregion

        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer() { Rate = 1 };

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
