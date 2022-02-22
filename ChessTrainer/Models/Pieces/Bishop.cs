using ChessTrainer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Bishop : Piece
    {
        public override Enums.Pieces PieceType { get; set; } = Enums.Pieces.Bishop;

        public override bool CanBeat(Cell CellFrom, Cell CellTo)
        {
            for (int i = 1; i <= 8; i++) //Для движения влево вниз
            {
                if ((CellFrom.File - i == CellTo.File) && (CellFrom.Rank - i == CellTo.Rank)) return true;
            }

            for (int i = 1; i <= 8; i++) //Для движения влево вверх
            {
                if ((CellFrom.File - i == CellTo.File) && (CellFrom.Rank + i == CellTo.Rank)) return true;
            }

            for (int i = 1; i <= 8; i++) //Для движения вправо вниз
            {
                if ((CellFrom.File + i == CellTo.File) && (CellFrom.Rank - i == CellTo.Rank)) return true;
            }

            for (int i = 1; i <= 8; i++) //Для движения вправо вверх
            {
                if ((CellFrom.File + i == CellTo.File) && (CellFrom.Rank + i == CellTo.Rank)) return true;
            }

            return false;
        }
    }
}
