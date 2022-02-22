using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    public interface IPiece
    {
        bool CanBeat(Cell CellFrom, Cell CellTo);
    }
}
