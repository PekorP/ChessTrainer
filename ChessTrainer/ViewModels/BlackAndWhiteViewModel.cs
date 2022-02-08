using ChessTrainer.Commands;
using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    class BlackAndWhiteViewModel : BaseViewModel
    {

        #region Команды

        #region Команда изменения цвета доски

        private RelayCommand checkIsRightAnswer;
        public RelayCommand CheckIsRightAnswer
        {
            get
            {
                return checkIsRightAnswer ??
                  (checkIsRightAnswer = new RelayCommand(obj =>
                  {
                      switch (obj) {
                          case "Black":
                              Cell newCellBlack = new Cell() { Color = Enums.CellColor.Black, File = RandomCell.File, Rank = RandomCell.Rank };
                              if (RandomCell.Equals(newCellBlack)) { CountRightAnswers++; IsRightAnswer = true; } else IsRightAnswer = false;
                              break;
                          case "White":
                              Cell newCellWhite = new Cell() { Color = Enums.CellColor.White, File = RandomCell.File, Rank = RandomCell.Rank };
                              if (RandomCell.Equals(newCellWhite)) { CountRightAnswers++; IsRightAnswer = true; } else IsRightAnswer = false;
                              break;
                      }
                      TotalCountAnswers++;
                      RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
                  }));
            }
        }

        #endregion

        #endregion

        public Board Board { get; set; }

        private Cell randomCell;
        public Cell RandomCell
        {
            get { return randomCell; }
            set { randomCell = value; OnPropertyChanged(); }
        }

        private int countRightAnswers;
        public int CountRightAnswers
        {
            get { return countRightAnswers; }
            set { countRightAnswers = value; OnPropertyChanged(); }
        }

        private int totalCountAnswers;
        public int TotalCountAnswers
        {
            get { return totalCountAnswers; }
            set { totalCountAnswers = value; OnPropertyChanged(); }
        }

        private bool? isRightAnswer;

        public bool? IsRightAnswer
        {
            get { return isRightAnswer; }
            set { isRightAnswer = value; OnPropertyChanged(); }
        }


        public BlackAndWhiteViewModel()
        {
            Board = new Board();
            RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
            CountRightAnswers = 0;
            TotalCountAnswers = 0;
            IsRightAnswer = null;
        }
    }
}
