using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Interp
{
    public partial class Form1 : Form
    {
        private double[,] XY;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("График1");
            chart1.Series.Add("График2");
            chart1.Series[0].ChartType = SeriesChartType.Point;
            chart1.Series[1].ChartType = SeriesChartType.Line;

            double step = Convert.ToDouble(textBox1.Text);
            double a = Convert.ToDouble(textBox2.Text);
            double b = Convert.ToDouble(textBox3.Text);

            XY = new double[dataGridView1.ColumnCount, dataGridView1.RowCount - 1];
            for (int i = 0; i < XY.GetLength(1); i++)
            {
                object e1 = dataGridView1.Rows[i].Cells[0].Value;
                object e2 = dataGridView1.Rows[i].Cells[1].Value;
                if (e1 == null || e2 == null)
                    break;
                XY[0, i] = Convert.ToDouble(e1);
                XY[1, i] = Convert.ToDouble(e2);
            }

            for (int i = 0; i < XY.GetLength(1); i++)
            {
                chart1.Series[0].Points.AddXY(XY[0, i], XY[1, i]);
            }

            //A
            double[,] xAndDeductions = new double[XY.GetLength(1), XY.GetLength(1) - 1 + 2];
            for (int i = 0; i < XY.GetLength(1); i++)
            {
                xAndDeductions[i, 0] = XY[0, i];
                xAndDeductions[i, 1] = XY[1, i];
            }

            for (int i = 2; i < xAndDeductions.GetLength(1); i++)
            {
                for (int j = 0; j < xAndDeductions.GetLength(0) - i + 1; j++)
                {
                    xAndDeductions[j, i] = (xAndDeductions[j + 1, i - 1] - xAndDeductions[j, i - 1]);
                }
            }


            /*
            for (int i = 2; i < A.GetLength(1); i++)
            {
                dataGridView1.Columns.Add("A", "a");
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = A[j, i];
                }
            }
            */

            for (double i = a; i <= b; i += step)
            {
                chart1.Series[1].Points.AddXY(i, P(i, xAndDeductions));

            }

        }

        private double P(double xx, double[,] A)
        {
            double p = 0;
            double dx = 1;
            int factorial = 1;
            double h = 1;

            for (int i = 1; i < A.GetLength(1); i++)
            {
                p += A[0, i] * dx / (h * factorial);
                if (i < A.GetLength(0))
                    dx *= xx - A[i - 1, 0];

                if (A.GetLength(0) > 1) //Считается факториал и шаг
                {
                    h *= A[1, 0] - A[0, 0];
                    factorial *= i;
                }
            }
            return p;
        }

    }
}
