namespace Just_Get_10
{
    partial class frmJustGet10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.tbGridSize = new System.Windows.Forms.TrackBar();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHighScores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.lblGridSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbGridSize)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.Black;
            this.pnlBoard.Location = new System.Drawing.Point(12, 179);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(500, 500);
            this.pnlBoard.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewGame.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(12, 87);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(254, 58);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(12, 24);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(193, 60);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score: 0";
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Interval = 1;
            this.tmrAnimate.Tick += new System.EventHandler(this.tmrAnimate_Tick);
            // 
            // tbGridSize
            // 
            this.tbGridSize.BackColor = System.Drawing.Color.Gray;
            this.tbGridSize.Location = new System.Drawing.Point(272, 128);
            this.tbGridSize.Maximum = 11;
            this.tbGridSize.Minimum = 2;
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(240, 45);
            this.tbGridSize.TabIndex = 3;
            this.tbGridSize.Value = 5;
            this.tbGridSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmHighScores,
            this.tsmHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(525, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmSave,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(37, 20);
            this.tsmFile.Text = "File";
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(103, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(103, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmHighScores
            // 
            this.tsmHighScores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDisplay,
            this.tsmReset});
            this.tsmHighScores.Name = "tsmHighScores";
            this.tsmHighScores.Size = new System.Drawing.Size(82, 20);
            this.tsmHighScores.Text = "High Scores";
            // 
            // tsmDisplay
            // 
            this.tsmDisplay.Name = "tsmDisplay";
            this.tsmDisplay.Size = new System.Drawing.Size(152, 22);
            this.tsmDisplay.Text = "Display";
            this.tsmDisplay.Click += new System.EventHandler(this.tsmDisplay_Click);
            // 
            // tsmReset
            // 
            this.tsmReset.Name = "tsmReset";
            this.tsmReset.Size = new System.Drawing.Size(152, 22);
            this.tsmReset.Text = "Reset";
            // 
            // tsmHelp
            // 
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmHelp.Text = "Help";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSize.Location = new System.Drawing.Point(346, 87);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(94, 23);
            this.lblGridSize.TabIndex = 5;
            this.lblGridSize.Text = "Grid Size: 5";
            // 
            // frmJustGet10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(525, 695);
            this.Controls.Add(this.lblGridSize);
            this.Controls.Add(this.tbGridSize);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "frmJustGet10";
            this.Text = "Just Get 10";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbGridSize)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.TrackBar tbGridSize;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.ToolStripMenuItem tsmHighScores;
        private System.Windows.Forms.ToolStripMenuItem tsmDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmReset;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;

    }
}

