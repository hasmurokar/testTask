using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTask.Shapes;

namespace testTask.Helper
{
    internal static class ShapeManager
    {
        /// <summary>
        /// Подсчитывает общий периметр всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void TotalPerimetr<T>(this List<Shape> shapeList) //Для обращения к методу из другого класса используется static
            where T : Shape
        {
            Console.WriteLine("\nПериметр: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetPerimetr())), 2);
        }
        /// <summary>
        /// Подсчитывает общую площадь всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void TotalArea<T>(this List<Shape> shapeList) //Для обращения к методу из другого класса используется static
            where T : Shape
        {
            Console.WriteLine("Площадь: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetArea())), 2);
        }
        /// <summary>
        /// Осуществляет выбор фигуры и выводит площадь и периметр выбранной фигуры
        /// </summary>
        public static void GetPerimetrAndArea(this List<Shape> shapeList)
        //В этом методе static нужен потому, что нестатические поля/методы нельзя напрямую вызвать в статических классах
        {
            Console.WriteLine("\nВведите цифру: 1 - Квадрат, 2 - Прямоугольник, 3 - Треугольник, 4 - Круг, 5 - Многоугольник, 6 - Общая");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    ShapeManager.TotalPerimetr<Square>(shapeList);
                    ShapeManager.TotalArea<Square>(shapeList);
                    break;
                case ConsoleKey.D2:
                    ShapeManager.TotalPerimetr<Rectangle>(shapeList);
                    ShapeManager.TotalArea<Rectangle>(shapeList);
                    break;
                case ConsoleKey.D3:
                    ShapeManager.TotalPerimetr<Triangle>(shapeList);
                    ShapeManager.TotalArea<Triangle>(shapeList);
                    break;
                case ConsoleKey.D4:
                    ShapeManager.TotalPerimetr<Circle>(shapeList);
                    ShapeManager.TotalArea<Circle>(shapeList);
                    break;
                case ConsoleKey.D5:
                    ShapeManager.TotalPerimetr<Polygon>(shapeList);
                    ShapeManager.TotalArea<Polygon>(shapeList);
                    break;
                case ConsoleKey.D6:
                    ShapeManager.TotalPerimetr<Shape>(shapeList);
                    ShapeManager.TotalArea<Shape>(shapeList);
                    break;
                default:
                    Console.WriteLine("\nВы ввели неверную букву.");
                    break;
            }
        }
    }
}
