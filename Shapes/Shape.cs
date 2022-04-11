using System;
using System.Collections.Generic;
using System.Linq;

namespace testTask
{
    public abstract class Shape
    {
        public abstract double GetPerimetr(); //абстрактный метод нахождения периметра
        public abstract double GetArea(); //абстрактный метод нахождения площади
        /// <summary>
        /// Подсчитывает общий периметр всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void TotalPerimetr<T>(List<Shape> shapeList) //Для обращения к методу из другого класса используется static
            where T : Shape 
        {
            Console.WriteLine("\nПериметр: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetPerimetr())), 2);
        }
        /// <summary>
        /// Подсчитывает общую площадь всех фигур по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void TotalArea<T>(List<Shape> shapeList) //Для обращения к методу из другого класса используется static
            where T : Shape 
        {
            Console.WriteLine("Площадь: " + Math.Round(shapeList.Where(x => x is T).Sum(x => x.GetArea())), 2);
        }
    }
}
