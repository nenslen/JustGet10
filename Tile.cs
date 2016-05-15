using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Just_Get_10
{
    class Tile : Button
    {
        public int value;
        public int targetTop;
        public int row;
        public int col;
        public bool selected;


        public Tile(int size, int gridSize)
        {
            Size = new Size(size, size);
            Font = new Font("Comic sans", 25f);
            if (gridSize > 7) { Font = new Font("Comic Sans", 15f); }
            FlatStyle = FlatStyle.Flat; // Allows use of borders
            FlatAppearance.BorderSize = 0;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
