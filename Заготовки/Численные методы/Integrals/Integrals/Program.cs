using System;

namespace Integrals
{
    class Program
    {
        private static void Main(string[] args)
        {
            SimpsonExample();
            TrapezoidExample();
            RectangleExample();
        }

        private static void RectangleExample()
        {
            int n = 1000; //Количество точек
            double a = 0;
            double b = 10;
            double h = (b - a) / (n - 1);
            double[] y = new double[n];

            for (var i = 0; i < n; i++)
            {
                y[i] = Math.Sin(a + h * i);
            }

            var res = RectangleMethod(y, h);

            Console.WriteLine(res);
        }

        private static void TrapezoidExample()
        {
            int n = 1000; //Количество точек
            double a = 0;
            double b = 10;
            double h = (b - a) / (n - 1);
            double[] y = new double[n];

            for (var i = 0; i < n; i++)
            {
                y[i] = Math.Sin(a + h * i);
            }

            var res = TrapezoidMethod(y, h);

            Console.WriteLine(res);
        }

        private static void SimpsonExample()
        {
            int N = 100;
            double a = 0;
            double b = 10;
            double h = (b - a) / N;
            double[] y = new double[N + 1]; //100 отрезков => 101 точка

            for (var i = 0; i < y.Length; i++) //Заполняем сетку значениями
            {
                y[i] = Math.Sin(a + i * h);
            }

            var res = SimpsonMethod(y, N, h);

            Console.WriteLine(res);
        }

        /// <summary>
        /// Метод Симпсона
        /// </summary>
        /// <param name="y">Массив значений функции</param>
        /// <param name="N">Число отрезков (чётное)</param>
        /// <param name="h">Длина отрезка (шаг)</param>
        /// <returns>Значение интеграла</returns>
        private static double SimpsonMethod(double[] y, int N, double h)
        {
            var sum = 0.0;
            for (var k = 1; k < N; k += 2)
            {
                sum += y[k - 1] + 4 * y[k] + y[k + 1];
            }

            return (h / 3.0) * sum;
        }

        /// <summary>
        /// Метод трапеций
        /// </summary>
        /// <param name="y">Массив значений функции</param>
        /// <param name="h">шаг между точками</param>
        /// <returns>Значение интеграла</returns>
        private static double TrapezoidMethod(double[] y, double h)
        {
            var n = y.Length;
            var sum = (y[0] + y[n - 1]);

            for (int i = 1; i < n - 1; i++)
            {
                sum += y[i];
            }

            return h * sum;
        }

        /// <summary>
        /// Метод трапеций
        /// </summary>
        /// <param name="y">Массив значений функции</param>
        /// <param name="h">шаг между точками</param>
        /// <returns>Значение интеграла</returns>
        private static double RectangleMethod(double[] y, double h)
        {
            var n = y.Length;
            var sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                sum += y[i];
            }

            return h * sum;
        }
    }
}
