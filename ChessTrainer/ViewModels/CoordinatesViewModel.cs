using ChessTrainer.Commands;
using ChessTrainer.Enums;
using ChessTrainer.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    class CoordinatesViewModel : BaseViewModel
    {

        #region Команды

        #region Команда изменения цвета доски

        private RelayCommand changeColorCommand;
        public RelayCommand ChangeColorCommand
        {
            get {
                return changeColorCommand ??
                  (changeColorCommand = new RelayCommand(obj =>
                  {
                      Ranks = new ObservableCollection<int>(Ranks.Reverse<int>());
                      Files = new ObservableCollection<char>(Files.Reverse<char>());
                      SelectedCell = null;
                      OnPropertyChanged();
                      Board.Cells = new ObservableCollection<Cell>(Board.Cells.Reverse<Cell>());                 
                      CurrentColorBoard = CurrentColorBoard == CellColor.White ? CellColor.Black : CellColor.White;
                  }));
                    }
        }

        #endregion

        #endregion

        //отвечает за то,с какой стороны (со стороны белых или черных) мы "смотрим" на доску
        private CellColor currentColorBoard;
        public CellColor CurrentColorBoard {
            get => currentColorBoard;
            set { currentColorBoard = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> ranks;
        public ObservableCollection<int> Ranks {
            get { return ranks; }
            set { ranks = value; OnPropertyChanged(); }
        }

        private ObservableCollection<char> files { get; set; }
        public ObservableCollection<char> Files
        {
            get { return files; }
            set { files = value; OnPropertyChanged(); }
        }
        public Board Board{ get; set; }

        private Cell randomCell;

        public Cell RandomCell
        {
            get { return randomCell; }
            set { randomCell = value; OnPropertyChanged(); }
        }

        private Cell selectedCell;

        public Cell SelectedCell
        {
            get { return selectedCell; }
            set {
                selectedCell = value;
                OnPropertyChanged();
                if(selectedCell != null) {
                    if (selectedCell.Equals(RandomCell))
                        IsRightSelection = true;
                    else
                        IsRightSelection = false;
                }          
                selectedCell = null;
                RandomCell = Board.Cells[new Random().Next(64)];
            }
        }

        private bool isRightSelection;
        public bool IsRightSelection
        {
            get { return isRightSelection; }
            set { isRightSelection = value; OnPropertyChanged(); }
        }

    public CoordinatesViewModel()
        {
            Board = new Board();
            Ranks = new ObservableCollection<int> { 8, 7, 6, 5, 4, 3, 2, 1 };
            Files = new ObservableCollection<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            CurrentColorBoard = CellColor.White; //Изначально мы "смотрим" на доску со стороны белых
            RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
            IsRightSelection = false;
        }
    }
}
