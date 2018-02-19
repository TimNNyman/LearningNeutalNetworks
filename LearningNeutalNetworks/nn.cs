using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNeutalNetworks
{
    class NeuralNetwork
    {
        private int inputNodes, hiddenNodes, outputNodes;
        private Matrix weights_ih;
        private Matrix weights_ho;

        private Matrix bias_h;
        private Matrix bias_o;

        public NeuralNetwork(int numI, int numH, int numO)
        {
            inputNodes = numI;
            hiddenNodes = numH;
            outputNodes = numO;

            weights_ih = new Matrix(hiddenNodes, inputNodes);
            weights_ho = new Matrix(outputNodes, hiddenNodes);
            bias_h = new Matrix(hiddenNodes, 1);
            bias_o = new Matrix(outputNodes, 1);

            weights_ih.randomize();
            weights_ho.randomize();
            bias_h.randomize();
            bias_o.randomize();

        }

        public float[] feedForward(float[] input)
        {
            Matrix hidden = Matrix.multiply(weights_ih, Matrix.fromArray( input));
            hidden.add(bias_h);
            hidden.map(sigmoid);

            Matrix output = Matrix.multiply(weights_ho, hidden);
            output.add(bias_o);
            output.map(sigmoid);
            return output.toArray();
        }

        public void train(float[] input, float[] awnser)
        {

        }

        public void print()
        {
            weights_ih.print();
            Console.WriteLine();
            bias_h.print();
            Console.WriteLine();
            Console.WriteLine();
            weights_ho.print();
            Console.WriteLine();
            bias_o.print();
            Console.WriteLine();
        }

        public float sigmoid(float x)
        {
            return (float)(1 / (1 + Math.Exp(-x)));
        }
    }
}
