﻿using ChessTrainer.Commands;
using ChessTrainer.Enums;
using ChessTrainer.Models;
using ChessTrainer.Models.EF;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace ChessTrainer.ViewModels
{
    public class CoordinatesViewModel : BaseTrainerViewModel
    {

        #region Команды

        #region Старт таймера

        public RelayCommand startTimer;
        public override RelayCommand StartTimer
        {
            get
            {
                return startTimer ?? (startTimer = new RelayCommand(obj =>
                {
                    Timer.Start();
                    RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
                },
                obj=>
                {
                    return !Timer.IsEnabled;
                }));
            }
        }

        #endregion

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
                      IsRightAnswer = null;
                      Board.Cells = new ObservableCollection<Cell>(Board.Cells.Reverse<Cell>());
                      CurrentColorBoard = CurrentColorBoard == CellColor.White ? CellColor.Black : CellColor.White;
                  }));
                    }
        }

        #endregion

        #region Команда проверки ответа

        private RelayCommand checkIsRightAnswer;
        public override RelayCommand CheckIsRightAnswer
        {
            get
            {
                return checkIsRightAnswer ??
                  (checkIsRightAnswer = new RelayCommand(obj =>
                  {
                      SelectedCell = obj as Cell;
                      Cell newRandCell;
                      if (SelectedCell.Equals(RandomCell))
                      {
                          IsRightAnswer = true;
                          CountRightAnswers++; OnPropertyChanged();
                      }
                      else
                          IsRightAnswer = false;
                      do
                      {
                          newRandCell = RandomCell;
                          RandomCell = Board.Cells[new Random().Next(64)];
                      } while (newRandCell.Equals(randomCell));
                      TotalCountAnswers++;
                  },
                  obj=>
                  {
                      return Timer.IsEnabled;
                  }
                  ));
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
            set
            {
                selectedCell = value;
                OnPropertyChanged();
            }
        }
        public User User { get; set; }
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (--TickCounter <= 0)
            {
                RandomCell = null;
                SaveRecord("Coordinates", User);
                base.Timer_Tick(sender, e);
            }
        }

        public CoordinatesViewModel(User User) : base()
        {            
            Board = new Board();
            Ranks = new ObservableCollection<int> { 8, 7, 6, 5, 4, 3, 2, 1 };
            Files = new ObservableCollection<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            CurrentColorBoard = CellColor.White; //Изначально мы "смотрим" на доску со стороны белых
            this.User = User;

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1d);
            Timer.Tick += new EventHandler(Timer_Tick);
        }
    }
}
