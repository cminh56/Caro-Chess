using System.Windows;

namespace CaroGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(BoardSizeInput.Text, out int size) && size >= 5)
            {
                // Đóng MainWindow trước khi mở GameWindow
                this.Hide();

                // Mở cửa sổ GameWindow
                var gameWindow = new GameWindow(size);
                gameWindow.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lớn hơn hoặc bằng 5!", "Lỗi nhập liệu");
            }
        }
    }
}
