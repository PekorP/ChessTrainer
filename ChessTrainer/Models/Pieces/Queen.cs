using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models.Pieces
{
    class Queen : Piece
    {
        public override Enums.Pieces PieceType { get; set; } = Enums.Pieces.Queen;

        public override bool CanMove(Cell CellFrom, Cell CellTo)
        {
            return (new Rook().CanMove(CellFrom, CellTo) || new Bishop().CanMove(CellFrom, CellTo));
        }
    }
}
