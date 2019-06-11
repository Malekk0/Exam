using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Vector F(double x, Vector y)
        {
            double[] dy = new double[2];
            dy[0] = y[1];
            dy[1] = -y[0];
            return new Vector(dy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = 0.1;
            double xl = 100;
            double h = 0.1;
            double y0 = 1;
            double y1 = 0;
            int iter = 0;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            Vector nexty = new Vector(new double[2] { y0, y1 });
            Vector d1 = new Vector(2);
            Vector d2 = new Vector(2);
            Vector d3 = new Vector(2);
            Vector d4 = new Vector(2);
            for (double x = x0; x <= xl; x += h)
            {
                d4 = d3;
                d3 = d2;
                d2 = d1;
                d1 = F(x, nexty);

                if (iter > 2)
                    nexty = nexty + (h / 24.0) * (55 * d1 - 59 * d2 + 37 * d3 - 9 * d4);
                else
                    nexty = nexty + h * d1;

                AddChartXY(x, nexty);

                iter++;
            }
        }

        private void AddChartXY(double x, Vector y)
        {
            for (int i = 0; i < y.Length; i++)
                chart1.Series[i].Points.AddXY(x, y[i]);
        }
    }
}
