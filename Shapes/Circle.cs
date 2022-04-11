using System;
using System.Collections.Generic;

namespace testTask
{
    class Circle: Shape
    {
        private int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public override double GetPerimetr() //нахождение периметра
        {
            return 2 * Radius * Math.PI;
        }

        public override double GetArea() //нахождение площади
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
        /// <summary>
        /// ввод параметров круга
        /// </summary>
        /// <returns></returns>
        public static Circle InputCircle() //Для обращения к методу из другого класса используется static
        {
            Console.WriteLine("\nВведите радиус:");
            var radius = Help.CheckedValueInt();
            return new Circle(radius);
        }
        /// <summary>
        /// создание круга по параметрам
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Circle CreateCircle(List<int> values) //Для обращения к методу из другого класса используется static
        {
            return new Circle(values[0]);
        }

        public override string ToString()
        {
            return $"Круг: r = {Radius}";
        }
    }
}
