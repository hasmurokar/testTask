using System;
using System.Collections.Generic;
using testTask.Helper;
using testTask.Shapes;

namespace testTask
{
    public class App
    {
        /// <summary>
        /// Запуск приложения
        /// </summary>
        public static void Run() //Для обращения к методу из другого класса используется static
        {
            var shapeList = new List<Shape>();
            while (true)
            {
                Console.WriteLine("Добавить: квадрат(S), прямоугольник(R), треугольник(T), круг(C), многоугольник(А)\nПодсчитать площадь и периметр(F), Сохранить(U), Вывод фигур(Z), Выход(esc)\nЗагрузить файл(О)");
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
                    case ConsoleKey.A:
                        shapeList.Add(Polygon.InputPolygon());
                        break;
                    case ConsoleKey.C:
                        shapeList.Add(Circle.InputCircle());
                        break;
                    case ConsoleKey.F:
                        shapeList.GetPerimetrAndArea();
                        break;
                    case ConsoleKey.U:
                        shapeList.SaveFile<Shape>();
                        break;
                    case ConsoleKey.O:
                        shapeList.LoadFile();
                        break;
                    case ConsoleKey.Z:
                        Console.WriteLine();
                        OutputShapes(shapeList);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("\nВы ввели неверную букву.");
                        break;
                }
            }
        }
        /// <summary>
        /// Вывод списка фигур
        /// </summary>
        public static void OutputShapes(List<Shape> shapeList)
        {
            if (shapeList.Count == 0)
            {
                Console.WriteLine("\nСписок фигур пуст");
                return;
            }
            shapeList.ForEach(item => Console.WriteLine(item));
        }
    }
}

