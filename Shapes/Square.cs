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
        /// <summary>
        /// ввод параметров квадрата
        /// </summary>
        /// <returns></returns>
        public static Square InputSquare() //Для обращения к методу из другого класса используется static
        {
            Console.WriteLine("\nВведите значение стороны:");
            var s = Help.CheckedValueInt();
            return new Square(s);
        }
        /// <summary>
        /// создание квадрата по параметрам
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Square CreateSquare(List<int> values) //Для обращения к методу из другого класса используется static
        {
            return new Square(values[0]);
        }
        public override string ToString()
        {
            return $"Квадрат: a = {Side}";
        }
    }
}
