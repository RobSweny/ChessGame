using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChessGameModel
{
    public class Board
    {
        // the Size of the board
        public int Size { get; set; }

        // 2D array of the type cell
        public Cell[,] theGrid { get; set; }

        public Board (int s)
        {   
            // initial size of the board is defined by s
            Size = s;

            // create a new 2D array of type cell
            theGrid = new Cell[Size, Size];

            // fill the 2d array with new Cells, each with a unique X and Y property (Row and Column)
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves ( Cell currentCell, string chessPeice)
        {
            // clear all previous moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {   
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            // find all legal moves and mark the cells
            switch (chessPeice)
            {
                case "Knight":
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "King":
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
    }
}
