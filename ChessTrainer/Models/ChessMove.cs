using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models
{
    class ChessMove
    {
        public int NumberOfMove { get; set; }
        public string WhiteMove { get; set; }
        public string BlackMove { get; set; }

        private static readonly Dictionary<char, string> figures = new Dictionary<char, string>()
        {
            { 'P', "Пешка"},
            { 'R', "Ладья"},
            { 'N', "Конь"},
            { 'B', "Слон"},
            { 'Q', "Ферзь"},
            { 'K', "Король"}
        };

        public ChessMove() { }

        public ChessMove(int numberOfMove, string whiteMove, string blackMove)
        {
            NumberOfMove = numberOfMove;
            WhiteMove = whiteMove;
            BlackMove = blackMove;
        }

        //Для примера: { 1, "Pe2-e4", "Ng8-f6" } => "Пешка e2 на e4", "Конь g8 на f6"
        public static string MoveParser(string move)
        {
            if (move == "0-0") return "Короткая рокировка";
            if (move == "0-0-0") return "Длинная рокировка";

            var startCell = move[1].ToString() + move[2].ToString();
            var endCell = move[4].ToString() + move[5].ToString();
            var parsedMove = $"{figures[Char.ToUpper(move[0])]} {startCell} на {endCell}";

            if ((move.Length == 7) && (figures[Char.ToUpper(move[0])] == figures['P']))
                parsedMove += $" и превращается в {figures[move[6]]}";

            return parsedMove;
        }
    }
}
