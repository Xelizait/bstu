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

            
            return a.arr;
        }
    }



}

