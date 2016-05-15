namespace Just_Get_10
{
    partial class frmHighScores
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
            this.dgvHighScores = new System.Windows.Forms.DataGridView();
            this.gridSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxTile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHighScores
            // 
            this.dgvHighScores.AllowUserToAddRows = false;
            this.dgvHighScores.AllowUserToDeleteRows = false;
            this.dgvHighScores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSize,
            this.score,
            this.maxTile});
            this.dgvHighScores.Location = new System.Drawing.Point(12, 61);
            this.dgvHighScores.Name = "dgvHighScores";
            this.dgvHighScores.ReadOnly = true;
            this.dgvHighScores.RowHeadersVisible = false;
            this.dgvHighScores.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvHighScores.Size = new System.Drawing.Size(429, 239);
            this.dgvHighScores.TabIndex = 0;
            // 
            // gridSize
            // 
            this.gridSize.HeaderText = "Grid Size";
            this.gridSize.Name = "gridSize";
            this.gridSize.ReadOnly = true;
            // 
            // score
            // 
            this.score.HeaderText = "Score";
            this.score.Name = "score";
            this.score.ReadOnly = true;
            // 
            // maxTile
            // 
            this.maxTile.HeaderText = "Max Tile";
            this.maxTile.Name = "maxTile";
            this.maxTile.ReadOnly = true;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(12, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(429, 43);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show Scores";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score and Max Tile do not have to be from the same game";
            // 
            // frmHighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvHighScores);
            this.Name = "frmHighScores";
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.frmHighScores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighScores;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxTile;
        private System.Windows.Forms.Label label1;
    }
}