using System;


namespace ClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] mas = new int[n, n];
            for (int m = 0; m < n; m++)
            {
                for (int l = 0; l < n; l++)
                {
                    mas[m, l] = rnd.Next(-1000, 1000);
                    Console.Write(mas[m, l] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(Result(mas, n));

        }
        public static int Result(int[,] mas, int n)
        {
            int max = mas[0, 0];
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                if (mas[i, i] > max)
                {
                    max = mas[i, i];
                    res = i + 1;
                }
            }
            return res;
        }
    }
}
