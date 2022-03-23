using System;
using System.Collections.Generic;
using System.Linq;

namespace testTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeList = new List<Shape>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Добавить: квадрат(S), прямоугольник(R), треугольник(T), круг(C)\nПодсчитать площадь и периметр(F), Выход(esc)");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        shapeList.Add(Square.InputSquare());
                        break;
                    case ConsoleKey.R:
                        shapeList.Add(Rectangle.InputRectangle());
                        break;
                    case ConsoleKey.T:
                        shapeList.Add(Triangle.InputTriangle());
                        break;
                    case ConsoleKey.C:
                        shapeList.Add(Circle.InputCircle());
                        break;
                    case ConsoleKey.F:
                        GetPerimetrAndArea(shapeList);
                        break;
                    case ConsoleKey.Escape:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nВы ввели неверную букву.");
                        break;
                }
            }

        }

        private static void GetPerimetrAndArea(List<Shape> list)
        {
            var totalPerimetr = 0.0;
            var totalArea = 0.0;
            foreach (var item in list)
            {
                totalArea += item.GetArea();
                totalPerimetr += item.GetPerimetr();
            }
            Console.WriteLine("\nОбщий периметр: " + Math.Round(totalPerimetr, 4));
            Console.WriteLine("Общая площадь: " + Math.Round(totalArea, 4));
            Console.WriteLine();
        }

    }
}
