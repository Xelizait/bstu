using System;
using lab5;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lan6
{
    static class StackOfFigures
    {
        public static List<Figure> AllFigures = new List<Figure>();
        public static List<Figure> allFigures { get; set; }

        public static void Add(Figure figure)
        {
            AllFigures.Add(figure);
            Console.WriteLine("В список добавлен {0}", figure.Figurename);
        }

        public static Figure Remove(Figure figure)
        {
            foreach (Figure item in AllFigures)
            {
                if (figure == item)
                {
                    AllFigures.Remove(figure);
                    return figure;
                }
            }
            Console.WriteLine("Такой фигуры не существует");
            return null;
        }

        public static void ShowList()
        {
            Console.WriteLine("Полный список фигур: ");
            foreach (Figure figure in AllFigures)
            {
                Console.WriteLine($"Имя фигуры: {figure.Figurename}   |   Цвет: {figure.Color}   |   Площадь: {figure.FigureArea}");
            }
        }

    }


    partial class Controller : IComparer<Figure> // контоллер
    {
        public int Compare(Figure p1, Figure p2)
        {
            if (p1.Figurename.Length > p2.Figurename.Length)
                return 1;
            else if (p1.Figurename.Length < p2.Figurename.Length)
                return -1;
            else
                return 0;
        }


        public static List<Figure> SortByArea(List<Figure> figures)
        {
            Figure temp;
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = i + 1; j < figures.Count; j++)
                {
                    if (figures[i].FigureArea > figures[j].FigureArea)
                    {
                        temp = figures[i];
                        figures[i] = figures[j];
                        figures[j] = temp;
                    }
                }
            }

            return figures;
        }
    }
}

