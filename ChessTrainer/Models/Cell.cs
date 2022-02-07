using ChessTrainer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.Models
{
    public class Cell
    {
        public CellColor Color { get; set; }

        public int Rank { get; set; } //1-8 (Горизонтали)

        public char File { get; set; } //a-h (Вертикали)

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   Color == cell.Color &&
                   Rank == cell.Rank &&
                   File == cell.File;
        }
    }
}
