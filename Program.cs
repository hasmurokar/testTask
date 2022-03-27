using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                Console.WriteLine("Добавить: квадрат(S), прямоугольник(R), треугольник(T), круг(C)\nПодсчитать площадь и периметр(F), Сохранить(U), Выход(esc)\nЗагрузить файл(О)");
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
                    case ConsoleKey.U:
                        Console.WriteLine();
                        SaveFile(shapeList);
                        break;
                    case ConsoleKey.O:
                        Console.WriteLine();
                        shapeList = LoadFile();
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

        private static void SaveFile(List<Shape> list)
        {
            using (var tw = new StreamWriter(InputPath() + "‪testFile.txt", true))
            {
                foreach (var item in list)
                {
                    tw.WriteLine(item);
                }
            }
        }

        private static List<Shape> LoadFile()
        {
            var listLoadFile = new List<Shape>();
            using (var sr = new StreamReader(InputPath() + "testFile.txt"))
            {
                while (true)
                {
                    var line = sr.ReadLine();
                    if (line == null) break;
                    switch (line?.Split(' ')[0])
                    {
                        case "Квадрат:":
                            var squareObj = Parse(line);
                            var squareSide = squareObj[0];
                            listLoadFile.Add(new Square(squareSide));
                            break;
                        case "Прямоугольник:":
                            var rectangleObj = Parse(line);
                            var rectangleSideA = rectangleObj[0];
                            var rectangleSideB = rectangleObj[1];
                            listLoadFile.Add(new Rectangle(rectangleSideA, rectangleSideB));
                            break;
                        case "Треугольник:":
                            var triangleObj = Parse(line);
                            var triangleSideA = triangleObj[0];
                            var triangleSideB = triangleObj[1];
                            var triangleSideC = triangleObj[2];
                            listLoadFile.Add(new Triangle(triangleSideA, triangleSideB, triangleSideC));
                            break;
                        case "Круг:":
                            var circleObj = Parse(line);
                            var radius = circleObj[0];
                            listLoadFile.Add(new Circle(radius));
                            break;
                        default:
                            break;
                    }
                }
            }
            foreach (var item in listLoadFile)
            {
                Console.WriteLine(item);
            }
            return listLoadFile;
        }

        private static string InputPath()
        {
            while (true)
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
                }
            }
        }

        private static List<int> Parse(string s)
        {
            var isNumber = false;
            var numberString = "";
            var listParse = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int result))
                {
                    isNumber = true;
                    numberString += result.ToString();
                    if (s.Length == i + 1)
                    {
                        isNumber = false;
                    }
                }
                else
                {
                    isNumber = false;
                }
                if (isNumber == false && numberString.Length > 0)
                {
                    listParse.Add(Convert.ToInt32(numberString));
                    numberString = "";
                    isNumber = true;
                }
            }
            return listParse;
        }
    }
}

