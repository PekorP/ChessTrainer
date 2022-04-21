using ChessTrainer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ChessTrainer.ViewModels
{
    public class BaseTrainerViewModel : BaseViewModel
    {
        
        private RelayCommand checkIsRightAnswer;
        public virtual RelayCommand CheckIsRightAnswer { get => checkIsRightAnswer; }

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

        protected DispatcherTimer _timer;

        private int tickCounter = 30;
        public int TickCounter
        {
            get { return tickCounter; }
            set { tickCounter = value; OnPropertyChanged(); }
        }

        public BaseTrainerViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1d);
            _timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (--TickCounter <= 0)
            {
                var timer = (DispatcherTimer)sender;
                TickCounter = 30;
                timer.Stop();
            }
        }
    }
}
