using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask
{
    class Triangle: Shape
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
            Console.WriteLine("\nВведите сторону А:");
            var sideA = CheckedValueInt(); 
            Console.WriteLine("Введите сторону В:");
            var sideB = CheckedValueInt();
            Console.WriteLine("Введите сторону С:");
            var sideC = CheckedValueInt();
            return new Triangle(sideA, sideB, sideC);
        }

        public override string ToString()
        {
            return $"Треугольник: a = {SideA}, b = {SideB}, c = {SideC}";
        }
    }
}
