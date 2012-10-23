using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XNA = Microsoft.Xna.Framework;


namespace GameForm
{
    public partial class xWindow : Form
    {
        
        public x2D _x2D;


        public xWindow()
        {
            InitializeComponent();
            _x2D = new x2D(pView);
            
        }
        
        private void xWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _x2D.Exit();
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //_x2D.sizeSpriteNew = Convert.ToInt16(textBox1.Text);
        }

        private void pView_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = Convert.ToString(_x2D.mouse.X) + ";" + Convert.ToString(_x2D.mouse.Y) + "|" + "|" + Convert.ToString(_x2D.xx) + ";" + Convert.ToString(_x2D.yy) + "|" + "|" + Convert.ToString(_x2D._xstone) + ";" + Convert.ToString(_x2D._ystone);
        }

     
    }
}
