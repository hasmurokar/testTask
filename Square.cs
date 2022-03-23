using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var s = CheckedValueInt();
            return new Square(s);
        }
    }
}
