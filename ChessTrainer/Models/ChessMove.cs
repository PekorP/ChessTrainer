using ChessTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessTrainer.Models
{
    public class ChessMove : BaseViewModel
    {
        private int numberOfMove;
        public int NumberOfMove
        {
            get { return numberOfMove; }
            set { numberOfMove = value; OnPropertyChanged(); }
        }

        private string whiteMove;
        public string WhiteMove
        {
            get { return whiteMove; }
            set { whiteMove = value; OnPropertyChanged(); }
        }

        private string blackMove;
        public string BlackMove
        {
            get { return blackMove; }
            set { blackMove = value; OnPropertyChanged(); }
        }

        private static readonly Dictionary<char, string> figures = new Dictionary<char, string>()
        {
            { 'P', "Пешка"},
            { 'R', "Ладья"},
            { 'N', "Конь"},
            { 'B', "Слон"},
            { 'Q', "Ферзь"},
            { 'K', "Король"}
        };

        public ChessMove()
        {
            NumberOfMove = 1;
            WhiteMove = BlackMove = "";
        }

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

            try
            {
                Regex regex = new Regex(@"(?i)^[prnbqk][a-h][1-8]-[a-h][1-8][prnbqk]?$");
                if (regex.Matches(move).Count == 0)
                    throw new Exception();
            }
            catch(Exception e)
            {
                return null;
            }
            var startCell = move[1].ToString() + move[2];
            var endCell = move[4].ToString() + move[5];
            var parsedMove = $"{figures[Char.ToUpper(move[0])]} {startCell} на {endCell}";

            if ((move.Length == 7) && (figures[Char.ToUpper(move[0])] == figures['P']))
                parsedMove += $" и превращается в {figures[Char.ToUpper(move[6])]}";

            return parsedMove;
        }
    }
}
