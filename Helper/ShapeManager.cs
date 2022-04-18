using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
