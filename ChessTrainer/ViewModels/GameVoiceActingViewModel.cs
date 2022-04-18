using ChessTrainer.Commands;
using ChessTrainer.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        #endregion


        private RelayCommand openGameFromFile;
        public RelayCommand OpenGameFromFile
        {
            get
            {
                return openGameFromFile ??
                  (openGameFromFile = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.DefaultExt = ".txt";
                      openFileDialog.Filter = "Text documents (.txt)|*.txt";
                      if (openFileDialog.ShowDialog() == true)
                      {
                          using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                          {
                              while(!reader.EndOfStream)
                              {
                                  var splitMove = reader.ReadLine().Split(' ');
                                  Moves.Add(new ChessMove { NumberOfMove = int.Parse(splitMove[0]), WhiteMove = splitMove[1], BlackMove = splitMove[2] });
                              }
                          }
                      }
                  }, obj =>
                  {
                      if (Moves.Count > 0) return false;
                      return true;
                  }
                  ));
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
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = ".txt";
                    saveFileDialog.Filter = "Text documents (.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == true)
                        {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName)) 
                        {
                            foreach (var move in Moves)
                            {
                                writer.WriteLine($"{move.NumberOfMove} {move.WhiteMove} {move.BlackMove}");
                            }
                        }
                          MessageBox.Show($"Партия успешно сохранена по пути {saveFileDialog.FileName}",
                              "Успех!",MessageBoxButton.OK, MessageBoxImage.Information);
                      }     
                  }, obj =>
                  {
                      if (Moves.Count <= 0) return false;
                      return true;
                  }
                  ));
            }
        }

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
