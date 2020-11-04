using System;
using lan6;

namespace lab5
{
    interface IActionable
    {
        void Resize();
        void Show();
        void Input();
        void Move();
    }

    interface IAlive
    {
        void Clone();
    }

    public abstract class Figure : IActionable
    {
        protected string figurename;
        protected int width;
        protected int heigth;
        protected string color;
        protected int id;
        protected int figureArea;

        public int FigureArea
        {
            get { return figureArea; }
            set { figureArea = value; }
        }

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

        public override string ToString()
        {
            Console.WriteLine("Фигура: " + Figurename);
            Console.WriteLine("Ширина: " + Width);
            Console.WriteLine("Высота: " + Heigth);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("ID: " + Id);
            return " тип " + base.ToString();
        }

        virtual public bool ChangeWeapon(string newWeapon)
        {
            return true;
        }
        public abstract void Resize();
        public abstract void Show();
        public abstract void Input();
        public abstract void Move();
        public abstract void Clone();
    }

    public class Ellipse : Figure, IAlive
    {
        public Ellipse(string figurename, int id, int heigth, string color)
        {
            this.figurename = figurename;
            this.id = id;
            this.heigth = heigth;
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

        void IAlive.Clone()   // метод из интерсфейса 
        {
            Console.WriteLine("МЕТОД ИНТЕРФЕЙСА ОГО");
        }
    }
    public class Rectangle : Figure, IAlive
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
        void IAlive.Clone()
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

    public class Printer
    {
        public void IAmPrinting(Figure figure)
        {
            Console.WriteLine(figure.ToString());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Ellipse ellipse1 = new Ellipse("Продолговатый эллипс", 152415, 110, "Голубой");
            ellipse1.FigureArea = 50;

            Ellipse ellipse2 = new Ellipse("Сплюснутый эллипс", 965986, 70, "Фиолетовый");
            ellipse2.FigureArea = 80;

            Ellipse ellipse3 = new Ellipse("Маленький эллипс", 120120, 20, "Белый");
            ellipse3.FigureArea = 25;



            Radiobutton radiobutton1 = new Radiobutton("Радиокнопка большая", 456456, 150, "Серый", true);
            radiobutton1.FigureArea = 90;

            Radiobutton radiobutton2 = new Radiobutton("Радиокнопка средняя", 485485, 120, "Белый", true);
            radiobutton2.FigureArea = 60;

            Radiobutton radiobutton3 = new Radiobutton("Радиокнопка маленькая", 789456, 90, "Черный", false);
            radiobutton1.FigureArea = 30;



            Rectangle rectangle1 = new Rectangle("Огромный прямоугольник", 753756, 160, "Сиреневый", 125);
            rectangle1.FigureArea = 130;

            Rectangle rectangle2 = new Rectangle("Закругленный прямоугольник", 186123, 70, "Бирюзовый", 50);
            rectangle2.FigureArea = 50;

            Rectangle rectangle3 = new Rectangle("Перевернутый прямоугольник", 900102, 100, "Красный", 75);
            rectangle1.FigureArea = 80;



            Checkbox checkbox1 = new Checkbox("Дефолтный чекбокс", 152689, 30, "Белый", 30, false);
            checkbox1.FigureArea = 40;

            Checkbox checkbox2 = new Checkbox("Прямоугольный чекбокс", 196234, 40, "Черный", 30, true);
            checkbox2.FigureArea = 45;

            Checkbox checkbox3 = new Checkbox("Многоугольный чекбокс", 245900, 70, "Бежевый", 70, false);
            checkbox3.FigureArea = 60;

            StackOfFigures.Add(ellipse1);
            StackOfFigures.Add(radiobutton1);
            StackOfFigures.Add(rectangle1);
            StackOfFigures.Add(checkbox1);

            StackOfFigures.Add(ellipse2);
            StackOfFigures.Add(radiobutton2);
            StackOfFigures.Add(rectangle2);
            StackOfFigures.Add(checkbox2);

            StackOfFigures.Add(ellipse3);
            StackOfFigures.Add(radiobutton3);
            StackOfFigures.Add(rectangle3);
            StackOfFigures.Add(checkbox3);


            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("ВСЕ ФИГУРЫ И КНОПКИ: ");
            StackOfFigures.ShowList();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();

            int totalarea = Controller.FindTotal(StackOfFigures.AllFigures);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Сумма всех площадей: {0}", totalarea);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------------------");
            int indexOfBiggest = Controller.FindTheBiggest(StackOfFigures.AllFigures);
            Console.WriteLine("Самая большая фигура: {0}. Ее площадь: {1}.", StackOfFigures.AllFigures[indexOfBiggest].Figurename, StackOfFigures.AllFigures[indexOfBiggest].FigureArea);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------------------");
            Controller.SortByArea(StackOfFigures.AllFigures);
            Console.WriteLine("Отсортированные по площади фигуры:");
            StackOfFigures.ShowList();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();

            Console.ReadKey();
        }       
        }
    }

