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

        public static Circle InputCircle() //ввод параметров круга
        {
            Console.WriteLine("\nВведите радиус:");
            var radius = Help.CheckedValueInt();
            return new Circle(radius);
        }

        public static Circle CreateCircle(List<int> values) //создание круга по параметрам
        {
            return new Circle(values[0]);
        }

        public override string ToString()
        {
            return $"Круг: r = {Radius}";
        }
    }
}
