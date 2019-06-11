using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int size = 3;
            double[,] matrixA = new double[size, size];
            double[] matrixB = new double[size];

            InputInMatrix(matrixA, matrixB, size);

            SolveMatrix(matrixA, matrixB, size);

            ShowMatrix(matrixA, matrixB, size);

            Solution(matrixA, matrixB, size);
        }

        public void SwapRow(int k, double[,] matrixA, double[] matrixB, int size)
        {
            int max = k;
            double c;

            for (int i = k + 1; i < size; i++)
                if (Math.Abs(matrixA[max, k]) < Math.Abs(matrixA[i, k]))
                    max = i;

            if (max == k) return;
            for (int i = 0; i < size; i++)
            {
                c = matrixA[k, i];
                matrixA[k, i] = matrixA[max, i];
                matrixA[max, i] = c;
            }

            c = matrixB[k];
            matrixB[k] = matrixB[max];
            matrixB[max] = c;
        }

        public double[] Solution(double[,] matrixA, double[] matrixB, int size)
        {
            double[] X = new double[size];

            for (int i = 0; i < size; i++)
            {
                X[i] = matrixB[i] / matrixA[i,i];
            }
            //Show
            label2.Text = "";
            for (int i = 0; i < X.Length; i++)
            {
                label2.Text += String.Format("x{0} = {1:0.##}; ", (i + 1), X[i]);
            }
            //
            return X;
        }

        public void SolveMatrix(double[,] matrixA, double[] matrixB, int size)
        {
            for (int k = 0; k < size - 1; k++)
            {
                SwapRow(k, matrixA, matrixB, size);
                if (matrixA[k, k] == 0) continue; //Если не удалось найти в столбце элемент != 0

                for (int i = k + 1; i < size; i++)
                {
                    double c = matrixA[i, k] / matrixA[k, k];

                    for (int j = k; j < size; j++)
                    {
                        matrixA[i, j] -= matrixA[k, j] * c;
                    }
                    matrixB[i] -= matrixB[k] * c;
                }
            }
            
            for (int k = size - 1; k > 0; k--)
            {
                //SwapRow(k, matrixA, matrixB, size);
                if (matrixA[k, k] == 0) continue;

                for (int i = k - 1; i >= 0; i--)
                {
                    double c = matrixA[i, k] / matrixA[k, k];

                    for (int j = k; j >= 0; j--)
                    {
                        matrixA[i, j] -= matrixA[k, j] * c;
                    }
                    matrixB[i] -= matrixB[k] * c;
                }
            }
            
        }

        public void InputInMatrix(double[,] matrixA, double[] matrixB, int size)
        {
            for (int i = 0; i < size * size; i++)
                matrixA[i / size, i % size] = Convert.ToDouble(this.Controls["textBox" + (i + 1)].Text);

            for (int i = size * size; i < size * (size + 1); i++)
                matrixB[i - (size * size)] = Convert.ToDouble(this.Controls["textBox" + (i + 1)].Text);
        }

        public void ShowMatrix(double[,] matrixA, double[] matrixB, int size)
        {
            label1.Text = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    label1.Text += String.Format("{0:0.##}   ", matrixA[i, j]);

                label1.Text += String.Format(" = {0:0.##};\n", matrixB[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
