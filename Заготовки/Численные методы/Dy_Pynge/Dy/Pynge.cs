namespace Dy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] F(double x, double[] y)
        {
            double[] dy = new double[2];
            dy[0] = y[1];
            dy[1] = -y[0];
            return dy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = 0.1;
            double xl = 50;
            double h = 0.5;
            double y0 = 1;
            double y1 = 0;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            double[] prevy = new double[2];
            prevy[0] = y0;
            prevy[1] = y1;
            for (double x = x0; x <= xl; x+=h)
            {
                double[] _y0 = new double[2];
                double[] k1;
                double[] k2;
                double[] k3;
                double[] k4;
                double[] y = new double[2];

                for (int i = 0; i < 2; i++)
                {
                    _y0[i] = prevy[i];
                    y[i] = prevy[i];
                }

                k1 = F(x, y);
                for (int i = 0; i < 2; i++)
                    y[i] = _y0[i] + h / 2.0 * k1[i];

                k2 = F(x + h / 2.0, y);
                for (int i = 0; i < 2; i++)
                    y[i] = _y0[i] + h / 2.0 * k2[i];

                k3 = F(x + h / 2.0, y);
                for (int i = 0; i < 2; i++)
                    y[i] = _y0[i] + h * k3[i];

                k4 = F(x + h, y);

                for(int i = 0; i < 2; i++)
                {
                    prevy[i] = _y0[i] + (h / 6.0) * (k1[i] + 2*k2[i] + 2*k3[i] + k4[i]);
                    chart1.Series[i].Points.AddXY(x, prevy[i]);
                }

                /*
                for (int i = 0; i < 2; i++)
                {
                    _y0[i] = prevy[i];
                    y[i] = _y0[i] + dy0[i] * h;
                }

                double[] dy1 = F(x + h, y);

                for (int i = 0; i < 2; i++)
                {
                    prevy[i] = _y0[i] + h * (dy0[i] + dy1[i]) / 2;
                    chart1.Series[i].Points.AddXY(x, prevy[i]);
                }
                */
            }


        }
    }
}