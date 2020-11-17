using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8
{

    interface IGeneric<Type>
    {
        void Add(Type item);
        Type Delete(int item);
        void Check();
    }


   public class CollectionType<Type> : IGeneric<Type> where Type:class
    {
        public  List<Type> passwords = new List<Type>();

        public void Add( Type item)
        {
            passwords.Add(item);
        }

        public Type Delete(int item)
        {
            Type value = passwords[item] ;
            passwords.RemoveAt(item);
            return value;            
        }

        public void Check()
        {
            int count = 0;
            foreach (Type item in passwords)
            {
                count++;
                Console.WriteLine($"Элемент списка под номером {count}\nТип: {item.GetType()}");
                Console.WriteLine();
            }          

        }

        public void WriteToFile()
        {
            StreamWriter f = null;
            try
            {
                f = new StreamWriter("X://Проекты Visual Studio//repos//лаба8//лаба8.txt", false, Encoding.Default);
                foreach (Type t in passwords)
                {
                    f.WriteLine("apappapppsppaldlas;da;ls");
                }
            }
            finally
            {
                f.Close();
            }
        }

        public void ReadFromFile()
        {
            StreamReader s = null;
            try
            {
                s = new StreamReader("X://Проекты Visual Studio//repos//лаба8//лаба8.txt");
                int counter = 0;

                foreach (string str in File.ReadAllLines("X://Проекты Visual Studio//repos//лаба8//лаба8.txt"))
                {
                    counter++;
                }

                Console.WriteLine(counter);
                string[] arr = new string[counter];
                for (int i = 0; i < counter; i++)
                {
                    arr[i] = s.ReadLine();
                }
            }
            finally
            {
                s.Close();
            }
        }
    }



    public class StandartTypes<Type1, Type2, Type3> where Type1 : struct where Type2 : struct where Type3 : struct
    {
        Type1 A { get; set; }
        Type2 B { get; set; }
        Type3 C { get; set; }

        public StandartTypes(Type1 A, Type2 B, Type3 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public void ShowTypes()
        {
            Console.WriteLine($"Первый тип {A.GetType()} его значение {A}");
            Console.WriteLine($"Второй тип {B.GetType()} его значение {B}");
            Console.WriteLine($"Третий тип {C.GetType()} его значение {C}");
        }
    }

    


    class Program
    {
        static void Main(string[] args)
        {
            Password password1 = new Password();
            Console.WriteLine("Введите пароль:");
            password1.Parol = Console.ReadLine();

            Password password2 = new Password();
            Console.WriteLine("Введите второй пароль:");
            password2.Parol = Console.ReadLine();

            Password password3 = new Password();
            Console.WriteLine("Введите третий пароль:");
            password3.Parol = Console.ReadLine();

            Password password4 = new Password();
            Console.WriteLine("Введите четвёртый пароль:");
            password4.Parol = Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------");

            CollectionType<Password> myCollection = new CollectionType<Password>();
            myCollection.Add(password1);
            myCollection.Add(password2);
            myCollection.Add(password3);
            myCollection.Add(password4);
            myCollection.Check();

            Console.WriteLine("--------------------------------------------------------");

            bool exept = false;
            try
            {
                Password giveMe = myCollection.Delete(2);
                Console.WriteLine($" Извлечённый пароль {giveMe.Parol}");
                myCollection.Check();
            }
           
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.Source);
                exept = true;
            }
            finally
            {
                if(exept)
                {
                    Console.WriteLine("Исключение обработано");
                }
                else
                {
                    Console.WriteLine("Исключение не обработано либо не произошло");
                }
            }

            Console.WriteLine("--------------------------------------------------------");

            bool exept2 = false;
            try
            {
                StandartTypes<int, double, byte> myTypes = new StandartTypes<int, double, byte>(1234, 123.4, 8); // обобщение для проверки типов
                myTypes.ShowTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.Source);
                exept2 = true;
            }
           finally
            {
                if (exept2)
                {
                    Console.WriteLine("Исключение обработано");
                }
                else
                {
                    Console.WriteLine("Исключение не обработано либо не произошло");
                }

            }

            myCollection.WriteToFile();

            Console.ReadKey();

        }

    }

    //-------------------------------------------------------дальше переопределения и глупые методы---------------

    public class Password // переопределение
    {
        string parol;
        public string Parol
        {
            get { return parol; }
            set { parol = value; }
        }

        public string this[string str]
        {
            set
            {
                parol = value;
            }
            get
            {
                return parol;
            }

        }

        public static Password operator -(Password p1, char symbol)
        {
            int a = p1.Parol.Length - 1;
            string str = p1.Parol;
            str = str.Replace(str[a], symbol);

            return new Password { Parol = str };
        }
        public static bool operator >(Password p1, Password p2)
        {
            if (p1.Parol.Length > p2.Parol.Length)
                return true;
            else if (p1.Parol.Length == p2.Parol.Length)
                return false;
            else return false;


        }
        public static bool operator <(Password p1, Password p2)
        {
            if (p1.Parol.Length < p2.Parol.Length)
                return true;
            else if (p1.Parol.Length == p2.Parol.Length)
                return false;
            else return false;
        }
        public static bool operator !=(Password p1, Password p2)
        {
            if (p1.Parol != p2.Parol)
                return true;
            else
                return false;
        }
        public static bool operator ==(Password p1, Password p2)
        {
            if (p1.Parol == p2.Parol)
                return true;
            else
                return false;

        }
        public static Password operator ++(Password p1)
        {
            Console.WriteLine("Вызвана команда сброса пароля на значение по умолчанию");
            p1.Parol = "1111";
            return p1;
        }
        public static bool operator true(Password p1)
        {

            return p1.Parol.Length >= 10;
        }
        public static bool operator false(Password p1)
        {

            return p1.Parol.Length < 10;
        }
    }


    public static class lengthAndMedium
    {
        public static char srSymbol(this Password password)
        {
            char sr = password.Parol[password.Parol.Length / 2 - 1];
            return sr;

        }

        public static bool normalLength(this Password password)
        {
            if (password.Parol.Length < 6 || password.Parol.Length > 12)
                return false;
            else
                return true;
        }

    }

  

    public static class StatiсClass
    {
        static public int ShowLength(Password password)
        {
            return password.Parol.Length;
        }

        static public int Difference(Password password1, Password password2)
        {
            return Math.Abs(password1.Parol.Length - password2.Parol.Length);
        }

        static public int Sum(Password password1, Password password2)
        {
            return password1.Parol.Length + password2.Parol.Length;
        }
    }
    public static class StatisticOperation
    {
        public static int HowManyA(this string str)
        {
            int a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                    a++;
            }

            return a;

        }

        public static string Add(this string str)
        {
            str = str + Console.ReadLine();
            return str;
        }

        public static Password ChangePassword(this Password password)
        {
            password.Parol = Console.ReadLine();
            return password;
        }
    }



}

