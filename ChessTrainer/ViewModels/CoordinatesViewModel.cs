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
        public Board Board{ get; set; }

        public CoordinatesViewModel()
        {
            Board = new Board();
        }
    }
}
