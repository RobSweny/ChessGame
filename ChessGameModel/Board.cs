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
                    try { theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true; } catch (Exception) { }
                    break;

                case "King":
                    try { theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 1].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                    try { theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                    break;

                case "Rook":
                    for (int i = 0; i <= 8; i++)
                    {
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - 0, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - 0, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                    }
                    break;

                case "Bishop":
                    for (int i = 0; i <= 8; i++)
                    {
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                    }
                    break;

                case "Queen":
                    for (int i = 0; i <= 8; i++)
                    {
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - 0].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - 0, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - 0, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true; } catch (Exception) { }
                        try { theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true; } catch (Exception) { }
                    }
                    break;

                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
    }
}
