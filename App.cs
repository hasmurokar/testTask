using System;
using System.Collections.Generic;
using System.Linq;
using testTask.Shapes;

namespace testTask
{
    class App
    {
        public static List<Shape> shapeList = new();
        /// <summary>
        /// Запуск приложения
        /// </summary>
        public void Run()
        {
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
                        Console.WriteLine();
                        shapeList.Add(Polygon.InputPolygon());
                        break;
                    case ConsoleKey.C:
                        shapeList.Add(Circle.InputCircle());
                        break;
                    case ConsoleKey.F:
                        Console.WriteLine();
                        ShapeMethods.PerimetrAndArea();
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine();
                        FileManager.SaveFile(shapeList);
                        break;
                    case ConsoleKey.O:
                        Console.WriteLine();
                        FileManager.LoadFile(shapeList);
                        break;
                    case ConsoleKey.Z:
                        Console.WriteLine();
                        ShapeMethods.OutputShapes();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("\nВы ввели неверную букву.");
                        break;
                }
            }

        }
    }
}

