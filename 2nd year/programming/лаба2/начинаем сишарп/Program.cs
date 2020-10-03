using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace начинаем_сишарп
{
    class Program
    {
        static void Main()
        {
            byte b = 120; // 1a
            sbyte sb = -8;
            bool logic = true;
            short s = -1;
            ushort us = 1;
            int i = -1;
            uint ui = 1;
            long l = -123;
            ulong ul = 123;
            double d = 1.23;
            float f = 1.23f;
            decimal de = 1.23m;
            char c = 'a';
            string st = "Антон Литягин супер пупер чел";
            object o = 3u;

            l = ui; // 1b
            i = s;
            de = s;
            o = sb;
            d = s;
            i = (int)ui;
            l = (long)ul;
            f = (float)d;
            b = (byte)sb;
            s = (short)us;
            bool boool = Convert.ToBoolean(2);

            int intt = 1; // 1c
            object obj = intt;
            intt = (int)obj;

            var ok = 123; // 1d
            intt = ok;

            Nullable<uint> nol = null; // 1e
            Console.Write(nol);

            // var hello = 0; // 1f
            // hello = 1.23f; // нет преобразования

            char s1 = 's', s2 = 's'; // 2a
            if (s1 == s2) Console.WriteLine("Литералы равны!!!");

            string ss1 = "hhhhh", ss2 = "iiiiiiiii", ss3 = "ooo"; // 2b
            Console.WriteLine(ss1 + ss2);
            ss1 = ss1.Substring(4);
            ss2 = ss2.Insert(7, ss1);
            Console.WriteLine(ss1);
            string ss4 = "Коля Бовкун легенда";
            string[] names = ss4.Split(' ');
            Console.WriteLine($"ss3: {ss3}");
          

            string empty = "", empty0 = null; // 2c
            Console.WriteLine(string.IsNullOrEmpty(empty));
            Console.WriteLine(string.IsNullOrEmpty(empty0));
            Console.WriteLine(string.IsNullOrEmpty(ss1));

            StringBuilder build = new StringBuilder("Hello World!!"); // 2d
            build.Remove(2, 3);
            Console.WriteLine(build);
            build.Insert(7, "____");
            Console.WriteLine(build);

            int[,] matrix = { { 1, 2 }, { 3, 4 }, { 5, 6 } }; // 3a

            int rows = matrix.GetUpperBound(0) + 1; // индекс последнего элемента
            int columns = matrix.Length / rows;
            for (int ii = 0; ii < rows; ii++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[ii, j]} \t");
                }
                Console.WriteLine();
            }

            string[] days = { "Mon", "Tue", "Wed", "Thi", "Fri", "Sat", "Sun" }; // 3b
            for (int iii = 0; iii < days.Length; iii++) Console.WriteLine("Day[{0}] = {1}", iii, days[iii]);

            int[][] nums = new int[3][]; // 3c
            nums[0] = new int[2] { 1, 2 }; 
            nums[1] = new int[3] { 1, 2, 3 };     
            nums[2] = new int[4] { 1, 2, 3, 4};

            var not = new[] { 1, 2, 3, 4, 5 }; // 3d

            (int,string,char,string,ulong) kortej = (1, "hello", 'a', "world", 123); // 4a

            Console.WriteLine("элемент 1: {0}", kortej.Item1); // 4b
            Console.WriteLine("элемент 2: {0}", kortej.Item2);
            Console.WriteLine("элемент 3: {0}", kortej.Item3);
            Console.WriteLine("элемент 4: {0}", kortej.Item4);
            Console.WriteLine("элемент 5: {0}", kortej.Item5);

            int r1 = 1; // 4c
            string r2 = "wow";
            char r3 = 'o';
            string r4 = "ohoho";
            ulong r5 = 12;
            (r1, r2, r3, r4, r5) = kortej;

            (int, string, char, string, ulong) kortej1 = (1, "hello", 'b', "world", 123); // 4d
            if (kortej == kortej1) Console.WriteLine("Кортежи равны!"); else Console.WriteLine("Кортежи не равны!");


            (int, int, int, char) localfunc(int[] massiv, string stroka) // 5
            {
                int maxx = massiv.Max();
                int minn = massiv.Min();
                int summ = massiv.Sum();
                char simm = stroka.First();
                return (maxx, minn, summ, simm);
            }
            int[] massiv1 = { 1, 2, 5, 3, 4 };
            string stroka1 = "OH WOW!";
            Console.WriteLine(localfunc(massiv1, stroka1));

            int func_checked() // 6
            {
                checked
                {
                    int q = int.MaxValue;
                    try
                    {                   
                        return q+1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("переполнение");
                        return q;
                    }
                }
            }
            int func_unchecked()
            {
                unchecked
                {
                    int q = int.MaxValue;
                    try
                    {
                        return q+1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("переполнение");
                        return q;
                    }
                }
            }
            Console.WriteLine(func_checked());
            Console.WriteLine(func_unchecked());

            Console.ReadKey();
        }
    }
}
