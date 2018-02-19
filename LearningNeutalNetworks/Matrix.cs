using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNeutalNetworks
{
    class Matrix
    {
        int Rows, Cols;
        float[,] Data;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Data = new float[rows, cols];

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] = 0;
                }
            }
        }
        public static Matrix fromArray(float[] arr)
        {
            Matrix m = new Matrix(arr.Length, 1);
            for (int i = 0; i < arr.Length; i++)
            {
                m.Data[i, 0] = arr[i];
            }
            return m;
        }

        public static Matrix subtract(Matrix a, Matrix b)
        {
            // Return a new Matrix a-b
            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
                }
            }
            return result;
        }

        public float[] toArray()
        {
            List<float> arr = new List<float>();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    arr.Add(this.Data[i, j]);
                }
            }
            return arr.ToArray();
        }

        public void randomize()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] = (float)Program.rnd.NextDouble() * 2 - 1;
                }
            }
        }

        public void add(Matrix m)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] += m.Data[i, j];
                }
            }
        }

        public void add(int n)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] += n;
                }

            }
        }

        public static Matrix transpose(Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Cols, matrix.Rows);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    result.Data[j, i] = matrix.Data[i, j];
                }
            }
            return result;
        }

        public static Matrix multiply(Matrix a, Matrix b)
        {
            // Matrix product
            if (a.Cols != b.Rows)
            {
                //console.log('Columns of A must match rows of B.')
                return null;
            }

            Matrix result = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    // Dot product of values in col
                    float sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        sum += a.Data[i, k] * b.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }
            return result;
        }

        public void multiply(Matrix m)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] *= m.Data[i, j];
                }
            }
        }

        public void multiply(int n)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] *= n;
                }

            }
        }

        public void map(Func<float, float> func)
        {
            // Apply a function to every element of matrix
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    float val = this.Data[i, j];
                    this.Data[i, j] = func(val);
                }
            }
        }

        public static Matrix map(Matrix matrix, Func<float, float> func)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            // Apply a function to every element of matrix
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    float val = matrix.Data[i, j];
                    result.Data[i, j] = func(val);
                }
            }
            return result;
        }

        public void print()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    Console.Write(this.Data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
