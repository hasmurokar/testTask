using System;
using System.Collections.Generic;

namespace testTask
{
    class Rectangle: Shape
    {
        private int Width { get; set; }
        private int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override double GetPerimetr() //нахождение периметра
        {
            return (Width + Height) * 2;
        }

        public override double GetArea() //нахождение площади
        {
            return Width * Height;
        }
        /// <summary>
        /// ввод параметров прямоугольника
        /// </summary>
        /// <returns></returns>
        public static Rectangle InputRectangle() //Для обращения к методу из другого класса используется static
        {
            while (true)
            {
                Console.WriteLine("\nВведите ширину:");
                var width = Help.CheckedValueInt();
                Console.WriteLine("Введите высоту:");
                var height = Help.CheckedValueInt();
                if (width != height) { return new Rectangle(width, height); }
                Console.WriteLine("Ширина не может быть равна высоте");
            }
        }
        /// <summary>
        /// создние прямоугольника по параметрам
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Rectangle CreateRectangle(List<int> values) //Для обращения к методу из другого класса используется static
        {
            return new Rectangle(values[0], values[1]);
        }

        public override string ToString()
        {
            return $"Прямоугольник: a = {Width}, b = {Height}";
        }
    }
}
