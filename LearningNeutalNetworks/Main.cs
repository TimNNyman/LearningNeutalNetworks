using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace LearningNeutalNetworks
{
    struct TrainingData
    {
        public float[] inputs;
        public float[] awnser;

        public TrainingData(float[] _inputs, float[] _awnser)
        {
            inputs = _inputs;
            awnser = _awnser;
        }
    }

    class Main : Form
    {

        public Main() : base()
        {
            Text = "NN";
            Width = 600;
            Height = 400;
            BackColor = System.Drawing.Color.White;

            NeuralNetwork nn = new NeuralNetwork(new int[]{ 3, 5, 1 });

            TrainingData[] data = {
                new TrainingData(new float[]{ 0, 0, 0 },new float[]{ 1 }),
                new TrainingData(new float[]{ 0, 1, 0 },new float[]{ 1 }),
                new TrainingData(new float[]{ 1, 0, 0 },new float[]{ 1 }),
                new TrainingData(new float[]{ 1, 1, 0 },new float[]{ 0 }),
                new TrainingData(new float[]{ 0, 0, 1 },new float[]{ 1 }),
                new TrainingData(new float[]{ 0, 1, 1 },new float[]{ 0 }),
                new TrainingData(new float[]{ 1, 0, 1 },new float[]{ 0 }),
                new TrainingData(new float[]{ 1, 1, 1 },new float[]{ 0 })
            };


            int[] count = new int[data.Length];

            for (int i = 0; i < 50000; i++)
            {
                int index = Program.rnd.Next(data.Length);
                count[index]++;
                nn.train(data[index].inputs, data[index].awnser);
            }

            for (int i = 0; i < data.Length; i++)
            {
                float error = (Math.Abs(nn.feedForward(data[i].inputs)[0] - data[i].awnser[0]));
                Console.WriteLine(nn.feedForward(data[i].inputs)[0] + " Expected: " + data[i].awnser[0] + " Error: " + error +" \t" + (error < 0.1f ? "OK" : "--NOT OK--"));
            }

            for (int i = 0; i < count.Length; i++)
            {
                Console.WriteLine(count[i]);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(120, 67);
            this.Name = "Main";
            this.ResumeLayout(false);

        }
    }
}
