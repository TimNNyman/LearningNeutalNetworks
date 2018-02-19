using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningNeutalNetworks
{
    class Program
    {
        public static Random rnd = new Random();
        //Precepton p;

        static void Main(string[] args)
        {
            Main m = new Main();
            Application.Run(m);
            m.Refresh();
        }
    }
}
