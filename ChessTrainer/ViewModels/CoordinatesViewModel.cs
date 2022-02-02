using ChessTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    class CoordinatesViewModel : BaseViewModel
    {
        public List<int> Ranks { get; set; }
        public List<char> Files { get; set; }
        public Board Board{ get; set; }

        public CoordinatesViewModel()
        {
            Board = new Board();
            Ranks = new List<int> { 8, 7, 6, 5, 4, 3, 2, 1 };
            Files = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        }
    }
}
