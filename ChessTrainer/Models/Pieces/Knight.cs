using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Knight : IPiece
    {
        public bool CanBeat(Cell CellFrom, Cell CellTo)
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
