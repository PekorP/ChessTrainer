using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChessTrainer.ViewModels
{
    public class BaseTrainerViewModel : BaseViewModel
    {
        
        private RelayCommand checkIsRightAnswer;
        public virtual RelayCommand CheckIsRightAnswer { get => checkIsRightAnswer; }

        private RelayCommand startTimer;
        public virtual RelayCommand StartTimer { get => startTimer; }
 
        private int countRightAnswers;
        public int CountRightAnswers
        {
            get { return countRightAnswers; }
            set { countRightAnswers = value; OnPropertyChanged(); }
        }

        private int totalCountAnswers;
        public int TotalCountAnswers
        {
            get { return totalCountAnswers; }
            set { totalCountAnswers = value; OnPropertyChanged(); }
        }

        private bool? isRightAnswer;
        public bool? IsRightAnswer
        {
            get { return isRightAnswer; }
            set { isRightAnswer = value; OnPropertyChanged(); }
        }

        private DispatcherTimer timer;
        protected DispatcherTimer Timer { 
            get => timer;
            set
            { 
                timer = value;
                OnPropertyChanged();
            }
        }

        private int tickCounter;
        public int TickCounter
        {
            get { return tickCounter; }
            set { tickCounter = value; OnPropertyChanged(); }
        }

        protected virtual void Timer_Tick(object sender, EventArgs e)
        {

            if (TickCounter <= 0)
            {
                Timer.Stop();
                SetupTrainer();
            }
        }
        public BaseTrainerViewModel()
        {
            SetupTrainer();
        }

        protected void SetupTrainer()
        {
            IsRightAnswer = null;
            TickCounter = 30;
            TotalCountAnswers = 0;
            CountRightAnswers = 0;
            CommandManager.InvalidateRequerySuggested();
        }

        protected void SaveRecord(string trainerName, User User)
        {
            using (ChessTrainerContext chessTrainerContext = new ChessTrainerContext())
            {
                var trainer = chessTrainerContext.Trainers.Where(t => t.TrainerName == trainerName).First();
                var record = chessTrainerContext.Records.Where(r => r.IdTrainer == trainer.ID && r.IdUser == User.ID).FirstOrDefault();
                if (record != null)
                {
                    if (record.Result < CountRightAnswers)
                    {
                        record.Result = CountRightAnswers;
                        chessTrainerContext.Entry(record).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                else
                {
                    chessTrainerContext.Records.Add(new Record() { IdTrainer = trainer.ID, IdUser = User.ID, Result = CountRightAnswers });
                }
                chessTrainerContext.SaveChanges();

            }
        }
    }
}
