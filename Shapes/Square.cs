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

        public override double GetArea() //нахождение площади
        {
            return Side * Side;
        }

        public override double GetPerimetr() //нахождение периметра
        {
            return Side * 4;
        }
        public static Square InputSquare() //ввод параметров квадрата
        {
            Console.WriteLine("\nВведите значение стороны:");
            var s = Help.CheckedValueInt();
            return new Square(s);
        }
        public static Square CreateSquare(List<int> values) //создание квадрата по параметрам
        {
            return new Square(values[0]);
        }
        public override string ToString()
        {
            return $"Квадрат: a = {Side}";
        }
    }
}
