using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pr13v7
{
    internal static class MatrixManipulations
    {
        public static void Create(this Matrix<int> numbers, int row, int column, int minValue, int maxValue)
        {
            int[,] matrix = new int[row, column];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = rnd.Next(minValue, maxValue);
                }
            }
            numbers.Add(matrix);
        }

        public static int CalculateColumn(this Matrix<int> matrix)
        {
            int sum = 0,
                average = 0,               
                localRow = 0,
                localColumn = 0,
                i;
            for (i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sum += matrix[i, j]; //1. Нахождение суммы
                }
            }

            average = sum / (matrix.Rows * matrix.Columns); //2. Нахождение среднего значения

            int minItem = matrix[0,0];
            for (i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (Math.Abs(average - matrix[i,j]) < minItem) //3. Поиск минимальной разницы между средней величиной и исходной
                    {
                        minItem = matrix[i, j];
                        localRow = i+1;
                        localColumn = j+1;
                    }
                }

            }

            //int[,]ints = new int[localRow,localColumn];

            return localColumn;
        }

        public static int CalculateRow(this Matrix<int> matrix)
        {
            int sum = 0,
                average = 0,
                localRow = 0,
                localColumn = 0,
                i;
            for (i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sum += matrix[i, j]; //1. Нахождение суммы
                }
            }

            average = sum / (matrix.Rows * matrix.Columns); //2. Нахождение среднего значения

            int minItem = matrix[0, 0];
            for (i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (Math.Abs(average - matrix[i, j]) < minItem) //3. Поиск минимальной разницы между средней величиной и исходной
                    {
                        minItem = matrix[i, j];
                        localRow = i + 1;
                        localColumn = j + 1;
                    }
                }

            }

            //int[,]ints = new int[localRow,localColumn];

            return localRow;
        }
    }
}

                        
           
         