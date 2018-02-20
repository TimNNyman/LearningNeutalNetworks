using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace LearningNeutalNetworks
{
    class Main : Form
    {
        public Main() : base()
        {
            Text = "NN";
            Width = 600;
            Height = 400;
            BackColor = System.Drawing.Color.White;

            NeuralNetwork nn = new NeuralNetwork(2, 2, 1);
            float[] inputs = { 1, 2 };
            float[] outputs = nn.feedForward(inputs);

            for (int i = 0; i < outputs.Length; i++)
            {
                Console.WriteLine(outputs[i]);
            }

            nn.print();
        }


        /*
        Precepton brain = new Precepton(1);
        PointArea[] traningData = new PointArea[50];
        Renderer r;

        public Main() : base()
        {
            Text = "Assignment 2";
            Width = 517;
            Height = 540;
            BackColor = System.Drawing.Color.White;

            r = new Renderer(this.CreateGraphics());

            this.Paint += new PaintEventHandler(Draw);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }

        private void generateTraningData()
        {
            for (int i = 0; i < traningData.Length; i++) { traningData[i] = new PointArea(); }
        }

        private void train()
        {
            generateTraningData();
            for (int i = 0; i < traningData.Length; i++)
            {
                float[] inputs = { traningData[i].x, traningData[i].y };
                int target = traningData[i].label;
                brain.train(inputs, target);
            }
        }

        private void Draw(Object obj, PaintEventArgs args)
        {

            new PointArea().draw(r, Brushes.Blue, Brushes.Red);
            args.Graphics.DrawEllipse(Pens.Black, 125, 125, 250, 250);
            args.Graphics.DrawLine(Pens.Black, 0, 0, 500, 500);
        }

        private void Draw(Graphics g, int x, int y, Brush b)
        {
            g.FillRectangle(b, x, y, 5, 5);
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            train();
            Refresh();
        }
    */
    }
}
