using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace лаб4
{

    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Введите размер массива 1:");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите {0}-й элемент массива 1: ", i + 1);
                a[i] = int.Parse(Console.ReadLine());
            }
            Massive aa = new Massive(a);

            Console.WriteLine("--------------------------------------------------------------------------------------");

            int[] b = new int[n];

            Console.WriteLine("Введите новый массив 2 размером {0} для сравнения с первым:", n); // проверяем равенство массивов
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите {0}-й элемент массива 2: ", i + 1);
                b[i] = int.Parse(Console.ReadLine());
            }
            Massive bb = new Massive(b);
            if (aa == bb)
                Console.WriteLine("Массив 1 равен массиву 2");
            else Console.WriteLine("Массив 1 не равен массиву 2");

            Console.WriteLine("--------------------------------------------------------------------------------------");

 int check;
            Console.WriteLine("Введите число, которое хотите найти в массиве 1: "); // ищем элемент check в массиве a
            check = int.Parse(Console.ReadLine());
            if (aa > check) Console.WriteLine("Элемент {0} присутствует в массиве 1!", check);
            else Console.WriteLine("Элемент {0} не существует в массиве 1!", check);

            Console.WriteLine("--------------------------------------------------------------------------------------");

int minus;
            Console.WriteLine("Введите число, которое хотите вычесть от всех элементов массива 1: "); // вычитаем элемент minus из массива 1
            minus = int.Parse(Console.ReadLine());
            int[] gov = new int[n];
            gov = aa - minus;
            Console.WriteLine("Итоговый массив 1: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} ", gov[i]);
            }

            Console.WriteLine("--------------------------------------------------------------------------------------");

Console.WriteLine("Объединяем массивы 1 и 2: "); // объединяем массивы 1 и 2
            int[] gov2 = new int[n];
            gov2 = aa + bb;
            Console.WriteLine("Итоговый массив (1 + 2): ");
            for (int i = 0; i < gov2.Length; i++)
            {
                Console.WriteLine("{0} ", gov2[i]);
            }

            Console.WriteLine("--------------------------------------------------------------------------------------");




        }

    }

    // перегрузки

    public class Massive
    {
        Owner owner = new Owner(1780401, "Денис", "BSTU"); 

        public int[] arr, brr;
        public Massive(int[] a, int[] b)
        {
            arr = a;
            brr = b;
        }
        public Massive(int[] a)
        {
            arr = a;
        }

        public class Date // класс Date
        {
            private int day;
            private int month;
            private int year;
            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            public void getDate()
            {
                Console.WriteLine("Год:{0}\nМесяц:{1}\nДень:{2}\n", year, month, day);
            }
        }


        public static bool operator !=(Massive a, Massive b) // проверка массива на неравенство
        {
            bool result = a.arr.Equals(b.brr);
            if (result)
                return false;
            else
                return true;
        }

public static bool operator ==(Massive a, Massive b) // проверка массива на равенство
        {
            bool result = a.arr.Equals(b.brr);
            if (result)
                return true;
            else
                return false;
        }

public static bool operator >(Massive a, int check) // проверка на вхождение в массив
        {
            int flag = 0;
            for (int i = 0; i < a.arr.Length; i++)
            {
                if (a.arr[i] == check)
                    flag++;
            }
            if (flag != 0) return true;
            else return false;
        }

        public static bool operator <(Massive a, int check)
        {
            return false;
        }

        public static int[] operator -(Massive a, int minus) // разность по скаляру
        {
            int[] arr1 = a.arr;
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr1[i] - minus;
            }
            return arr1;
        }

public static int[] operator +(Massive a, Massive b) // объединение массивов
        {
            int[] conc = new int[a.arr.Length + b.brr.Length];
            for (int i = 0; i < a.arr.Length; i++)
            {
                conc[i] = a.arr[i];
            }
            for (int i = a.arr.Length, ii = 0; i < a.arr.Length + b.brr.Length; ii++, i++)
            {
                conc[i] = b.arr[ii];
            }
            return conc;
        }
    }

public class Owner
    {
        int id;
        string name;
        string org;

        public Owner(int id, string name, string org)
        {
            this.id = id;
            this.name = name;
            this.org = org;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Org
        {
            get { return org; }
            set { org = value; }
        }

        public void getInfo()
        {
            Console.WriteLine("ID:{0}\nИмя:{1}\nОрганизация:{2}", Id, Name, Org);
        }
    }



    public static class StatisticOperation
    {
        public static int HowManySpace(this string str) // первый метод расширения для строки (удалить пробелы) 
        {
            int a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    a++;
            }
            return a;
        }

public static string Add(this string str) // второй метод расширения для строки (добавить что-то к строке)
        {
            str = str + Console.ReadLine();
            return str;
        }

        public static string DeleteLetters(this string str) // третий метод расширения для строки (удалить гласные)
        {
            str = Regex.Replace(str, "EUIOAeuioa", "");
            return str;
        }

      public static int MaxMinusMin(this Massive a) // первый метод расширения для массива (разность между максимальным и минимальным)
        {
            int maxnum = -99999;
            for (int i = 0; i < a.arr.Length; i++)
            {
                if (a.arr[i] > maxnum)
                {
                    maxnum = a.arr[i];
                };
            }
            int minnum = 99999;
            for (int i = 0; i < a.arr.Length; i++)
            {
                if (a.arr[i] < minnum)
                {
                    minnum = a.arr[i];
                };
            }
            int res;
            res = maxnum - minnum;
            return res;
        }


        public static int Summa(this Massive a) // второй метод расширения для массива (сумма элементов)
        {
            int sum = 0;
            for (int i = 0; i < a.arr.Length; i++)
            {
                sum = sum + a.arr[i];
            }
            return sum;
        }

        public static int[] Delete5(this Massive a) // третий метод для расшииения массива (удаление первых пяти элементов)
        {
            int c = 0;

            List<int> temp1 = a.arr.ToList(); // пять раз удаляем нулевой элемент
            temp1.RemoveAt(c);
            a.arr = temp1.ToArray();

List<int> temp2 = a.arr.ToList();
            temp2.RemoveAt(c);
            a.arr = temp2.ToArray();

            List<int> temp3 = a.arr.ToList();
            temp3.RemoveAt(c);
            a.arr = temp3.ToArray();

            List<int> temp4 = a.arr.ToList();
            temp4.RemoveAt(c);
            a.arr = temp4.ToArray();

            List<int> temp5 = a.arr.ToList();
            temp5.RemoveAt(c);
            a.arr = temp5.ToArray();


            
            return a.arr;
        }
    }



}

