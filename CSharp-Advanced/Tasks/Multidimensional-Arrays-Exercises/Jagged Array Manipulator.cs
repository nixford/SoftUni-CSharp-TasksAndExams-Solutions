﻿using System;
using System.Linq;

namespace _06_JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowInMatrix = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rowInMatrix][];

            for (int i = 0; i < rowInMatrix; i++)
            {
                double[] currentRowValue = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[i] = currentRowValue;
            }

            for (int i = 0; i < rowInMatrix - 1; i++)
            {
                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string operand = command[0];

                if (operand == "End")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                double value = double.Parse(command[3]);

                if (!IsCoordinatesValid(matrix, row, column))
                {
                    continue;
                }

                if (operand == "Add")
                {
                    matrix[row][column] += value;
                }

                else if (operand == "Subtract")
                {
                    matrix[row][column] -= value;
                }
            }

            for (int i = 0; i < rowInMatrix; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static bool IsCoordinatesValid(double[][] matrix, int row, int column)
        {
            if (row >= 0 && row < matrix.Length)
            {
                if (column >= 0 && column < matrix[row].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}