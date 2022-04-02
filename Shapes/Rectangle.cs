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

        public override double GetPerimetr()
        {
            return (Width + Height) * 2;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
        public static Rectangle InputRectangle()
        {
            while (true)
            {
                Console.WriteLine("\nВведите ширину:");
                var width = ValidParseData.CheckedValueInt();
                Console.WriteLine("Введите высоту:");
                var height = ValidParseData.CheckedValueInt();
                if (width != height) { return new Rectangle(width, height); }
                Console.WriteLine("Ширина не может быть равна высоте");
            }
        }

        public static Rectangle CreateRectangle(List<int> values)
        {
            return new Rectangle(values[0], values[1]);
        }

        public override string ToString()
        {
            return $"Прямоугольник: a = {Width}, b = {Height}";
        }
    }
}
