using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Just_Get_10
{
    public partial class frmHighScores : Form
    {
        public frmHighScores()
        {
            InitializeComponent();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("HighScores.txt");
            string line;
            string[] lineItems = new string[4];

            // Loads high score
            for (int i = 0; i < 10; i++)
            {
                line = SR.ReadLine();

                lineItems = line.Split(',');
                dgvHighScores.Rows.Add();

                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        dgvHighScores.Rows[i].Cells[j].Value = lineItems[j] + "x" + lineItems[j];
                    }
                    else
                    {
                        if (Convert.ToInt32(lineItems[j]) == 0)
                        {
                            dgvHighScores.Rows[i].Cells[j].Value = "-";
                        }
                        else
                        {
                            dgvHighScores.Rows[i].Cells[j].Value = lineItems[j];
                        }
                    }
                }
            }

            // Resizes the columns so they fit horizontally
            for (int i = 0; i < 3; i++)
            {
                dgvHighScores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            SR.Close();
        }
    }
}