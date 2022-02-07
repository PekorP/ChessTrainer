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
    public class Cell : INotifyPropertyChanged
    {
        private CellColor color;

        public CellColor Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private int rank;

        public int Rank //1-8 (Горизонтали)
        {
            get { return rank; }
            set { rank = value; OnPropertyChanged(); }
        }

        private char file;

        public char File //a-h (Вертикали)
        {
            get { return file; }
            set { file = value; OnPropertyChanged(); }
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   Color == cell.Color &&
                   Rank == cell.Rank &&
                   File == cell.File;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
