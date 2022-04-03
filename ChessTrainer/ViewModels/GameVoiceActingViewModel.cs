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

        

        private RelayCommand addChessMove;
        public RelayCommand AddChessMove
        {
            get
            {
                return addChessMove ??
                  (addChessMove = new RelayCommand(obj =>
                  {
                      try
                      {
                          ChessParsedMoves.Add(ChessMove.MoveParser(AddedChessMove.WhiteMove));
                          ChessParsedMoves.Add(ChessMove.MoveParser(AddedChessMove.BlackMove));
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show($"Пожалуйста, запишите ход в соответствии с правилами записи ходов",
                              "Ошибка записи хода",MessageBoxButton.OK, MessageBoxImage.Error );
                          return;
                      }

                      Moves.Add(new ChessMove(AddedChessMove.NumberOfMove, AddedChessMove.WhiteMove, AddedChessMove.BlackMove));
                      AddedChessMove.WhiteMove = "";
                      AddedChessMove.BlackMove = "";
                      AddedChessMove.NumberOfMove++;
                  },
                  obj =>
                  {
                      if (AddedChessMove.WhiteMove == "" || AddedChessMove.BlackMove == "" || IsGameVoiceActing == true) return false;
                      return true;
                  }
                  ));
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
                      IsGameVoiceActing = true;
                      foreach(var move in ChessParsedMoves)
                          speechSynthesizer.Speak(move);
                      IsGameVoiceActing = false;
                  },
                  obj =>
                  {
                      if (Moves.Count <= 0 || AddedChessMove.WhiteMove != "" || AddedChessMove.BlackMove != "") return false;
                      return true;
                  }));
            }
        }

        private RelayCommand deleteMove;
        public RelayCommand DeleteMove
        {
            get
            {
                return deleteMove ??
                  (deleteMove = new RelayCommand(obj =>
                  {
                      Moves.Remove(Moves[Moves.Count - 1]);
                      AddedChessMove.NumberOfMove--;
                  },
                  obj =>
                  {
                      if (Moves.Count<=0) return false;
                      return true;
                  }
                  ));
            }
        }

        private RelayCommand clearMoves;
        public RelayCommand ClearMoves
        {
            get
            {
                return clearMoves ??
                  (clearMoves = new RelayCommand(obj =>
                  {
                      Moves.Clear();
                      AddedChessMove.NumberOfMove = 1;
                  },
                  obj =>
                  {
                      if (Moves.Count <= 0) return false;
                      return true;
                  }));
            }
        }


        private RelayCommand openGameFromFile;
        public RelayCommand OpenGameFromFile
        {
            get
            {
                return openGameFromFile ??
                 (openGameFromFile = new RelayCommand(obj =>
                 {
                     MessageBox.Show("Test1");
                 }));
            }
        }


        private RelayCommand saveGameToFile;
        public RelayCommand SaveGameToFile
        {
            get
            {
                return saveGameToFile ??
                  (saveGameToFile = new RelayCommand(obj =>
                  {
                      MessageBox.Show("Test2");
                  }));
            }
        }
        #endregion

        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer() { Rate = 1 };

        List<string> ChessParsedMoves;

        public ObservableCollection<ChessMove> Moves { get; set; }

        private ChessMove addedChessMove;
        public ChessMove AddedChessMove
        {
            get { return addedChessMove; }
            set { addedChessMove = value; OnPropertyChanged(); }
        }

        public bool IsGameVoiceActing { get; set; } = false;

        public GameVoiceActingViewModel()
        {
            AddedChessMove = new ChessMove();
            Moves = new ObservableCollection<ChessMove>();
            ChessParsedMoves = new List<string>();
        }
    }
}
