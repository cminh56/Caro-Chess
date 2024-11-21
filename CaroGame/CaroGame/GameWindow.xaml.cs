using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CaroGame.Models;

namespace CaroGame
{
    public partial class GameWindow : Window
    {
        private CaroGameLogic _game;
        private Button[,] _buttons;

        public GameWindow(int size)
        {
            InitializeComponent();
            InitializeGame(size);
            this.Closed += GameWindow_Closed;
        }

        private void InitializeGame(int size)
        {
            _game = new CaroGameLogic(size);
            _buttons = new Button[size, size];

            GameBoard.Children.Clear();
            GameBoard.Rows = size;
            GameBoard.Columns = size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var button = new Button
                    {
                        Tag = new Point(i, j),
                        FontSize = 20,
                        Background = Brushes.LightGray
                    };

                    button.Click += Cell_Click;
                    _buttons[i, j] = button;
                    GameBoard.Children.Add(button);
                }
            }
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var point = (Point)button.Tag;

            int row = (int)point.X;
            int col = (int)point.Y;

            if (_game.MakeMove(row, col))
            {
                button.Content = _game.Board[row, col] == Player.X ? "X" : "O";
                button.IsEnabled = false;

                var winner = _game.CheckWinner();
                if (winner != Player.None)
                {
                    MessageBox.Show($"Người chơi {winner} đã thắng!", "Kết thúc");
                    this.Close(); // Đóng cửa sổ GameWindow
                }
            }
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show(); // Hiển thị lại MainWindow
        }
    }
}
