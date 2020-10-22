using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{

interface Iactionable
    {
        void Resize();
        void Show();
        void Input();
        void Move();
    }

    interface Ialive
    {
        void Clone();
    }

    public abstract class Figure : Iactionable
    {
        protected string figurename;
        protected int width;
        protected int heigth;
        protected string color;
        protected int id;

        public string Figurename
        {
            get { return figurename; }
            set { figurename = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Heigth
        {
            get { return heigth; }
            set { heigth = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString() // переопределение ToString с выводом информации
        {
            Console.WriteLine("Фигура: " + Figurename);
            Console.WriteLine("Ширина: " + Width);
            Console.WriteLine("Высота: " + Heigth);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("ID: " + Id);
            return " тип " + base.ToString();
        }

        public abstract void Resize(); // реализация методов
        public abstract void Show();
        public abstract void Input();
        public abstract void Move();
        public abstract void Clone();
    }


    public class Ellipse : Figure, Ialive
    {
        public Ellipse(string figurename, int id, int height, string color)
        {
            this.figurename = figurename;
            this.id = id;
            this.heigth = height;
            this.color = color;
        }
        override public void Move() // реализуем методы из интерфейса
        {
            Console.WriteLine("Произошло передвижение фигуры!!!");
        }

        public override void Show()
        {
            Console.WriteLine("Фигура показалась!");
        }

        public override void Resize()
        {
            Console.WriteLine("Изменяем размер");
            heigth = 123;
            width = 123;
        }
        public override void Input()
        {
            Console.WriteLine("Вставка фигуры!");
        }

        public override void Clone() // метод из абстрактного класса 
        {
            Console.WriteLine("МЕТОД АБСТРАКТНОГО КЛАССА");
        }

        void Ialive.Clone()   // метод из интерсфейса 
        {
            Console.WriteLine("МЕТОД ИНТЕРФЕЙСА ОГО");
        }
    }

    public class Rectangle : Figure, Ialive
    {
        public Rectangle(string name, int id, int height, string color, int width)
        {
            this.figurename = name;
            this.id = id;
            this.heigth = height;
            this.color = color;
            this.width = width;
        }

        public override void Clone()
        {
            Console.WriteLine("МЕТОД АБСТРАКТНОГО КЛАССА");
        }
        void Ialive.Clone()
        {
            Console.WriteLine("МЕТОД ИНТЕРФЕЙСА ОГО");
        }
        override public void Move()
        {
            Console.WriteLine("Произошло перемещение фигуры!!!");
        }
        public override void Show()
        {
            Console.WriteLine("Фигура показалась!");
        }
        public override void Resize()
        {
            Console.WriteLine("Изменяем размер");
            heigth = 123;
            width = 123;
        }
        public override void Input()
        {
            Console.WriteLine("Вставка фигуры!");
        }     

    }

sealed public class Button : Rectangle
    {
        public bool PushedOrNot;
        public Button(string name, int id, int height, string color, int width, bool PushedOrNot) : base(name, id, height, color, width)
        {
            this.PushedOrNot = PushedOrNot;
        }
        public bool ToCheck()
        {
            if (PushedOrNot)
                return true;
            else
                return false;
        }
    }

    sealed public class Checkbox : Rectangle
    {
        public bool PushedOrNot;
        public Checkbox(string name, int id, int height, string color, int width, bool PushedOrNot) : base(name, id, height, color, width)
        {
            this.PushedOrNot = PushedOrNot;
        }
        public bool ToCheck()
        {
            if (PushedOrNot)
                return true;
            else
                return false;
        }
    }

    sealed public class Radiobutton : Ellipse
    {
        public bool PushedOrNot;
        public Radiobutton(string name, int id, int height, string color, bool PushedOrNot) : base(name, id, height, color)
        {
            this.PushedOrNot = PushedOrNot;
        }
        public bool ToCheck()
        {
            if (PushedOrNot)
                return true;
            else
                return false;
        }
    }






    public static class GenFigure<Type> where Type : Figure
    {

        public static void Func(Type figure)
        {
            Console.WriteLine($"Фигура: {figure.Figurename}");
            Console.WriteLine($"Ширина: {figure.Width}");
            Console.WriteLine($"Высота: {figure.Heigth}");
        }

    }

 public class forObject : Object // переопределение методов Object
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            return true; 
        }

        public string Name { get; set; }
        int sNumber;

        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + sNumber.GetHashCode();
            return hash;
        }

    }





}
