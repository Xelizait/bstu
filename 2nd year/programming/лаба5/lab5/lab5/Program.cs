using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {

            Ellipse ellipse1 = new Ellipse("Эллипс1", 123123, 100, "Голубой");
            Checkbox checkbox1 = new Checkbox("Чекбокс1", 145145, 150, "Серый", 150, true);
            Rectangle rectangle1 = new Rectangle("Прямоугольник1", 789789, 220, "Розовый", 125);
            Radiobutton radiobutton1 = new Radiobutton("Радиокнопка1", 159159, 300, "Черный", false);

            radiobutton1.Clone();                   // вызов метода у класса
            ((Ialive)radiobutton1).Clone();         // вызов метода у интерфейса

  





            Console.WriteLine(checkbox1.ToString());

            Printer printer = new Printer();
            printer.IAmPrinting(radiobutton1);

            Console.WriteLine("_________________________ВЫВОД ЭЛЕМЕНТОВ ЧЕРЕЗ МАССИВ________________________");
            Console.WriteLine("-------------------------------------");
            Figure[] allfigures = new Figure[] { ellipse1, checkbox1, rectangle1, radiobutton1 };
            for (int i = 0; i < allfigures.Length; i++)
            {
                printer.IAmPrinting(allfigures[i]);
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("______________________________________________________________________________");

            GenFigure<Figure>.Func(rectangle1);

            Console.ReadKey();
        }
    }
}

