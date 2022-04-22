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
                      return UserAnswer != "";
                  }
                  ));
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

        public MaterialAdvantageViewModel() : base()
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
        }
    }
}
