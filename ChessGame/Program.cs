using ChessGameModel;
using System;
using System.Linq;

namespace ChessGame
{
    class Program
    {
        static Board myBoard = new Board(8);
        

        static void Main(string[] args)
        {
            // show empty chess board
            printBoard(myBoard);

            // ask the user for row and column where we will place a peice
            Cell currentCell = setCurrentCell();
            String chessPiece = setChessPiece();

            currentCell.CurrentlyOccupied = true;

            // calculate all legal moves for that peice
            myBoard.MarkNextLegalMoves(currentCell, chessPiece);

            // print the chess board use an X for the occupied square
            printBoard(myBoard);

            // wait for another key press
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            int currentRow = 0;
            int currentColumn = 0;

            // get x and y coordinate from the user. return cell location and validate user input
            Console.WriteLine("Enter the current row number: ");
            while (!int.TryParse(Console.ReadLine(), out currentRow))
            {
                Console.WriteLine("That was invalid. Enter a valid column number.");
            }

            Console.WriteLine("Enter the current column number: ");
            while (!int.TryParse(Console.ReadLine(), out currentColumn))
            {
                Console.WriteLine("That was invalid. Enter a valid column number.");
            }

            myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static String setChessPiece()
        {
            string[] chessPeices = { "King", "Knight", "Rook", "Queen", "Bishop" };
            string userPieceChoice = "";

            Console.WriteLine("Chess Options - King, Knight, Rook, Queen or Bishop ");
            Console.WriteLine("Choose a chess piece: ");
            userPieceChoice = Console.ReadLine();

            // user choice within array
            while (!chessPeices.Contains(userPieceChoice))
            {
                Console.WriteLine("Invalid option, please choose again");
                Console.WriteLine("Chess Options - King, Knight, Rook, Queen or Bishop ");
                Console.WriteLine("Choose a chess piece: ");
                userPieceChoice = Console.ReadLine();
            }
            return userPieceChoice;
        }


        private static void printBoard(Board myBoard)
        {
            // print the chess board to the console. Use X for the piece location. + for legal move . for empty square
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    // current cell
                    Cell c = myBoard.theGrid[i, j];

                    // check if cell is currently occupied
                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("========");
        }
    }
}
