using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Shapes
{
    public class ShapeMethods
    {
        /// <summary>
        /// Осуществляет выбор фигуры и выводит площадь и периметр выбранной фигуры
        /// </summary>
        public static void PerimetrAndArea()
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
        private static void TotalPerimetr<T>()
            where T : Shape
        {
            Console.WriteLine("\nПериметр: " + Math.Round(App.shapeList.Where(x => x is T).Sum(x => x.GetPerimetr())), 2);
        }
        /// <summary>
        /// Подсчитывает общую площадь всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static void TotalArea<T>()
            where T : Shape
        {
            Console.WriteLine("Площадь: " + Math.Round(App.shapeList.Where(x => x is T).Sum(x => x.GetArea())), 2);
        }
        /// <summary>
        /// Вывод списка фигур
        /// </summary>
        public static void OutputShapes()
        {
            if (App.shapeList.Count == 0)
            {
                Console.WriteLine("Список фигур пуст");
                return;
            }
            App.shapeList.ForEach(item => Console.WriteLine(item));
        }
    }
}