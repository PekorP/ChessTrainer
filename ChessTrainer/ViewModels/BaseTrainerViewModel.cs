using ChessTrainer.Commands;
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
        public virtual RelayCommand StartTimer { get => checkIsRightAnswer; }
 
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

        private int tickCounter = 5;
        public int TickCounter
        {
            get { return tickCounter; }
            set { tickCounter = value; OnPropertyChanged(); }
        }

        public BaseTrainerViewModel()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1d);
            Timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (--TickCounter <= 0)
            {
                Timer.Stop();
                TickCounter = 30;
                TotalCountAnswers = 0;
                CountRightAnswers = 0;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
