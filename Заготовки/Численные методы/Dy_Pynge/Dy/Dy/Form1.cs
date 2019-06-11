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
            double xl = 50;
            double h = 0.1;
            double y0 = 1;
            double y1 = 0;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            Vector y = new Vector(new double[2] { y0, y1 });
            for (double x = x0; x <= xl; x+=h)
            {
                Vector k1;
                Vector k2;
                Vector k3;
                Vector k4;

                k1 = F(x, y);
                k2 = F(x + h / 2.0, y + h / 2.0 * k1);
                k3 = F(x + h / 2.0, y + h / 2.0 * k2);
                k4 = F(x + h, y + h * k3);

                y = y + (h / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);

                for (int i = 0; i < 2; i++)
                {
                    chart1.Series[i].Points.AddXY(x, y[i]);
                }
            }


        }
    }
}
