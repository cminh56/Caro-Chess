using System;

namespace CaroGame.Models
{
    public enum Player { None, X, O }

    public class CaroGameLogic
    {
        public Player[,] Board { get; private set; }
        private Player _currentPlayer;
        private int _size;

        public CaroGameLogic(int size)
        {
            _size = size;
            Board = new Player[_size, _size];
            _currentPlayer = Player.X;
        }

        public bool MakeMove(int row, int col)
        {
            if (Board[row, col] == Player.None)
            {
                Board[row, col] = _currentPlayer;
                _currentPlayer = _currentPlayer == Player.X ? Player.O : Player.X;
                return true;
            }
            return false;
        }

        public Player CheckWinner()
        {
            // Kiểm tra theo hàng
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j <= _size - 5; j++)
                {
                    if (CheckLine(i, j, 0, 1)) return Board[i, j];
                }
            }

            // Kiểm tra theo cột
            for (int i = 0; i <= _size - 5; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (CheckLine(i, j, 1, 0)) return Board[i, j];
                }
            }

            // Kiểm tra đường chéo chính
            for (int i = 0; i <= _size - 5; i++)
            {
                for (int j = 0; j <= _size - 5; j++)
                {
                    if (CheckLine(i, j, 1, 1)) return Board[i, j];
                }
            }

            // Kiểm tra đường chéo phụ
            for (int i = 4; i < _size; i++)
            {
                for (int j = 0; j <= _size - 5; j++)
                {
                    if (CheckLine(i, j, -1, 1)) return Board[i, j];
                }
            }

            return Player.None;
        }

        private bool CheckLine(int row, int col, int dRow, int dCol)
        {
            Player first = Board[row, col];
            if (first == Player.None) return false;

            for (int i = 1; i < 5; i++)
            {
                if (Board[row + i * dRow, col + i * dCol] != first) return false;
            }

            return true;
        }
    }
}

