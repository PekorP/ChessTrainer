using ChessTrainer.Commands;
using ChessTrainer.Models;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChessTrainer.ViewModels
{
    class BlackAndWhiteViewModel : BaseTrainerViewModel
    {

        #region Команды

        private RelayCommand checkIsRightAnswer;
        public override RelayCommand CheckIsRightAnswer
        {
            get
            {
                return checkIsRightAnswer ??
                  (checkIsRightAnswer = new RelayCommand(obj =>
                  {
                      Cell newCell = new Cell() { File = RandomCell.File, Rank = RandomCell.Rank };

                      switch (obj) {
                          case "Black":
                              newCell.Color = Enums.CellColor.Black;
                              break;
                          case "White":
                              newCell.Color = Enums.CellColor.White;
                              break;
                      }
                      if (RandomCell.Equals(newCell))
                      {
                          CountRightAnswers++;
                          IsRightAnswer = true;
                      }
                      else
                          IsRightAnswer = false;
                      TotalCountAnswers++;
                      RandomCell = Board.Cells[new Random().Next(Board.Cells.Count())];
                  },
                  obj =>
                  {
                      return Timer.IsEnabled;
                  }));
            }
        }

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
                obj =>
                {
                    return !Timer.IsEnabled;
                }));
            }
        }

        #endregion

        public Board Board { get; set; }

        private Cell randomCell;
        public Cell RandomCell
        {
            get { return randomCell; }
            set { randomCell = value; OnPropertyChanged(); }
        }

        public User User { get; set; }

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (--TickCounter <= 0)
            {
                RandomCell = null;
                SaveRecord("BlackAndWhite", User);
                base.Timer_Tick(sender, e);
            }
        }

        public BlackAndWhiteViewModel(User User) : base()
        {
            Board = new Board();
            this.User = User;

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1d);
            Timer.Tick += new EventHandler(Timer_Tick);
        }
    }
}
