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

        public override double GetPerimetr()
        {
            return 2 * Radius * Math.PI;
        }

        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public static Circle InputCircle()
        {
            Console.WriteLine("\nВведите радиус:");
            var radius = ValidParseData.CheckedValueInt();
            return new Circle(radius);
        }

        public static Circle CreateCircle(List<int> values)
        {
            return new Circle(values[0]);
        }

        public override string ToString()
        {
            return $"Круг: r = {Radius}";
        }
    }
}
