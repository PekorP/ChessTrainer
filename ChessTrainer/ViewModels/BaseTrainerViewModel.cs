using ChessTrainer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTrainer.ViewModels
{
    public abstract class BaseTrainerViewModel : BaseViewModel
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
    }
}
