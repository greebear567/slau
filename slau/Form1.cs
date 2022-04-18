

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace slau
{

    public partial class Form1 : Form
    {

        public NumericUpDown[,] elements { get; set; }
        public Label[,] labelx { get; set; }

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(numericUpDown2.Value.ToString());
            double[,] matr = new double[n, n+1];
            elements = new NumericUpDown[n, n + 1];
            labelx = new Label[n, n ];

            for (int i = 0; i < numericUpDown2.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value+1; j++)
                {
                    elements[i, j] = new NumericUpDown();
                    elements[i, j].Size = new System.Drawing.Size(50,100);
                    elements[i, j].Location = new System.Drawing.Point(12+j*95, 100 + i * 50);
                    elements[i, j].Name = $"shtoto{i + j}";
                    elements[i, j].DecimalPlaces = 2;
                    elements[i, j].Value = 0;
                    elements[i, j].Text = "";
                    if (j < n)
                    {
                        labelx[i,j] = new Label();

                        labelx[i,j].Size = new System.Drawing.Size(40, 50);
                        labelx[i, j].Location = new System.Drawing.Point(65 + j * 95, 100 + i * 50);
                        labelx[i, j].Text = j < n - 1 ? $"*x{j + 1}+" : $"*x{j + 1}=";
                        labelx[i, j].Name = $"{i * 10 + j * 50}";
                        Controls.Add(labelx[i, j]);

                    }
                    Controls.Add(elements[i, j]);

                }
            }
            button1.Visible = false;
            
            Console.WriteLine(matr);
        }




        //void gaus(double [,] matr)
        //{
        //    for(int i = 1; i < matr.GetLength(0); i++)
        //    {
        //        double shtoto;
        //        for(int j = 0; j < matr.GetLength(1); j++)
        //        {
        //            shtoto = matr[i - 1, i]/matr[i,i];
        //            matr[i, j] = shtoto*matr[i, j] - matr[i - 1, j];
        //        }
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(numericUpDown2.Value.ToString());
            double[,] matr = new double[n,n+1];
            int i = 0;
            int j = 0;
            foreach (var nup in Controls.OfType<NumericUpDown>())
            {
                if (nup.Name == "numericUpDown2") continue;
                matr[i, j] = double.Parse(nup.Value.ToString());
                j++;
                if (j == n + 1)
                {
                    i++;j = 0;
                }
            }

            double[,] another = new double[n, n]; // osnovna9 matrica
            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    another[k, l] = matr[k, l];
                }
            }


            Square_Matrix sq_m = new Square_Matrix(another);
            if (sq_m.determinant(sq_m.arr) == 0)
            {
                if ((MessageBox.Show("Программа не умеет решать такие системы", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)) == DialogResult.OK)
                {
                    foreach(var nup in elements)
                    {
                        if (nup.Name == "numericUpDown2") continue;
                        this.Controls.Remove(nup);
                        //foreach (var nup1 in Controls.OfType<NumericUpDown>())
                        //{
                        //    if (nup1.Name == "numericUpDown2") continue;
                        //    this.Controls.Remove(nup1);
                        //}

                    }
                    foreach (var nup1 in labelx)
                    {
                        if (nup1.Name == "lab") continue;
                        this.Controls.Remove(nup1);
                    }
                    
                }
            }
            else
            {
                double[] x = new double[n]; // korni

                podschet shtoto = new podschet();
                x = shtoto.metod_kramera(matr, n);

                Label label2 = new Label()
                {
                    Text = "Корни:",
                    Location = new Point(200, 32)
                };
                Controls.Add(label2);
                for(i = 0; i < x.Length; i++)
                {
                    Label label1 = new Label()
                    {
                        Text = i != x.Length - 1 ? $"{x[i]};" : $"{x[i]}",
                        Location = new Point(30*i+300, 32),
                        TabIndex = 10,
                        AutoSize=true
                    };
                    Controls.Add(label1);
                }
            }
            button1.Visible = true;
        }

        private void numericUpDown2_Enter(object sender, EventArgs e)
        {
            numericUpDown2.Select(0, numericUpDown2.Text.Length);
        }
    }
}

