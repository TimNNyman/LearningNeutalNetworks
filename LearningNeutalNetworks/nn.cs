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

        private float learningRate = 0.1F;

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
            Matrix hidden = Matrix.multiply(weights_ih, Matrix.fromArray(input));
            hidden.add(bias_h);
            hidden.map(sigmoid);

            Matrix output = Matrix.multiply(weights_ho, hidden);
            output.add(bias_o);
            output.map(sigmoid);
            return output.toArray();
        }

        public void train(float[] inputs, float[] awnsers)
        {
            Matrix hidden = Matrix.multiply(weights_ih, Matrix.fromArray(inputs));
            hidden.add(bias_h);
            hidden.map(sigmoid);

            Matrix output = Matrix.multiply(weights_ho, hidden);
            output.add(bias_o);
            output.map(sigmoid);

            //Calc changes needed for hidden - output
            Matrix outputErrors = Matrix.subtract(Matrix.fromArray(awnsers), output);
            
            Matrix output_gradients = Matrix.map(output, dsigmoid);
            output_gradients.multiply(outputErrors);
            output_gradients.multiply(learningRate);
            
            Matrix hidden_T = Matrix.transpose(hidden);
            Matrix weight_ho_deltas = Matrix.multiply(output_gradients, hidden_T);

            weights_ho.add(weight_ho_deltas);
            bias_o.add(output_gradients);

            //Calc changes needed for input - hidden
            Matrix hiddenErrors = Matrix.multiply(Matrix.transpose(weights_ho), outputErrors);

            Matrix hidden_gradients = Matrix.map(hidden, dsigmoid);
            hidden_gradients.multiply(hiddenErrors);
            hidden_gradients.multiply(learningRate);

            Matrix inputs_T = Matrix.transpose(Matrix.fromArray(inputs));
            Matrix weight_ih_deltas = Matrix.multiply(hidden_gradients, inputs_T);

            weights_ih.add(weight_ih_deltas);
            bias_h.add(hidden_gradients);
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

        public float dsigmoid(float y)
        {
            return 1 - y;
        }
    }
}
