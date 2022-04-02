using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testTask.Shapes;

namespace testTask
{
    class App
    {
        public static List<Shape> shapeList = new();

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Добавить: квадрат(S), прямоугольник(R), треугольник(T), круг(C), пятиугольник(А)\nПодсчитать площадь и периметр(F), Сохранить(U), Выход(esc)\nЗагрузить файл(О)");
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
                        TotalPerimetr();
                        TotalArea();
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine();
                        SaveFile();
                        break;
                    case ConsoleKey.O:
                        Console.WriteLine();
                        LoadFile();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("\nВы ввели неверную букву.");
                        break;
                }
            }

        }
        private static void TotalPerimetr()
        {
            Console.WriteLine("Периметр: " + shapeList.Sum(x => x.GetPerimetr()));
        }

        private static void TotalArea()
        {
            Console.WriteLine("Площадь: " + shapeList.Sum(x => x.GetArea()));
        }
        private static void SaveFile()
        {
            using (var tw = new StreamWriter(InputPath() + "testFile.txt", true))
            {
                foreach (var item in shapeList)
                {
                    tw.WriteLine(item);
                }
            }
        }

        private static void LoadFile()
        {
            shapeList.Clear();
            using (var sr = new StreamReader(InputPath() + "testFile.txt"))
            {
                while (true)
                {
                    var line = sr.ReadLine();
                    var typeShape = line?.Split(' ')[0];
                    if (line == null) break;
                    switch (typeShape)
                    {
                        case "Квадрат:":
                            shapeList.Add(Square.CreateSquare(ConvertToValues(line)));
                            break;
                        case "Прямоугольник:":
                            shapeList.Add(Rectangle.CreateRectangle(ConvertToValues(line)));
                            break;
                        case "Треугольник:":
                            shapeList.Add(Triangle.CreateTriangle(ConvertToValues(line)));
                            break;
                        case "Многоугольник:":
                            shapeList.Add(Polygon.CreatePolygon(ConvertToValues(line)));
                            break;
                        case "Круг:":
                            shapeList.Add(Circle.CreateCircle(ConvertToValues(line)));
                            break;
                        default:
                            break;
                    }
                }
            }
            OutputShapes();
        }

        private static void OutputShapes()
        {
            foreach (var item in shapeList)
            {
                Console.WriteLine(item);
            }
        }

        private static string InputPath()
        {
            Console.WriteLine("Введите путь:");
            var filePath = @"" + Console.ReadLine();
            if (Directory.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                Console.WriteLine("Путь указан неверно");
                return InputPath();
            }
        }

        private static List<int> ConvertToValues(string line)
        {
            var isFillNumber = false;
            var number = "";
            var listValues = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                var letter = line[i].ToString();
                if (int.TryParse(letter, out int result))
                {
                    isFillNumber = true;
                    number += result.ToString();
                    if (line.Length == i + 1) isFillNumber = false;
                }
                else isFillNumber = false;

                var isReadyNumber = !isFillNumber && number.Length > 0;
                if (isReadyNumber)
                {
                    listValues.Add(Convert.ToInt32(number));
                    number = "";
                    isFillNumber = true;
                }
            }
            return listValues;
        }
    }
}

