using System;
using System.Collections.Generic;
using System.Text;

namespace slau
{
    class podschet
    {
        double[,] matr_pod { get; set; }

        public podschet()
        {
            matr_pod = null;
        }

        public podschet(double[,] some)
        {
            matr_pod = new double[some.GetLength(0), some.GetLength(1)];
            for (int i = 0; i < some.GetLength(0); i++)
            {
                for (int j = 0; j < some.GetLength(1); j++)
                {
                    matr_pod[i, j] = some[i, j];
                }
            }
        }

        public double[] metod_kramera(double[,] matr, int n)
        {

            int i = 0;
            int j = 0;

            double[,] another = new double[n, n]; // osnovna9 matrica
            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    another[k, l] = matr[k, l];
                }
            }

            Square_Matrix sq_m = new Square_Matrix(another);


            double[] x = new double[another.GetLength(0)];//korni

            for (i = 0; i < n; i++)
            {
                
                Square_Matrix some = new Square_Matrix(another);
                for (j = 0; j < n; j++)
                {
                    some.arr[j, i] = matr[j, n];
                }
                x[i] = some.determinant(some.arr) / sq_m.determinant(sq_m.arr);
                x[i] = Math.Round(x[i], 3);
            }

            for (i = 0; i < n; i++)
            {
                Square_Matrix some = new Square_Matrix(another);
                for (j = 0; j < n; j++)
                {
                    some.arr[j, i] = matr[j, n];
                }
                x[i] = some.determinant(some.arr) / sq_m.determinant(sq_m.arr);
                x[i] = Math.Round(x[i], 3);
            }
            return x;
        }
    }
}
