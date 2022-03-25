using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var radius = CheckedValueInt();
            return new Circle(radius);
        }

        public override string ToString()
        {
            return $"Круг: радиус = {Radius}";
        }
    }
}
