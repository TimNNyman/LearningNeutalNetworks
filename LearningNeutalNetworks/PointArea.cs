using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningNeutalNetworks
{
    class PointArea
    {
        public float x, y;
        public int label;

        public PointArea()
        {
            x = (float)Program.rnd.NextDouble();
            y = (float)Program.rnd.NextDouble();

            label = generateLabel(); // x > y ? 1 : -1;
        }

        public int generateLabel()
        {
            return ((x - 50) * (x - 50) + (y - 50) * (y - 50)) < (25) * (25) ? 1 : -1;
        }

        public void draw(Graphics g)
        {
            //draw(g, label == 1 ? Brushes.Orange : Brushes.Blue);
        }

        public void draw(Renderer r, Brush outline, Brush core)
        {
            r.DrawCircle(x, y, outline, core);
            //g.FillRectangle(b, x, y, 5, 5);
        }
    }
}
