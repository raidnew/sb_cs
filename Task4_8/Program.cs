using System;

namespace Task4_8
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            /*
            Matrix test = new Matrix(5,3);
            test.completeRandomData();
            Console.Write(test.toString());
            Console.Write(test.summ());
            Console.WriteLine();

            Matrix test2 = new Matrix(5,3);
            test2.completeRandomData();
            Console.Write(test2.toString());

            Console.WriteLine();
            Matrix test3 = test + test2;
            Console.Write(test3.toString());
            */
            GameOgLife test = new GameOgLife();
        }
    }

    class Matrix
    {
        private uint width, height;
        private int[,] data;
        
        public Matrix(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            data = new int[height,width];
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.width != matrix2.width || matrix1.height != matrix2.height) return null;
            Matrix result = new Matrix(matrix1.width, matrix1.height);
            for (int i = 0; i<result.height;i++)
            {
                for (int j = 0;j<result.width; j++)
                {
                    result.data[i, j] = matrix1.getData(j, i) + matrix2.getData(j, i);
                }
            }
            return result;
        }

        public int getData(int x, int y)
        {
            return this.data[y, x];
        }
        
        public void completeRandomData()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i<this.height;i++)
            {
                for (int j = 0;j<this.width; j++)
                {
                    this.data[i,j] = rnd.Next(-100, 100);
                }
            }
        }

        public long summ()
        {
            long summ = 0;
            foreach (int value in this.data)
            {
                summ += value;
            }

            return summ;
        }

        public string toString()
        {
            string retString = "";
            int index = 0;
            foreach (int value in this.data)
            {
                index++;
                retString += $"{value}";
                if (index % this.width == 0) retString += "\n";
                else retString += " ";
            }

            return retString;
        }
    }
}