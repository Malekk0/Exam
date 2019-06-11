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
        double[,] XY;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Лагранж интерполяция
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

            for(double i = a; i <= b; i+= step)
            {
                chart1.Series[1].Points.AddXY(i, L(i, XY.GetLength(1)));
            }

        }

        private double L(double xx, int n)
        {
            double l = 0;
            for (int i = 0; i < n; i++)
            {
                double k = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;
                    k *= (xx - XY[0, j]) / (XY[0, i] - XY[0, j]);
                }
                l += k * XY[1, i];
            }
            return l;
        }
    }
}
