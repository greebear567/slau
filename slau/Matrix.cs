using System;
using System.Collections.Generic;
using System.Text;

namespace slau
{
    class Matrix
    {
        //поля и свойства
        public double[,] arr
        {
            get;
            set;
        }

        //конструкторы

        public Matrix(Matrix matr)
        {
            arr = matr.arr;
        }
        public Matrix()
        {
        }
        public Matrix(double[,] arr1)
        {
            arr = arr1;
        }

        public Matrix(int str, int sto)
        {
            arr = new double[str, sto];
            int k = 0;
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < sto; j++)
                {
                    arr[i, j] = k++;
                }
            }
        }

        //методы
        static public Matrix operator +(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr1.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        res[i, j] = matr1.arr[i, j] + matr2.arr[i, j];
                    }
                }
                return new Matrix(res);
            }
            else { throw new Exception("У матриц разная размерность(+)"); }
        }

        static public Matrix operator -(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr1.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        res[i, j] = matr1.arr[i, j] - matr2.arr[i, j];
                    }
                }
                return new Matrix(res);
            }
            else { throw new Exception("У матриц разная размерность(-)"); }
        }

        static public Matrix operator *(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr2.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++) //i - stroku matr1
                {
                    for (int h = 0; h < matr2.arr.GetLength(1); h++) // h - stolbci matr2
                    {
                        for (int j = 0; j < matr1.arr.GetLength(1); j++)
                        {
                            res[i, h] += matr1.arr[i, j] * matr2.arr[j, h];
                        }
                    }
                }
                return new Matrix(res);
            }
            else { throw new Exception("У матриц неправильные размерности(*)"); }
        }

        static public Matrix operator /(Matrix matr, double k)
        {
            if (k == 0) throw new Exception("Нельзя делить на ноль");
            double[,] res = new double[matr.arr.GetLength(0), matr.arr.GetLength(1)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(1); j++)
                {
                    res[i, j] = matr.arr[i, j] / k;
                }
            }
            return new Matrix(res);
        }

        static public Matrix operator ~(Matrix matr)
        {
            double[,] res = new double[matr.arr.GetLength(1), matr.arr.GetLength(0)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(1); j++)
                {
                    res[j, i] = matr.arr[i, j];
                }
            }
            return new Matrix(res);
        }

        //операторы сравнения на равенство 

        static public bool operator ==(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        if (matr1.arr[i, j] != matr2.arr[i, j]) return false;
                    }
                }
            }
            else return false;
            return true;
        }

        static public bool operator !=(Matrix matr1, Matrix matr2)
        {
            if (matr1 == matr2) { return false; } else return true;
        }

        public override int GetHashCode()
        {
            //double[,] matr = new double[arr.GetLength(0),arr.GetLength(1)];
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        matr[i, j] = arr[i, j].GetHashCode();
            //    }
            //}
            return arr.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == arr)
                return true;
            else return false;
        }

        public override string ToString()
        {
            StringBuilder matr = new StringBuilder();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    matr.Append($"{arr[i, j]} \t");
                }
                matr.Append("\n");
            }
            return matr.ToString();
        }
    }

    class Square_Matrix : Matrix
    {
        public Square_Matrix(Square_Matrix matr)
        {
            arr = matr.arr;
        }
        public Square_Matrix()
        {
            arr = new double[1, 1];
            arr[0, 0] = 0;
        }
        public Square_Matrix(Matrix matr)
        {
            if (matr.arr.GetLength(0) != matr.arr.GetLength(1)) throw new Exception("Матрица не квадратная");

            arr = new double[matr.arr.GetLength(0), matr.arr.GetLength(0)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(0); j++)
                {
                    arr[i, j] = matr.arr[i, j];
                }
            }
        }

        public Square_Matrix(int dim1)
        {
            arr = new double[dim1, dim1];
            int k = 0;
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    arr[i, j] = k++;
                }
            }
        }

        static public Square_Matrix operator ~(Square_Matrix matr) 
        {
            double[,] res = new double[matr.arr.GetLength(1), matr.arr.GetLength(0)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(1); j++)
                {
                    res[j, i] = matr.arr[i, j];
                }
            }
            return new Square_Matrix(res);
        }

        public Square_Matrix(double[,] matr)
        {
            if (matr.GetLength(0) != matr.GetLength(1)) throw new Exception("Матрица не квадратная(2)");
            arr = new double[matr.GetLength(0), matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    arr[i, j] = matr[i, j];
                }
            }
        }

        public double minor(double[,] matr, int num_sto, int num_str)
        {
            double[,] matr_1 = new double[matr.GetLength(0) - 1, matr.GetLength(0) - 1];
            for (int i = 0; i < num_str; i++)
            {
                for (int j = 0; j < num_sto; j++)
                {
                    matr_1[i, j] = matr[i, j];
                }
                for (int j = matr.GetLength(0) - 1; j > num_sto; j--)
                {
                    matr_1[i, j - 1] = matr[i, j];
                }
            }
            for (int i = matr.GetLength(0) - 1; i > num_str; i--)
            {
                for (int j = 0; j < num_sto; j++)
                {
                    matr_1[i - 1, j] = matr[i, j];
                }
                for (int j = matr.GetLength(0) - 1; j > num_sto; j--)
                {
                    matr_1[i - 1, j - 1] = matr[i, j];
                }
            }
            return determinant(matr_1);
        }

        //double minor(double[,] matr,int num_sto,int dim)
        //{
        //    double[,] matr_1 = new double[dim,dim];
        //    for(int i = 1; i < dim+1; i++)
        //    {
        //        for(int j = 0; j < num_sto; j++)
        //        {
        //            matr_1[i-1, j] = matr[i,j];
        //        }
        //        for (int j = dim; j > num_sto; j--)
        //        {
        //            matr_1[i-1, j-1] = matr[i, j];
        //        }
        //    }
        //    return determinant(matr_1, dim);
        //}

        public double determinant(double[,] matr)
        {
            double result = 0;
            if (matr.GetLength(0) != 2)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    if (i % 2 == 0)
                    {
                        result += matr[0, i] * minor(matr, i, 0);
                    }
                    else
                    {
                        result -= matr[0, i] * minor(matr, i, 0);
                    }
                }
                return result;
            }
            else return matr[0, 0] * matr[1, 1] - matr[1, 0] * matr[0, 1];
        }
    }


    class Obr_Matr : Square_Matrix
    {
        public Obr_Matr(double[,] matr)
        {
            arr = new double[matr.GetLength(0), matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    arr[i, j] = matr[i, j];
                }
            }
        }
        public Obr_Matr(Square_Matrix matr)
        {
            arr = new double[matr.arr.GetLength(0),matr.arr.GetLength(0)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for(int j = 0; j < matr.arr.GetLength(0); j++)
                {
                    arr[i, j] = matr.arr[i, j];
                }
            }
        }

        public Obr_Matr(Matrix matr)
        {
            arr = matr.arr;
        }

        public Obr_Matr(Obr_Matr matr)
        {
            arr = matr.arr;
        }


        public Square_Matrix Obr()
        {
            Square_Matrix res = new Square_Matrix(arr.GetLength(0));
            if (res.determinant(arr) == 0) throw new Exception("Определитель равен 0");
            Matrix per2 = new Matrix(arr);
            per2 = ~per2;
            Square_Matrix tran = new Square_Matrix(per2);
            for (int i = 0; i < tran.arr.GetLength(0); i++)
            {
                for (int j = 0; j < tran.arr.GetLength(0); j++)
                {
                    res.arr[i, j] = minor(tran.arr, j, i) / determinant(arr) * Math.Pow(-1, i + j);
                }
            }
            return res;
        }
    }
}

