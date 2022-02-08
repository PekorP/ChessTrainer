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

        public BlackAndWhiteViewModel()
        {
            Board = new Board();
            RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
            CountRightAnswers = 0;
            TotalCountAnswers = 0;
        }
    }
}
