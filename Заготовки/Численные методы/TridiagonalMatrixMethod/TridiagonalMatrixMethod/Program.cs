using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TridiagonalMatrixMethod
{
    class Program
    {
        //http://old.exponenta.ru/educat/class/courses/vvm/theme_5/example.asp Пример с прогонкой
        static void Main(string[] args)
        {
            /*
                2x1 + x2            =-5
                x1 + 10x2 - 5x3     =-18
                    x2 - 5x3 + 2x4  =-40
                        x3 + 4x4    =-27
            
            
            double[] A = { 0, 1, 1, 1 };
            double[] C = { 2, 10, -5, 4 };
            double[] B = { 1, -5, 2, 0 };
            double[] F = { -5, -18, -40, -27 };
            */
            int l = 4; //Число неизвестных

            double[,] matrix =
            {
                { 2, 1, 0, 0 },
                { 1, 10, -5, 0 },
                { 0, 1, -5, 2 },
                { 0, 0, 1, 4 }
            };

            double[] right = { -5, -18, -40, -27 };

            var tuple = ConvertToACBF(matrix, right, l);
            double[] A = tuple.Item1;
            double[] C = tuple.Item2;
            double[] B = tuple.Item3;
            double[] F = tuple.Item4;

            double[] x = TridiagonalMethod(A, C, B, F, l);

            Array.ForEach(x, Console.WriteLine);
        }

        static Tuple<double[], double[], double[], double[]> ConvertToACBF(double[,] matrix, double[] right, int l)
        {
            double[] A = new double[l];
            double[] C = new double[l];
            double[] B = new double[l];
            double[] F = new double[l];

            for (var i = 0; i < l; i++)
            {
                if (i != 0)
                    A[i] = matrix[i, i - 1];

                C[i] = matrix[i, i];

                if (i != l - 1)
                    B[i] = matrix[i, i + 1];

                F[i] = right[i];
            }

            return new Tuple<double[], double[], double[], double[]>(A, C, B, F);
        }

        static double[] TridiagonalMethod(double[] A, double[] C, double[] B, double[] F, int l)
        {
            double[] alpha = new double[l];
            double[] beta = new double[l];
            alpha[0] = -B[0] / C[0];
            beta[0] = F[0] / C[0];

            for (int i = 0; i < l - 1; i++)
            {
                alpha[i + 1] = -B[i] / (A[i] * alpha[i] + C[i]);
                beta[i + 1] = (F[i] - A[i] * beta[i]) / (A[i] * alpha[i] + C[i]);
            }
            double[] result = new double[l];
            result[l - 1] = (F[l - 1] - A[l - 1] * beta[l - 1]) / (A[l - 1] * alpha[l - 1] + C[l - 1]);
            for (int i = l - 2; i >= 0; i--)
            {
                result[i] = alpha[i + 1] * result[i + 1] + beta[i + 1];
            }
            return result;
        }
    }
}
