using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNeutalNetworks
{
    class NeuralNetwork
    {
        private int[] nodes;
        private Matrix[] weights;
        private Matrix[] bias;

        private float learningRate = 0.05F;

        public NeuralNetwork(int[] layers)
        {
            nodes = new int[layers.Length];
            for (int i = 0; i < layers.Length; i++)
            {
                nodes[i] = layers[i];
            }

            weights = new Matrix[nodes.Length - 1];
            bias = new Matrix[nodes.Length - 1];
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                weights[i] = new Matrix(nodes[i + 1], nodes[i]);
                bias[i] = new Matrix(nodes[i + 1], 1);

                weights[i].randomize();
                bias[i].randomize();
            }
        }

        public float[] feedForward(float[] input)
        {
            Matrix matrix = Matrix.fromArray(input);

            for (int i = 0; i < weights.Length; i++)
            {
                matrix = Matrix.multiply(weights[i], matrix);
                matrix.add(bias[i]);
                matrix.map(sigmoid);
            }

            return matrix.toArray();
        }

        public void train(float[] inputs, float[] awnsers)
        {
            Matrix[] results = new Matrix[weights.Length + 1];
            results[0] = Matrix.fromArray(inputs);

            for (int i = 0; i < weights.Length; i++)
            {
                Matrix result = Matrix.multiply(weights[i], results[i]);
                result.add(bias[i]);
                result.map(sigmoid);
                results[i + 1] = result;
            }

            //Backpropegation
            Matrix[] errors = new Matrix[results.Length];
            errors[results.Length - 1] = results[results.Length - 1];
            for (int i = weights.Length; i > 0; i--)
            {
                if(i == weights.Length)
                    errors[i - 1] = Matrix.subtract(Matrix.fromArray(awnsers), errors[i]);
                else
                    errors[i - 1] = Matrix.multiply(Matrix.transpose(weights[i]), errors[i]);

                Matrix gradients = Matrix.map(results[i], dsigmoid);
                gradients.multiply(errors[i - 1]);
                gradients.multiply(learningRate);

                Matrix deltas = Matrix.multiply(gradients, Matrix.transpose(results[i - 1]));

                weights[i - 1].add(deltas);
                bias[i - 1].add(gradients);
            }
        }

        public void print()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i].print();
                Console.WriteLine();
                bias[i].print();
                Console.WriteLine();
                Console.WriteLine();
            }
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


/* Old
 * public void train(float[] inputs, float[] awnsers)
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
 */
