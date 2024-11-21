using CaroGame.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

            // Clear any existing controls
            GameBoard.Children.Clear();

            // Xử lý layout tự động cho bàn cờ
            GameBoard.RowDefinitions.Clear();
            GameBoard.ColumnDefinitions.Clear();

            for (int i = 0; i < size; i++)
            {
                // Tạo dòng và cột cho bảng cờ
                GameBoard.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var button = new Button
                    {
                        Tag = new Point(i, j),
                        FontSize = 20,
                        Background = Brushes.LightGray,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };

                    button.Click += Cell_Click;
                    _buttons[i, j] = button;

                    // Đặt button vào grid
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
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
                    Close();
                }
            }
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
