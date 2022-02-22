using ChessTrainer.Models;
using ChessTrainer.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    class IsCanBeatViewModel : BaseViewModel
    {
        Board board = new Board();
        List<Piece> pieces = new List<Piece> { new Knight(), new Rook(), new Queen(), new Bishop() };

        private Cell cellFrom;
        public Cell CellFrom
        {
            get { return cellFrom; }
            set { cellFrom = value; OnPropertyChanged(); }
        }
        private Cell cellTo;
        public Cell CellTo
        {
            get { return cellTo; }
            set { cellTo = value; OnPropertyChanged(); }
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

        public IsCanBeatViewModel()
        {
            do
            {
                CellFrom = board.Cells[new Random().Next(board.Cells.Count())];
                CellTo = board.Cells[new Random().Next(board.Cells.Count())];
            } while (CellFrom == CellTo);
            CellFrom.Piece = pieces[new Random().Next(pieces.Count())];
        }

    }
}
