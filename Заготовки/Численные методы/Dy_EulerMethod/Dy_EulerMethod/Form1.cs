using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dy_EulerMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double[] Func(double x, double[] y)
        {
            return new[] { y[1], -y[0] };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SimpleEulerMethod(Func, 0, 0.01, 3000, 1, 0);
            //ModifedEulerMethod(Func, 0, 0.01, 3000, 1, 0);
        }

        /// <summary>
        /// Простой метод Эйлера
        /// </summary>
        /// <param name="f">Правая часть системы</param>
        /// <param name="x0">Начальное х0</param>
        /// <param name="h">Шаг</param>
        /// <param name="n">Сколько шагов</param>
        /// <param name="y00">Значение y в х0</param>
        /// <param name="y01">Значение y` в х0</param>
        /// <returns></returns>
        private void SimpleEulerMethod(Func<double, double[], double[]> f, double x0, double h, int n, double y00,
            double y01)
        {
            double[] y = { y00, y01 };

            for (var i = 0; i < n; i++)
            {
                var x = x0 + h * i;
                var funcValue = f(x, y);

                chart1.Series[0].Points.AddXY(x, y[0]);
                chart1.Series[1].Points.AddXY(x, y[1]);

                y[0] = y[0] + h * funcValue[0];
                y[1] = y[1] + h * funcValue[1];
            }
        }

        /// <summary>
        /// Модифицированный метод Эйлера
        /// </summary>
        /// <param name="f">Правая часть системы</param>
        /// <param name="x0">Начальное х0</param>
        /// <param name="h">Шаг</param>
        /// <param name="n">Сколько шагов</param>
        /// <param name="y00">Значение y в х0</param>
        /// <param name="y01">Значение y` в х0</param>
        /// <returns></returns>
        private void ModifedEulerMethod(Func<double, double[], double[]> f, double x0, double h, int n, double y00,
            double y01)
        {
            double[] y = { y00, y01 };
            double[] _y = new double[2];

            for (var i = 0; i < n; i++)
            {
                double x = x0 + i * h;
                double[] dy = f(x, y);  

                for (int j = 0; j < 2; j++)
                {
                    chart1.Series[j].Points.AddXY(x, y[j]);
                }

                for (var j = 0; j < 2; j++)
                {
                    _y[j] = y[j] + h * dy[j];
                }

                double[] d_y = f(x + h, _y);

                for (int j = 0; j < 2; j++)
                {
                    y[j] = y[j] + h / 2 * (d_y[j] + dy[j]);
                }
            }
        }
    }
}
