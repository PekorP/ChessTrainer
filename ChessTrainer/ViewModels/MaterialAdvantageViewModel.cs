using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ChessTrainer.ViewModels
{
    class MaterialAdvantageViewModel : BaseTrainerViewModel
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
                      if(CurrentMaterialAdvantage.Advantage == int.Parse(UserAnswer))
                      {
                          CountRightAnswers++;
                          IsRightAnswer = true;
                      }
                      else
                      {
                          IsRightAnswer = false;
                      }
                      UserAnswer = "";
                      TotalCountAnswers++;
                      if(currentChessBoardIndex != chessBoards.Count-1)
                        CurrentMaterialAdvantage = chessBoards[++currentChessBoardIndex];
                      else
                      {
                          currentChessBoardIndex = 0;
                          CurrentMaterialAdvantage = chessBoards[currentChessBoardIndex];
                      }
                  },
                  obj=>
                  {
                      return UserAnswer != "" && Timer.IsEnabled;
                  }
                  ));
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
                    CurrentMaterialAdvantage = chessBoards[++currentChessBoardIndex];
                },
                obj =>
                {
                    return !Timer.IsEnabled;
                }));
            }
        }

        #endregion

        private MaterialAdvantage currentMaterialAdvantage;
        public MaterialAdvantage CurrentMaterialAdvantage
        {
            get { return currentMaterialAdvantage; }
            set { currentMaterialAdvantage = value; OnPropertyChanged(); }
        }

        private string userAnswer;
        public string UserAnswer
        {
            get { return userAnswer; }
            set { userAnswer = value; OnPropertyChanged(); }
        }

        List<MaterialAdvantage> chessBoards = new List<MaterialAdvantage>();
        int currentChessBoardIndex;

        public User User { get; set; }

        public MaterialAdvantageViewModel(User User) : base()
        {
            using(ChessTrainerContext ctx = new ChessTrainerContext())
            {
                foreach(var item in ctx.MaterialAdvantages)
                {
                    chessBoards.Add(item);
                }
            }
            currentChessBoardIndex = 0;
            CurrentMaterialAdvantage = chessBoards[currentChessBoardIndex];
            UserAnswer = "";

            this.User = User;
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1d);
            Timer.Tick += new EventHandler(Timer_Tick);
        }

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (--TickCounter <= 0)
            {
                SaveRecord("MaterialAdvantage", User);
                base.Timer_Tick(sender, e);
            }
        }
    }
}
