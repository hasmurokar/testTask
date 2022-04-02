using System;
using System.Collections.Generic;

namespace testTask
{
    class Triangle : Shape
    {
        private int SideA { get; set; }
        private int SideB { get; set; }
        private int SideC { get; set; }

        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetPerimetr()
        {
            return SideA + SideB + SideC;
        }

        public override double GetArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public static Triangle InputTriangle()
        {
            while (true)
            {
                Console.WriteLine("\nВведите сторону А:");
                var sideA = ValidParseData.CheckedValueInt();
                Console.WriteLine("Введите сторону В:");
                var sideB = ValidParseData.CheckedValueInt();
                Console.WriteLine("Введите сторону С:");
                var sideC = ValidParseData.CheckedValueInt();
                if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
                {
                    return new Triangle(sideA, sideB, sideC);
                }
                Console.WriteLine("Такого треугольника не существует.");
            }
        }

        public static Triangle CreateTriangle(List<int> values)
        {
            return new Triangle(values[0], values[1], values[2]);
        }

        public override string ToString()
        {
            return $"Треугольник: a = {SideA}, b = {SideB}, c = {SideC}";
        }
    }

}
