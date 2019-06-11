using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dy_RangingMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double[] Func(double x, double[] y) // Система
        {
            return new[] { y[1], -y[0] };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double a = 0;
            double b = 5;
            double ya = 1;
            double yb = 1;

            int n = 100;
            double h = (b - a) / n;

            double alpha1 = 2;
            double alpha2 = 3.5;
            double alphaMiddle;
            double alphaMiddleResult;

            do
            {
                alphaMiddle = (alpha1 + alpha2) / 2.0;
                alphaMiddleResult = ModifedEulerMethod(Func, a, h, n, ya, alphaMiddle, yb, false);
                var alpha1Result = ModifedEulerMethod(Func, a, h, n, ya, alpha1, yb, false);
                var alpha2Result = ModifedEulerMethod(Func, a, h, n, ya, alpha2, yb, false);

                if(alpha1Result * alpha2Result > 0)
                    throw new Exception("Неверные начальные углы");

                if (alphaMiddleResult * alpha1Result < 0)
                {
                    alpha2 = alphaMiddle;
                }
                else
                {
                    alpha1 = alphaMiddle;
                }

            } while (Math.Abs(alphaMiddleResult) > 0.001);


            ModifedEulerMethod(Func, a, h, n, ya, alphaMiddle, yb, true);
        }

        private double ModifedEulerMethod(Func<double, double[], double[]> f, double x0, double h, int n, double y00, double y01, double targetY, bool buildGraph)
        {
            double[] y = { y00, y01 };
            double x;

            for (int i = 0; i < n; i++)
            {
                x = x0 + i * h;
                double[] funcy = f(x, y);
                double[] _y = new double[2];

                for (int j = 0; j < 2; j++)
                    _y[j] = _y[j] + h * funcy[j];

                double[] func_y = f(x + h, _y);

                for (int j = 0; j < 2; j++)
                    y[j] = y[j] + (h / 2.0) * (funcy[j] + func_y[j]);

                if (buildGraph)
                    chart1.Series[0].Points.AddXY(x, y[0]);
            }

            return targetY - y[0];
        }
    }
}
