using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNeutalNetworks
{
    class Precepton
    {
        float[] weights;
        float lr = 0.1F;

        public Precepton(int n)
        {
            weights = new float[n];
            //Init weigths randomly
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = (float)((Program.rnd.NextDouble() * 2.0) - 1.0);
            }
        }

        public int guess(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            int output = sign(sum);
            return output;
        }

        public void train(float[] inputs, int target)
        {
            int guessRes = guess(inputs);
            int error = target - guessRes;

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] += error * inputs[i] * lr;
            }
        }

        int sign(float n)
        {
            return n >= 0 ? 1 : -1;
        }
    }
}
