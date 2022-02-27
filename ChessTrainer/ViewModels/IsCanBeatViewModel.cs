﻿using ChessTrainer.Models;
using ChessTrainer.Models.Pieces;
using System;
using ChessTrainer.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessTrainer.Commands;

namespace ChessTrainer.ViewModels
{
    class IsCanBeatViewModel : BaseTrainerViewModel
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
                      switch (obj)
                      {
                          case "Yes":
                              if (CellFrom.Piece.CanBeat(CellFrom, CellTo) == true)
                              {
                                  CountRightAnswers++;
                                  IsRightAnswer = true;
                              }
                              else
                                  IsRightAnswer = false;
                              break;

                          case "No":
                              if (CellFrom.Piece.CanBeat(CellFrom, CellTo) == false)
                              {
                                  CountRightAnswers++;
                                  IsRightAnswer = true;
                              }
                              else
                                  IsRightAnswer = false;
                              break;
                      }
                      TotalCountAnswers++;
                      NewCells();
                      
                  }));
            }
        }

        #endregion

        Board board = new Board();
        List<Piece> pieces = new List<Piece> { new Knight(), new Rook(), new Queen(), new Bishop() };
        Dictionary<Pieces, Char> piecesNames = new Dictionary<Pieces, char>()
        {
            {Pieces.Rook, 'R' },
            {Pieces.Queen, 'Q' },
            {Pieces.Bishop, 'B' },
            {Pieces.Knight, 'N' }
        };

        private char pieceName;
        public char PieceName
        {
            get { return pieceName; }
            set { pieceName = value; OnPropertyChanged(); }
        }

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

        public IsCanBeatViewModel()
        {
            NewCells();
            CountRightAnswers = 0;
            TotalCountAnswers = 0;
        }

        void NewCells()
        {
            do
            {
                CellFrom = board.Cells[new Random().Next(board.Cells.Count())];
                CellTo = board.Cells[new Random().Next(board.Cells.Count())];
            } while (CellFrom == CellTo);

            CellFrom.Piece = pieces[new Random().Next(pieces.Count())];
            PieceName = piecesNames[CellFrom.Piece.PieceType];
        }
    }
}
