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

namespace spline
{
    public partial class Form1 : Form
    {
        double[] Xi;
        double[] Fi;
        double[] h;
        //double[] S;
        const int l = 7;
        double[] d = new double[l];
        double[] a = new double[l];
        double[] b = new double[l];
        double[] c = new double[l];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //Кубическая интерполяция
        {
            Xi = new double[l];
            Fi = new double[l];
            h = new double[l];

            chart1.Series.Clear();
            chart1.Series.Add("График");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add("FFF");
            chart1.Series[1].ChartType = SeriesChartType.Point;

            for (int i = 0; i < l; i++)
                Xi[i] = i;

            Fi[0] = 4.1;
            Fi[1] = 2.4;
            Fi[2] = 3.0;
            Fi[3] = 4.3;
            Fi[4] = 3.6;
            Fi[5] = 5.2;
            Fi[6] = 5.9;

            //Build h
            for (int i = 1; i < l; i++)
                h[i] = Xi[i] - Xi[i - 1];

            //fill ACB|F
            double[] A = new double[l];
            double[] C = new double[l];
            double[] B = new double[l];
            double[] F = new double[l];
            for (int i = 1; i < l; i++)
            {
                A[i] = h[i];
            }
            for(int i = 1; i < l - 1; i++)
            {
                C[i] = 2 * (h[i] + h[i + 1]);
                B[i] = h[i + 1];
                F[i] = 6 * ((Fi[i + 1] - Fi[i]) / h[i + 1] - (Fi[i] - Fi[i - 1]) / h[i]);
            }
            c = pr(A, C, B, F);
            for (int i = 0; i < l; i++)
            {
                chart1.Series[1].Points.AddXY(Xi[i], Fi[i]);
            }
            Findabd();
            for (double x = Xi[0] - 1; x <= Xi[l - 1] + 1; x += 0.01)
            {
                double s = FindS(x);
                chart1.Series[0].Points.AddXY(x, s);
            }
        }

        double FindS(double xx)
        {
            double[] S = new double[l];
            for (int i = 1; i < l; i++)
            {
                S[i] = a[i] + b[i] * (xx - Xi[i]) + (c[i] * (xx - Xi[i]) * (xx - Xi[i])) / 2 + (d[i] / 6) * (xx - Xi[i]) * (xx - Xi[i]) * (xx - Xi[i]);
            }
            int k = 1;
            for (int i = 0; i < l - 1; i++)
                if (Xi[k] < xx)
                    k++;
                else
                    break;
            if (k >= l)
                k = l - 1;

            return S[k];
        }

        void Findabd()
        {
            for (int i = 1; i < l; i++)
                a[i] = Fi[i];

            for (int i = 1; i < l; i++)
            {
                d[i] = (c[i] - c[i - 1]) / h[i];
                b[i] = (Fi[i] - Fi[i - 1]) / h[i] + h[i] * (2 * c[i] + c[i - 1]) / 6;
            }
        }

        double[] pr(double[] A, double[] C, double[] B, double[] F) //Прогонка
        {
            double[] alpha = new double[l];
            double[] beta = new double[l];
            alpha[1] = -B[1] / C[1];
            beta[1] = F[1] / C[1];
            for (int i = 1; i < l-1; i++)
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
