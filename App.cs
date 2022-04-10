using System;
using System.Collections.Generic;
using System.Linq;
using testTask.Shapes;

namespace testTask
{
    class App
    {
        private List<Shape> shapeList = new();
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
                        PerimetrAndArea();
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
                        OutputShapes();
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
        private void PerimetrAndArea()
        {
            Console.WriteLine("Введите цифру: 1 - Квадрат, 2 - Прямоугольник, 3 - Треугольник, 4 - Круг, 5 - Многоугольник, 6 - Общая");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    TotalPerimetr<Square>();
                    TotalArea<Square>();
                    break;
                case ConsoleKey.D2:
                    TotalPerimetr<Rectangle>();
                    TotalArea<Rectangle>();
                    break;
                case ConsoleKey.D3:
                    TotalPerimetr<Triangle>();
                    TotalArea<Triangle>();
                    break;
                case ConsoleKey.D4:
                    TotalPerimetr<Circle>();
                    TotalArea<Circle>();
                    break;
                case ConsoleKey.D5:
                    TotalPerimetr<Polygon>();
                    TotalArea<Polygon>();
                    break;
                case ConsoleKey.D6:
                    TotalPerimetr<Shape>();
                    TotalArea<Shape>();
                    break;
                default:
                    Console.WriteLine("\nВы ввели неверную букву.");
                    break;
            }
        }
        /// <summary>
        /// Подсчитывает общий периметр всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void TotalPerimetr<T>()
            where T : Shape
        {
            Console.WriteLine("\nПериметр: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetPerimetr())),2);
        }
        /// <summary>
        /// Подсчитывает общую площадь всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void TotalArea<T>()
            where T : Shape
        {
            Console.WriteLine("Площадь: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetArea())),2);
        }
        /// <summary>
        /// Вывод списка фигур
        /// </summary>
        private void OutputShapes()
        {
            if (shapeList.Count == 0)
            {
                Console.WriteLine("Список фигур пуст");
                return;
            }
            shapeList.ForEach(item => Console.WriteLine(item));
        }
    }
}

