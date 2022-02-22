using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    public abstract class Piece : IPiece
    {
        public abstract ChessTrainer.Enums.Pieces PieceType { get; set; }
        public abstract bool CanBeat(Cell CellFrom, Cell CellTo);
    }
}
