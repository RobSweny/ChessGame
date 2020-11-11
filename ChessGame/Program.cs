using ChessGameModel;
using System;

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
            currentCell.CurrentlyOccupied = true;

            // calculate all legal moves for that peice
            myBoard.MarkNextLegalMoves(currentCell, "Knight");

            // print the chess board use an X for the occupied square
            printBoard(myBoard);

            // wait for another key press
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            // get x and y coordinate from the user. return cell location
            Console.WriteLine("Enter the current row number: ");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the current column number: ");
            int currentColumn = int.Parse(Console.ReadLine());

            myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];
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
