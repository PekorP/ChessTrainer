using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Queen : IPiece
    {
        public bool CanBeat(Cell CellFrom, Cell CellTo)
        {
            return (new Rook().CanBeat(CellFrom, CellTo) || new Bishop().CanBeat(CellFrom, CellTo));
        }
    }
}
