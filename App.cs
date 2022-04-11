﻿using System;
using System.Collections.Generic;
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
                        GetPerimetrAndArea(shapeList);
                        break;
                    case ConsoleKey.U:
                        FileManager.SaveFile(shapeList);
                        break;
                    case ConsoleKey.O:
                        shapeList = FileManager.LoadFile();
                        break;
                    case ConsoleKey.Z:
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
        /// Осуществляет выбор фигуры и выводит площадь и периметр выбранной фигуры
        /// </summary>
        public static void GetPerimetrAndArea(List<Shape> shapeList) 
            //В этом методе static нужен потому, что нестатические поля/методы нельзя напрямую вызвать в статических классах
        {
            Console.WriteLine("\nВведите цифру: 1 - Квадрат, 2 - Прямоугольник, 3 - Треугольник, 4 - Круг, 5 - Многоугольник, 6 - Общая");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Shape.TotalPerimetr<Square>(shapeList);
                    Shape.TotalArea<Square>(shapeList);
                    break;
                case ConsoleKey.D2:
                    Shape.TotalPerimetr<Rectangle>(shapeList);
                    Shape.TotalArea<Rectangle>(shapeList);
                    break;
                case ConsoleKey.D3:
                    Shape.TotalPerimetr<Triangle>(shapeList);
                    Shape.TotalArea<Triangle>(shapeList);
                    break;
                case ConsoleKey.D4:
                    Shape.TotalPerimetr<Circle>(shapeList);
                    Shape.TotalArea<Circle>(shapeList);
                    break;
                case ConsoleKey.D5:
                    Shape.TotalPerimetr<Polygon>(shapeList);
                    Shape.TotalArea<Polygon>(shapeList);
                    break;
                case ConsoleKey.D6:
                    Shape.TotalPerimetr<Shape>(shapeList);
                    Shape.TotalArea<Shape>(shapeList);
                    break;
                default:
                    Console.WriteLine("\nВы ввели неверную букву.");
                    break;
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

