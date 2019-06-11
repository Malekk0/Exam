using System;

namespace GradientMethod
{
    class Program
    {
        //Нужна только производная функции
        private static Vector DF_dx(Vector x)
        {
            return
                new Vector(new[]
                {
                    -(-x[0]*(x[1] + 5) - 2*(x[1]*x[1] + 1))/Math.Pow((1 + x[0]*x[0] + x[1]*x[1]), 3/2.0),
                    -(x[0]*x[0] + 2*x[0]*x[1] - 5*x[1] + 1)/Math.Pow((1 + x[0]*x[0] + x[1]*x[1]), 3/2.0)
                });
        }

        private static bool ExaminationResult(Vector prevX, Vector actualX, double e)
        {
            for (var i = 0; i < prevX.size; i++)
            {
                if (Math.Abs(prevX[i] - actualX[i]) > e)
                    return false;
            }
            return true;
        }

        private static void Main(string[] args)
        {
            //Начальная точка для поиска
            var x = new Vector(new[] { 4.0, 5.0 });
            //Шаг
            var lambda = 0.1;
            //Критерий остановки 
            var e = 0.0001;

            Vector newX = new Vector(x);
            do
            {
                x = new Vector(newX);
                newX = x - lambda * DF_dx(x);

            } while (!ExaminationResult(x, newX, e));

            Console.WriteLine(newX);
        }
    }
}
