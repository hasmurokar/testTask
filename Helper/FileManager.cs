using System;
using System.Collections.Generic;
using System.IO;
using testTask.Shapes;

namespace testTask
{
    public static class FileManager
    {
        /// <summary>
        /// Ввод пути к файлу с клавиатуры
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Сохранение фигур в txt файл
        /// </summary>
        /// <param name="shapeList"></param>
        public static void SaveFile(List<Shape> shapeList)
        {
            using var tw = new StreamWriter(InputPath() + "testFile.txt", true);
            shapeList.ForEach(item => tw.WriteLine(item));
        }
        /// <summary>
        /// Загрузка фигур из txt файла
        /// </summary>
        /// <param name="shapeList"></param>
        public static void LoadFile(List<Shape> shapeList)
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
                            shapeList.Add(Square.CreateSquare(Help.ConvertToValues(line)));
                            break;
                        case "Прямоугольник:":
                            shapeList.Add(Rectangle.CreateRectangle(Help.ConvertToValues(line)));
                            break;
                        case "Треугольник:":
                            shapeList.Add(Triangle.CreateTriangle(Help.ConvertToValues(line)));
                            break;
                        case "Многоугольник:":
                            shapeList.Add(Polygon.CreatePolygon(Help.ConvertToValues(line)));
                            break;
                        case "Круг:":
                            shapeList.Add(Circle.CreateCircle(Help.ConvertToValues(line)));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
