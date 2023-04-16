using System;

namespace SquareFigures
{
    abstract class Figure
    {
        public abstract double Square();
        public abstract override string ToString();
    }

    class Circle : Figure
    {
        double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public override double Square()
        {
            return Math.PI * r * r;
        }

        public override string ToString()
        {
            return $"Площадь круга = {Square()}";
        }
    }
    class Triangle : Figure
    {
        double a;
        double b;
        double c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Square()
        {
            if (a == b)
            {
                return a * b / 2;
            }
            else if(a == c)
            {
                return a * c / 2;
            }else if(b == c)
            {
                return b * c / 2;
            }
            else
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public override string ToString()
        {
            return $"Площадь треугольника = {Square()}";
        }
    }
    class Program
    {
        static void Menu()
        {
            int chooce = 0;
            do
            {
                Console.WriteLine("Выбери пункт в меню:\n" +
                    "1. Рассчитать площадь Круга\n" +
                    "2. Рассчитать площадь Треугольника\n" +
                    "3. Не хочу думать, посчитай сам что-то\n" +
                    "4. Выйти");
                chooce = Convert.ToInt32(Console.ReadLine());
                switch (chooce)
                {
                    case 1:
                        double r = 0;
                        while (r <= 0)
                        {
                            Console.Write("Введи радиус круга: ");
                            r = Convert.ToDouble(Console.ReadLine());
                            if (r <= 0)                            
                                Console.WriteLine("Вы ввели отрицательный радиус");
                            else
                            {
                                Circle circle = new Circle(r);
                                Console.WriteLine(circle);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        double a = 0;
                        double b = 0;
                        double c = 0;
                        while (a <= 0 || b <= 0 || c <= 0)
                        {
                            Console.Write("Введи сторону а: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введи сторону b: ");
                            b = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введи сторону c: ");
                            c = Convert.ToDouble(Console.ReadLine());
                            if (a <= 0 || b <= 0 || c <= 0)
                            {
                                Console.WriteLine("Вы указали сторону с отрицательным значением");
                            }
                            else
                            {
                                Triangle triangle = new Triangle(a, b, c);
                                Console.WriteLine(triangle);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        break;
                    case 3:
                        Figure[] figures =
                            {
                                new Circle(10),
                                new Triangle(10,7,7),
                                new Triangle(5,8,6)
                            };
                        foreach (var item in figures)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        break;
                }
            } while (chooce != 4);
            
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
