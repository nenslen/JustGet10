using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Just_Get_10
{
    class JustGet10Game
    {
        public struct Square
        {
            public int value;
            public int targetTop;
            public int row;
            public int col;
            public bool selected;
        };

        public int gridSize; // The size of the game board
        private int level; // Highest tile so far
        public int numSelectedTiles; // Total selected tiles on the board
        public int score; // Current score
        public Square[,] board; // The game board




        // Constructor
        public JustGet10Game(int size = 5)
        {
            gridSize = size;
            board = new Square[gridSize, gridSize];
            reset();
        }


        // Resets the game
        public void reset(List<Tile> tiles = null)
        {
            level = 5;
            score = 0;

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j].value = 0;
                }
            }

            fillTiles(tiles);
        }


        // Selects all touching tiles with the same value, returns how many tiles were selected
        public int selectTiles(int row, int col, bool initialSelection = true)
        {
            /* Checks top, right, bottom, and left tiles to see if their values match and whether or not
             * it is selected, if it is, selectTiles() is run again with that tile. This will select
             * all touching tiles with the same value
             */

            board[row, col].selected = true;
            if (initialSelection) { numSelectedTiles++; }


            // Top
            if (row > 0)
            {
                if (!board[row - 1, col].selected && board[row - 1, col].value == board[row, col].value)
                {
                    board[row - 1, col].selected = true;
                    numSelectedTiles++;
                    selectTiles(row - 1, col, false);
                }
            }


            // Right
            if (col < gridSize - 1)
            {
                if (!board[row, col + 1].selected && board[row, col + 1].value == board[row, col].value)
                {
                    board[row, col + 1].selected = true;
                    numSelectedTiles++;
                    selectTiles(row, col + 1, false);
                }
            }


            // Bottom
            if (row < gridSize - 1)
            {
                if (!board[row + 1, col].selected && board[row + 1, col].value == board[row, col].value)
                {
                    board[row + 1, col].selected = true;
                    numSelectedTiles++;
                    selectTiles(row + 1, col, false);
                }
            }


            // Left
            if (col > 0)
            {
                if (!board[row, col - 1].selected && board[row, col - 1].value == board[row, col].value)
                {
                    board[row, col - 1].selected = true;
                    numSelectedTiles++;
                    selectTiles(row, col - 1, false);
                }
            }

            return numSelectedTiles;
        }


        // Deselects all tiles
        public void deselectTiles()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j].selected = false;
                }
            }

            numSelectedTiles = 0;
        }


        // Combines selected tiles into 1 tile
        public void combineTiles(int row, int col)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (board[i, j].selected)
                    {
                        board[i, j].selected = false;

                        if (i == row && j == col)
                        {
                            if (++board[i, j].value > level) { level++; }
                        }
                        else { board[i, j].value = 0; }
                    }
                }
            }

            score += ((board[row, col].value - 1) * (board[row, col].value - 1)) * numSelectedTiles;
        }


        // Collapses tiles downwards
        public void dropTiles(List<Tile> tiles, int tileSize)
        {   
            for (int i = gridSize - 1; i >= 0; i--)
            {
                for (int j = gridSize - 1; j >= 0; j--)
                {
                    if (board[j, i].value == 0)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (board[k, i].value != 0)
                            {
                                Tile temp = new Tile(tileSize, gridSize);

                                temp.targetTop = j * tileSize;
                                temp.Top = k * tileSize;
                                temp.Left = i * tileSize;
                                temp.Text = board[k, i].value.ToString();
                                temp.row = j;
                                temp.col = i;

                                board[j, i].value = board[k, i].value;
                                board[k, i].value = 0;

                                temp.value = board[j, i].value;
                                tiles.Add(temp);

                                break;
                            }
                        }
                    }
                }
            }
        }


        // Fills empty tiles with random values
        public void fillTiles(List<Tile> tiles = null, int tileSize = 100)
        {
            Random rnd = new Random();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (board[i, j].value == 0)
                    {
                        board[i, j].value = rnd.Next(1, level - 1);
                        //board[i, j].value = rnd.Next(1, 17);

                        if (tiles != null)
                        {
                            Tile temp = new Tile(tileSize, gridSize);

                            temp.targetTop = i * tileSize;
                            temp.Top = (i - gridSize) * tileSize;
                            temp.Left = j * tileSize;
                            temp.Text = board[i, j].value.ToString();
                            temp.row = i;
                            temp.col = j;
                            temp.value = board[i, j].value;

                            tiles.Add(temp);
                        }
                    }
                }
            }
        }


        // Checks if any moves can be made
        public bool gameOver()
        {
            // Checks for pairs of numbers in each column and row
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize - 1; j++)
                {
                    if (board[i, j].value == board[i, j + 1].value) { return false; }
                }
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize - 1; j++)
                {
                    if (board[j, i].value == board[j + 1, i].value) { return false; }
                }
            }

            return true;
        }


        // Returns the highest tile on the board
        public int highestTile()
        {
            int highest = 0;

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (board[i, j].value > highest)
                    {
                        highest = board[i, j].value;
                    }
                }
            }

            return highest;
        }
    }
}
