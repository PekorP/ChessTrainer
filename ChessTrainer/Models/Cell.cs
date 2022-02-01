using ChessTrainer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models
{
    public class Cell
    {
        public CellColor Color {get; set;}

        public int Rank { get; set; } //1-8 (Горизонтали)

        public char File{ get; set; } //a-h (Вертикали)
    }
}
