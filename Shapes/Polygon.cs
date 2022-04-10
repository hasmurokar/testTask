using System;
using System.Collections.Generic;

namespace testTask.Shapes
{
    class Polygon : Shape
    {
        private List<Point> Points { get; set; } = new();
        /// <summary>
        /// Конструктор многоугольника с проверкой на null
        /// </summary>
        /// <param name="vertexes"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Polygon(List<Point> vertexes)
        {
            Points = vertexes ?? throw new ArgumentNullException(nameof(vertexes));
        }

        public override double GetPerimetr() //нахождение периметра многоугольника
        {
            var perimetr = 0.0;
            for (int i = 0; i < Points.Count; i++)
            {
                if (i == Points.Count - 1)
                {
                    perimetr += GetVectorLength(Points[0], Points[i]);
                    continue;
                }
                perimetr += GetVectorLength(Points[i], Points[i + 1]);
            }
            return perimetr;
        }

        public override double GetArea() //нахождение площади многоульника
        {
            var area = 0.0;
            for (int i = 0; i < Points.Count; i++)
            {
                if (i == Points.Count - 1)
                {
                    area += GetAreaTriangle(Points[0], Points[i], Points[0]);
                    continue;
                }
                area += GetAreaTriangle(Points[i], Points[i + 1], Points[0]);
            }
            return area;
        }

        public static Polygon InputPolygon() //ввод значений точек многоугольника
        {
            var points = new List<Point>();
            var count = InputCountPoints();
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Введите х:");
                    var x = Help.CheckedValueInt();
                    Console.WriteLine("Введите y:");
                    var y = Help.CheckedValueInt();
                    points.Add(new Point(x, y));
                }
                return new Polygon(points);
            }
        }

        public static Polygon CreatePolygon(List<int> values) //создание многоугольника по заданным точкам
        {
            var list = new List<Point>();
            for (int i = 0; i < values.Count - 1; i += 2)
            {
                list.Add(new Point(values[i], values[i + 1]));
            }
            return new Polygon(list);
        }
        private static int InputCountPoints() //ввод кол-ва точек многоуголька
        {
            int count;
            while (true)
            {
                Console.WriteLine("Введите количество точек многоугольника");
                count = Help.CheckedValueInt();
                if (count > 4) return count;
                Console.WriteLine("В многоугольнике должно быть не менее 5 точек");
            }
        }
        private static double GetVectorLength(Point p1, Point p2) //нахождение расстояния между точками
        {
            return Math.Sqrt(Math.Abs(p1.X - p2.X) + (p1.Y - p2.Y));
        }
        private static double GetAreaTriangle(Point a, Point b, Point c) //нахождения площади треуголников, составляющих иногоугольник
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2);
        }
        public override string ToString()
        {
            return "Многоугольник: " + string.Join(" ", Points);
        }
    }
}
