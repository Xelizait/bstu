using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    




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






    public static class GenFigure<Type> where Type : Figure
    {

        public static void Func(Type figure)
        {
            Console.WriteLine($"Фигура: {figure.Figurename}");
            Console.WriteLine($"Ширина: {figure.Width}");
            Console.WriteLine($"Высота: {figure.Heigth}");
        }

    }

 





}
