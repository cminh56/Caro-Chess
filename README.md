Overview
This is a simple Cờ Caro (Gomoku or Tic-Tac-Toe) game built using WPF (.NET). The application allows players to dynamically generate a board of their desired size and play the game on a separate window. The board layout automatically adjusts to fit the game window size, providing a responsive user interface.
________________________________________
Features
1.	Dynamic Board Creation:
o	Players can input the size of the board (e.g., 5 for a 5x5 board) before starting the game.
2.	Responsive Layout:
o	The game board automatically resizes to fill the window.
3.	Winning Detection:
o	The game checks for a winner after every move.
o	Alerts the winner and ends the game.
4.	Seamless Navigation:
o	Returns to the main menu when the game window is closed or a winner is determined.
________________________________________
How to Play
1.	Run the application.
2.	Enter the desired board size in the main window.
3.	Click the Start Game button to begin.
4.	A new game window opens with the board.
5.	Players take turns clicking the cells:
o	Player 1 (X) and Player 2 (O).
6.	The game detects a win when a player aligns their symbols in a row, column, or diagonal.
7.	The game announces the winner or ends in a draw.
8.	On game over or closing the game window, you are returned to the main window.
________________________________________
How to Build and Run
1.	Clone or download this repository.
2.	Open the solution file (CaroGame.sln) in Visual Studio.
3.	Build the solution using Ctrl+Shift+B.
4.	Run the application using F5.
________________________________________
Code Structure
•	MainWindow.xaml:
o	UI for entering the board size and starting the game.
•	GameWindow.xaml:
o	UI for the game board.
o	Dynamically creates the board based on the specified size.
•	CaroGameLogic.cs:
o	Handles game logic, including move validation and winner detection.
________________________________________
Requirements
•	.NET Framework: 6.0 or higher.
•	IDE: Visual Studio 2022 or newer.

