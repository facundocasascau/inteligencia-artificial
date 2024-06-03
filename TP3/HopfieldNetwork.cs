using System;
using System.Linq;

namespace TP3;

public class HopfieldNetwork
{
    private int dimension;
    private double[,] weights;

    public HopfieldNetwork(int dimension)
    {
        this.dimension = dimension;
        weights = new double[dimension, dimension];
    }

    public void Train(double[][] trainingData)
    {
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                if (i == j)
                    weights[i, j] = 0;
                else
                    weights[i, j] = trainingData.Sum(data => data[i] * data[j]);
            }
        }
    }

    public double[] Predict(double[] input, int iterations = 10)
    {
        double[] output = (double[])input.Clone();
        for (int iter = 0; iter < iterations; iter++)
        {
            for (int i = 0; i < dimension; i++)
            {
                double sum = 0;
                for (int j = 0; j < dimension; j++)
                {
                    sum += weights[i, j] * output[j];
                }
                output[i] = sum >= 0 ? 1 : -1;
            }
        }
        return output;
    }
}
