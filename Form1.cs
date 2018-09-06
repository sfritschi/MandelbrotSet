using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            double step = 200.0;
            int rightShift = 125;
            int midX = panel1.Width / 2 + rightShift;
            int midY = panel1.Height / 2;
            for (int i = 0; i < panel1.Width; i++)
            {
                for (int j = 0; j < panel1.Height; j++)
                {
                    Complex c = new Complex((i - midX) / step, (j - midY) / step);
                    if (c.IsConvergent())
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(i, j, 1, 1));
                    }
                }
            }
        }
    }
}
