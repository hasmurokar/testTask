using System;
using System.Collections.Generic;

namespace testTask
{
    class Square : Shape
    {
        private int Side { get; set; }

        public Square(int side)
        {
            Side = side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimetr()
        {
            return Side * 4;
        }
        public static Square InputSquare()
        {
            Console.WriteLine("\nВведите значение стороны:");
            var s = ValidParseData.CheckedValueInt();
            return new Square(s);
        }
        public static Square CreateSquare(List<int> values)
        {
            return new Square(values[0]);
        }
        public override string ToString()
        {
            return $"Квадрат: a = {Side}";
        }
    }
}
