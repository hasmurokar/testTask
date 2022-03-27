using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("\nВведите ширину:");
            var width = CheckedValueInt();
            Console.WriteLine("Введите высоту:");
            var height = CheckedValueInt();
            return new Rectangle(width, height);
        }

        public override string ToString()
        {
            return $"Прямоугольник: a = {Width}, b = {Height}";
        }
    }
}
