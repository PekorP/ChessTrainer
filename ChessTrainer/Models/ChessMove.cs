using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models
{
    class ChessMove
    {

        //Для примера: { 1, "Pa2-a4", "Ng1-f3" };
        public int NumberOfMove { get; set; }
        public string WhiteMove { get; set; }
        public string BlackMove { get; set; }

        public ChessMove(int numberOfMove, string whiteMove, string blackMove)
        {
            NumberOfMove = numberOfMove;
            WhiteMove = whiteMove;
            BlackMove = blackMove;
        }

        public string MoveParser(string move)
        {
            return "";
        }
    }
}
