using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    class MaterialAdvantageViewModel : BaseViewModel
    {

        #region Команды

        private RelayCommand checkIsRightAnswer;
        public RelayCommand CheckIsRightAnswer
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
                      return UserAnswer != "";
                  }
                  ));
            }
        }

        #endregion

        private bool? isRightAnswer;
        public bool? IsRightAnswer
        {
            get { return isRightAnswer; }
            set { isRightAnswer = value; OnPropertyChanged(); }
        }

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

        public MaterialAdvantageViewModel()
        {
            using(ChessTrainerContext ctx = new ChessTrainerContext())
            {
                foreach(var item in ctx.MaterialAdvantages)
                {
                    chessBoards.Add(item);
                }
            }
            CountRightAnswers = 0;
            TotalCountAnswers = 0;
            currentChessBoardIndex = 0;
            CurrentMaterialAdvantage = chessBoards[currentChessBoardIndex];
            UserAnswer = "";
        }
    }
}
