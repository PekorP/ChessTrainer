using ChessTrainer.Enums;

namespace ChessTrainer.Models
{
    public class Board
    {
        const int COUNT_CELLS_ON_BOARD = 64;
        const int COUNT_VERTICAL_AND_HORIZONTAL = 8;
        public Cell[] cells { get; set; } //Массив клеток, из которых состоит шахматная доска

        public Board()
        {
            cells = new Cell[COUNT_CELLS_ON_BOARD];
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
                    int index = j + 8 * i; //индекс для заполнения массива от 1 до 64
                    cells[index] = new Cell() //Создаем клетку с нужными данными (цвет, вертикальное и горизонтальное значение)
                    {
                        File = files[j],
                        Rank = (COUNT_VERTICAL_AND_HORIZONTAL - i),
                        Color = currentColor
                    };
                    currentColor = currentColor == CellColor.White ? CellColor.Black : CellColor.White; //меняем цвет
                }
                //в конце горизонтали меняем цвет,
                //так как след. горизонталь начинается с того же цвета, с которого заканчивается предыдущая
                currentColor = currentColor == CellColor.White ? CellColor.Black : CellColor.White; 
            }
        }
    }
}
