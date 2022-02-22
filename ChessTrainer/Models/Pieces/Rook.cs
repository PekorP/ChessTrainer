using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Rook : IPiece
    {
        public bool CanBeat(Cell CellFrom, Cell CellTo)
        {
            return ((CellFrom.Rank == CellTo.Rank) || (CellFrom.File == CellTo.File));
        }
    }
}
