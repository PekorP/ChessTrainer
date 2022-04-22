using ChessTrainer.Commands;
using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    class BlackAndWhiteViewModel : BaseTrainerViewModel
    {

        #region Команды

        private RelayCommand checkIsRightAnswer;
        public override RelayCommand CheckIsRightAnswer
        {
            get
            {
                return checkIsRightAnswer ??
                  (checkIsRightAnswer = new RelayCommand(obj =>
                  {
                      Cell newCell = new Cell() { File = RandomCell.File, Rank = RandomCell.Rank };

                      switch (obj) {
                          case "Black":
                              newCell.Color = Enums.CellColor.Black;
                              break;
                          case "White":
                              newCell.Color = Enums.CellColor.White;
                              break;
                      }
                      if (RandomCell.Equals(newCell))
                      {
                          CountRightAnswers++;
                          IsRightAnswer = true;
                      }
                      else
                          IsRightAnswer = false;
                      TotalCountAnswers++;
                      RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
                  }));
            }
        }

        #endregion

        public Board Board { get; set; }

        private Cell randomCell;
        public Cell RandomCell
        {
            get { return randomCell; }
            set { randomCell = value; OnPropertyChanged(); }
        }

        public BlackAndWhiteViewModel() : base()
        {
            Board = new Board();
            RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
        }
    }
}
