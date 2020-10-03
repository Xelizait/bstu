using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба3
{
    partial class Airline // инициализируем класс авиалиний
    {
        // назначаем параметры
        private readonly int id; // уникальный id для каждого рейса
        private string finish;
        private uint number;
        private string type;
        private string time;
        private string day;

        static int counterObj = 0; // статический конструктор

        static void classInfo()
        {
            Console.WriteLine(counterObj);
        }

        public Airline(string finish, uint number, string type, string time, string day)
        {

            this.finish = finish;
            this.number = number;
            this.type = type;
            this.time = time;
            this.day = day;
            counterObj++;
        }

        public Airline()
        {
        }

        //private Airline()
        //{
        //    Console.WriteLine("Закрытый конструктор");
        //}

        public int Id
        {
            get
            {
                if (id > 0) return id;
                else return 0;
            }
        }
        public string Finish
        {
            get { return finish; }
            set { finish = value; }
        }
        public uint Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Day
        {
            get { return day; }
            set { day = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество рейсов: ");
            sbyte counter = sbyte.Parse(Console.ReadLine());
            Console.WriteLine();
            Airline[] database = new Airline[counter];
            for (int i = 0; i < counter; i++)
            {
                database[i] = new Airline();

                Console.WriteLine("Введите пункт назначения рейса {0}: ", i + 1);
                database[i].Finish = Console.ReadLine();

                Console.WriteLine("Введите номер рейса {0}: ", i + 1);
                database[i].Number = uint.Parse(Console.ReadLine());

                Console.WriteLine("Введите тип рейса {0}: ", i + 1);
                database[i].Type = Console.ReadLine();

                Console.WriteLine("Введите время отправления рейса {0}: ", i + 1);
                database[i].Time = Console.ReadLine();

                Console.WriteLine("Введите день, в который курсирует рейс {0}: ", i + 1);
                database[i].Day = Console.ReadLine();

                Console.WriteLine();
            }

            Console.WriteLine("Введите пункт, в который хотите прилететь: "); // ищем рейс по пункту назначения
            string checkFinish = Console.ReadLine();
            bool flag1 = false;
            for (int i = 0; i < counter; i++)
            {
                if (database[i].Finish == checkFinish)
                {
                    Console.WriteLine("Найден рейс #{0}", database[i].Number);
                    flag1 = true;
                }
            }
            if (flag1 == false)
            {
                Console.WriteLine("Такого рейса нет :(");
            }

            Console.WriteLine();

            Console.WriteLine("Введите день недели, в который хотите полететь: "); // ищем рейс по дню недели
            string checkDay = Console.ReadLine();
            bool flag2 = false;
            for (int i = 0; i < counter; i++)
            {
                if (database[i].Day == checkDay)
                {
                    Console.WriteLine("Найден рейс #{0}", database[i].Number);
                    flag2 = true;
                }
            }
            if (flag2 == false)
            {
                Console.WriteLine("Такого рейса нет :(");
            }

            Console.WriteLine();

            Airline flight1 = new Airline("Берлин", 1941, "Грузовой", "23:45", "Суббота");
            Airline flight2 = new Airline("Берлин", 1941, "Грузовой", "23:45", "Понедельник");
            Console.WriteLine(flight1.GetHashCode());
            Console.WriteLine(flight1.GetType());
            Console.WriteLine(flight1.ToString());
            Console.WriteLine(flight1.Equals(flight2));

            var user = new { Name = "Денис", Age = 18 }; // анонимный тип
            Console.WriteLine(user.Name);

            Console.ReadKey();
        }
    }
}
