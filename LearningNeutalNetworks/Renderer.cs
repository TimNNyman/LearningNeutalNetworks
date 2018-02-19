using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNeutalNetworks
{
    class Renderer
    {
        private Graphics g;
        private int r = 32;

        public Renderer(Graphics _g)
        {
            g = _g;
        }

        public void DrawCircle(float x, float y, Brush outline, Brush core)
        {
            g.FillEllipse(outline, g.DpiX * x, g.DpiY * y, r, r);
            g.FillEllipse(core, g.DpiX * x + r * 0.25F, g.DpiY * y + r * 0.25F, r * 0.5F, r * 0.5F);
        }
    }
}
