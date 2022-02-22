using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Knight : Piece
    {
        public override Enums.Pieces PieceType { get; set; } = Enums.Pieces.Knight;

        public override bool CanBeat(Cell CellFrom, Cell CellTo)
        {
            if (((CellFrom.File + 1) == CellTo.File) && ((CellFrom.Rank + 2) == CellTo.Rank)) return true;
            if (((CellFrom.File + 2) == CellTo.File) && ((CellFrom.Rank + 1) == CellTo.Rank)) return true;

            if (((CellFrom.File + 1) == CellTo.File) && ((CellFrom.Rank - 2) == CellTo.Rank)) return true;
            if (((CellFrom.File + 2) == CellTo.File) && ((CellFrom.Rank - 1) == CellTo.Rank)) return true;

            if (((CellFrom.File - 1) == CellTo.File) && ((CellFrom.Rank + 2) == CellTo.Rank)) return true;
            if (((CellFrom.File - 2) == CellTo.File) && ((CellFrom.Rank + 1) == CellTo.Rank)) return true;

            if (((CellFrom.File - 1) == CellTo.File) && ((CellFrom.Rank - 2) == CellTo.Rank)) return true;
            if (((CellFrom.File - 2) == CellTo.File) && ((CellFrom.Rank - 1) == CellTo.Rank)) return true;

            return false;
        }
    }
}
