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

       
    }
}

