using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Just_Get_10
{
    public partial class frmJustGet10 : Form
    {
                              /// TO DO LIST ///
        /*
         * Use a stack of tiles for new tiles instead of just assigning them a definite top. This will stop long wait times for one new tile
         * falling in from the top
         * 
         *
         * 
         *
         * 
         * Make newly-combined tile pop when combined (separate timer?) and destroyed tiles shrink
         * 
         * Save top high score for each gridSize from 2x2 - 11x11, include highest tile and score. Name?
         * 
         * Make panel and tiles scale up or down when form is resized. Keep 1:1 aspect ratio. Make min/max size
         * 
         * Make initializeGame() and put code from buttonClick and game loading in to eliminate duplicate code
         * 
         * Make new tiles based on level and include probablity of pieces closer to the current level
         * 
         * 
         * 
         * Elimination game mode where once you get rid of all 1's, they disappear, then 2's and 3s etc
         */


        #region Variables

        private Color[] tileBGColors = new Color[20];    // Tile background colors
        private Color[] tileTextColors = new Color[20];  // Tile text colors
        private List<Tile> tempTiles = new List<Tile>(); // For animating new tiles dropping
        private int fallSpeed = 15;                      // For animating new tiles dropping
        private JustGet10Game game;
        private int gridSize = 5;
        private int tileSize = 100;
        private bool gameStarted = false;

        #endregion




        #region Constructor

        public frmJustGet10()
        {
            InitializeComponent();
        }

        #endregion




        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("HighScores.txt"))
            {
                File.Create("HighScores.txt").Close();
                StreamWriter SW = File.AppendText("HighScores.txt");
                for(int i = 2; i <= 11; i++)
                {
                    // Gridsize, score, max tile
                    SW.WriteLine(i + "," + 0 + "," + 0);
                }
                SW.Close();
            }

            tileBGColors[0] = Color.Black;
            tileBGColors[1] = ColorTranslator.FromHtml("#B9F349");
            tileBGColors[2] = ColorTranslator.FromHtml("#57BFF9");
            tileBGColors[3] = ColorTranslator.FromHtml("#FFC85B");
            tileBGColors[4] = ColorTranslator.FromHtml("#FF7155");
            tileBGColors[5] = ColorTranslator.FromHtml("#019E87");
            tileBGColors[6] = ColorTranslator.FromHtml("#7763FA");
            tileBGColors[7] = ColorTranslator.FromHtml("#F557C2");
            tileBGColors[8] = ColorTranslator.FromHtml("#E62E45");
            tileBGColors[9] = ColorTranslator.FromHtml("#FEF734");
            tileBGColors[10] = ColorTranslator.FromHtml("#21610B");
            tileBGColors[11] = ColorTranslator.FromHtml("#F5A9BC");
            tileBGColors[12] = ColorTranslator.FromHtml("#F5DA81");
            tileBGColors[13] = ColorTranslator.FromHtml("#E2A9F3");
            tileBGColors[14] = ColorTranslator.FromHtml("#CEF6EC");
            tileBGColors[15] = ColorTranslator.FromHtml("#E6E6E6");
            tileBGColors[16] = ColorTranslator.FromHtml("#01DF74");

            tileTextColors[0] = Color.Black;
            tileTextColors[1] = ColorTranslator.FromHtml("#35AB04");
            tileTextColors[2] = ColorTranslator.FromHtml("#0E8BF9");
            tileTextColors[3] = ColorTranslator.FromHtml("#FD7721");
            tileTextColors[4] = ColorTranslator.FromHtml("#FED099");
            tileTextColors[5] = ColorTranslator.FromHtml("#79E796");
            tileTextColors[6] = ColorTranslator.FromHtml("#CFBAF6");
            tileTextColors[7] = ColorTranslator.FromHtml("#FDBC9E");
            tileTextColors[8] = ColorTranslator.FromHtml("#FED2B7");
            tileTextColors[9] = ColorTranslator.FromHtml("#D2543E");
            tileTextColors[10] = ColorTranslator.FromHtml("#A5DF00");
            tileTextColors[11] = ColorTranslator.FromHtml("#FA5882");
            tileTextColors[12] = ColorTranslator.FromHtml("#8A0808");
            tileTextColors[13] = ColorTranslator.FromHtml("#5F4C0B");
            tileTextColors[14] = ColorTranslator.FromHtml("#2EFEC8");
            tileTextColors[15] = ColorTranslator.FromHtml("#2E2E2E");
            tileTextColors[16] = ColorTranslator.FromHtml("#4B088A");
        }


        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Makes sure user wants to start another game
            if (gameStarted && game.score > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Start new game? All progress will be lost.", "New Game", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            gridSize = tbGridSize.Value;
            tileSize = pnlBoard.Width / gridSize;

            pnlBoard.Width = gridSize * tileSize;
            pnlBoard.Height = gridSize * tileSize;

            game = new JustGet10Game(gridSize);
            
            createTiles(gridSize);
            displayBoard(gridSize);

            tmrAnimate.Start();

            gameStarted = true;
            toggleTiles(true);

            while (game.gameOver())
            {
                game.reset();
                displayBoard(gridSize);
            }
        }


        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            if (tempTiles.Count() == 0) { return; }


            // Animates any blocks downward until they hit another block or the floor
            for (int i = 0; i < tempTiles.Count(); i++)
            {
                if (tempTiles[i].Top <= tempTiles[i].targetTop)
                {
                    tempTiles[i].Top += fallSpeed;
                }
                else
                {
                    int row = tempTiles[i].row;
                    int col = tempTiles[i].col;

                    pnlBoard.Controls["T" + row + col].Visible = true;
                    tempTiles[i].Dispose();
                    tempTiles.RemoveAt(i);
                }
            }


        }


        void buttonClick(object sender, EventArgs e)
        {
            // Checks for game over
            if (game.gameOver())
            {
                toggleTiles(false);
                gameStarted = false;
                saveHighScore();
            }


            // Performs move
            Tile t = sender as Tile;

            if (game.numSelectedTiles > 1 && game.board[t.row, t.col].selected)
            {
                game.combineTiles(t.row, t.col);
                game.dropTiles(tempTiles, tileSize);
                hideTiles();
                game.fillTiles(tempTiles, tileSize);
                hideTiles();

                game.deselectTiles();
            }
            else
            {
                game.deselectTiles();
                game.selectTiles(t.row, t.col);

                if (game.numSelectedTiles < 2)
                {
                    game.deselectTiles();
                }
            }

            
            // Updates the board
            displayBoard(gridSize);
        }


        private void tbSize_Scroll(object sender, EventArgs e)
        {
            lblGridSize.Text = "Grid Size: " + tbGridSize.Value.ToString();
        }


        private void tsmSave_Click(object sender, EventArgs e)
        {
            saveGame();
        }


        private void tsmOpen_Click(object sender, EventArgs e)
        {
            loadGame();
        }


        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tsmDisplay_Click(object sender, EventArgs e)
        {
            frmHighScores frmScores = new frmHighScores();
            frmScores.Show();
        }

        #endregion




        #region Methods

        // Creates a grid of tiles on the board
        private void createTiles(int gridSize)
        {
            pnlBoard.Controls.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Tile tle = new Tile(tileSize, gridSize);
                    tle.Name = "T" + i + j;
                    tle.row = i;
                    tle.col = j;
                    tle.Left = tileSize * j;
                    tle.Top = tileSize * i;
                    tle.Click += new EventHandler(buttonClick);

                    pnlBoard.Controls.Add(tle);
                }
            }
        }


        // Updates the board's tiles with proper colors, values etc.
        private void displayBoard(int gridSize)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    pnlBoard.Controls["T" + i + j].Text = game.board[i, j].value.ToString();
                    pnlBoard.Controls["T" + i + j].ForeColor = tileTextColors[game.board[i, j].value];
                    pnlBoard.Controls["T" + i + j].BackColor = tileBGColors[game.board[i, j].value];
                    Tile tle = pnlBoard.Controls["T" + i + j] as Tile;

                    if (game.board[i, j].selected)
                    {
                        pnlBoard.Controls["T" + i + j].BackgroundImage = Image.FromFile("selected.png");
                    }
                    else
                    {
                        pnlBoard.Controls["T" + i + j].BackgroundImage = null;
                    }
                }
            }

            lblScore.Text = "Score: " + game.score.ToString();
        }


        // Hides any tiles currently being animated
        private void hideTiles()
        {
            for (int i = 0; i < tempTiles.Count(); i++)
            {
                pnlBoard.Controls["T" + tempTiles[i].row + tempTiles[i].col].Visible = false;
                tempTiles[i].BackColor = tileBGColors[tempTiles[i].value];
                tempTiles[i].ForeColor = tileTextColors[tempTiles[i].value];

                pnlBoard.Controls.Add(tempTiles[i]);

                tempTiles[i].BringToFront();
            }
        }


        // Makes all tiles visible
        private void showTiles()
        {
            for (int i = 0; i < game.gridSize; i++)
            {
                for (int j = 0; j < game.gridSize; j++)
                {
                    pnlBoard.Controls["T" + i + j].Visible = true;
                }
            }
        }


        // Enables / Disables all tiles
        private void toggleTiles(bool enable)
        {
            for (int i = 0; i < game.gridSize; i++)
            {
                for (int j = 0; j < game.gridSize; j++)
                {
                    pnlBoard.Controls["T" + i + j].Enabled = enable;
                }
            }
        }


        // Saves a game
        private void saveGame()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files | *.txt";
            sfd.DefaultExt = "txt";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                File.Delete(sfd.FileName);
                StreamWriter SW = File.CreateText(sfd.FileName);

                SW.WriteLine(gridSize);
                SW.WriteLine(game.score);

                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        SW.WriteLine(game.board[i, j].value);
                    }
                }

                SW.Close();
            }
        }


        // Loads a game
        private void loadGame()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files | *.txt";
            ofd.DefaultExt = "txt";
            ofd.ShowDialog();


            if (ofd.FileName != "")
            {
                try
                {
                    StreamReader SR = new StreamReader(ofd.FileName);

                    gridSize = Convert.ToInt32(SR.ReadLine());
                    game = new JustGet10Game(gridSize);
                    game.score = Convert.ToInt32(SR.ReadLine());

                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
                        {
                            game.board[i, j].value = Convert.ToInt32(SR.ReadLine());
                        }
                    }

                    SR.Close();

                    tileSize = pnlBoard.Width / gridSize;

                    pnlBoard.Width = gridSize * tileSize;
                    pnlBoard.Height = gridSize * tileSize;

                    

                    createTiles(gridSize);

                    tmrAnimate.Start();

                    gameStarted = true;
                    toggleTiles(true);

                    displayBoard(gridSize);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading file.\n\n" + e.ToString());
                }
            }
        }


        // Checks for high score or highest tile records
        private void saveHighScore()
        {
            bool overwrite = false;


            // Loads previous high scores
            string[] scores = new string[11];
            StreamReader SR = new StreamReader("HighScores.txt");

            for (int i = 0; i < 10; i++)
            {
                scores[i] = SR.ReadLine();
            }

            SR.Close();
            

            // Gets current record ready to be checked
            string[] lineItems = new string[3];
            lineItems = scores[gridSize - 2].Split(',');
            string line = gridSize.ToString() + ",";


            // Checks for high score record
            if (game.score > Convert.ToInt32(lineItems[1]))
            {
                MessageBox.Show("New high score! " + game.score);

                line += game.score.ToString() + ",";
                overwrite = true;
            }
            else
            {
                line += lineItems[1] + ",";
            }


            // Checks for highest tile record
            if (game.highestTile() > Convert.ToInt32(lineItems[2]))
            {
                MessageBox.Show("New highest tile! " + game.highestTile());

                line += game.highestTile().ToString();
                overwrite = true;
            }
            else
            {
                line += lineItems[2];
            }


            // Overwrites old score if any records were broken
            if (overwrite)
            {
                // Overwrites old score
                File.Create("HighScores.txt").Close();
                StreamWriter SW = File.AppendText("HighScores.txt");

                scores[gridSize - 2] = line;

                for (int i = 0; i < 10; i++)
                {
                    SW.WriteLine(scores[i]);
                }
                SW.Close();
            }
        }

        #endregion

        

        

        

        
    }
}
