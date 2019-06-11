using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquationsSolve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double a = 2;
            double b = 4;
            double h = 0.1;

            for (double x = a; x <= b; x += h)
            {
                chart1.Series[0].Points.AddXY(x, f(x));
            }

            int iter;
            label1.Text = HalfDivisionMethod(a, b, 0.01, out iter).ToString();
            label1.Text = SecantMethod(a, b, 0.01, out iter).ToString();
            label1.Text = NewtonMethod(a, 0.01, out iter).ToString();
        }

        private double f(double x)
        {
            return Math.Sin(x);
        }

        private double DerF(double x) //Производная от f
        {
            return Math.Cos(x);
        }

        double HalfDivisionMethod(double a, double b, double e, out int iterationsCount)
        {
            double c = a;
            iterationsCount = 0;
            while (Math.Abs(a - b) > e)
            {
                c = (a + b) / 2.0;
                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;

                iterationsCount++;
            }
            return c;
        }

        double SecantMethod(double a, double b, double e, out int iterationsCount) //?
        {
            double c = a;
            iterationsCount = 0;
            while (Math.Abs(a - b) >= e && Math.Abs(f(c)) >= e)
            {
                double k = (f(b) - f(a)) / (b - a);
                double d = f(a) - k * a;

                c = -d / k;
                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;

                iterationsCount++;
            }
            return c;
        }

        double NewtonMethod(double a, double e, out int iterationsCount)
        {
            double x = a;
            iterationsCount = 0;
            do
            {
                a = x;
                x = a - f(a) / DerF(a); //derivative

                iterationsCount++;
            } while (Math.Abs(x - a) >= e);

            return x;
        }
    }
}
