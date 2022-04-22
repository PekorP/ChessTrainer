using ChessTrainer.Enums;
using ChessTrainer.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessTrainer.Models
{
    public class Board : BaseViewModel
    {
        const int COUNT_VERTICAL_AND_HORIZONTAL = 8;

        private ObservableCollection<Cell> cells;
        public ObservableCollection<Cell> Cells //Массив клеток, из которых состоит шахматная доска
        {
            get { return cells; }
            set { cells = value; OnPropertyChanged(); }
        }

        public Board()
        {
            Cells = new ObservableCollection<Cell>();
            SetupBoard();
        }

        void SetupBoard() //Заполнение массива значениями, чтобы получилась шахматная доска с квадратами
        {
            char[] files = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' }; 
            CellColor currentColor = CellColor.White; //так как начинаем с левого верхнего края(А8), то клетка имеет белый цвет

            for (int i = 0; i < COUNT_VERTICAL_AND_HORIZONTAL; i++)
            {
                for (int j = 0; j < COUNT_VERTICAL_AND_HORIZONTAL; j++)
                {
                    Cells.Add(new Cell() //Создаем клетку с нужными данными (цвет, вертикальное и горизонтальное значение)
                    {
                        File = files[j],
                        Rank = (COUNT_VERTICAL_AND_HORIZONTAL - i),
                        Color = currentColor
                    });
                    currentColor = currentColor == CellColor.White ? CellColor.Black : CellColor.White; //меняем цвет
                }
                //в начале горизонтали меняем цвет,
                //так как горизонталь начинается с того же цвета, с которого заканчивается предыдущая
                currentColor = currentColor == CellColor.White ? CellColor.Black : CellColor.White; 
            }
        }
    }
}
