using System;
using System.Collections.Generic;
using System.Linq;

namespace testTask.Shapes
{
    class Polygon : Shape
    {
        private static List<Vertex> Vertexes { get; set; } = new();

        public Polygon(List<Vertex> vertexes)
        {
            Vertexes = vertexes ?? throw new ArgumentNullException(nameof(vertexes));
        }

        public override double GetPerimetr()
        {
            var array = new double[Vertexes.Count];
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (i == Vertexes.Count - 1)
                {
                    array[i] = Math.Sqrt((Vertexes[0].X - Vertexes[i].X) + (Vertexes[0].Y - Vertexes[i].Y));
                    continue;
                }
                array[i] = Math.Sqrt((Vertexes[i + 1].X - Vertexes[i].X) + (Vertexes[i + 1].Y - Vertexes[i].Y));
            }
            return array.Sum();
        }

        public override double GetArea()
        {
            var arrayFirst = new double[Vertexes.Count];
            var arraySecond = new double[Vertexes.Count];
            for (int i = 0; i < Vertexes.Count - 1; i++)
            {
                arrayFirst[i] = (Vertexes[i].X * Vertexes[i + 1].Y);
                arraySecond[i] = (Vertexes[i].Y * Vertexes[i + 1].X);
            }
            return (arrayFirst.Sum() - arraySecond.Sum()) / 2;
        }

        public static Polygon InputPolygon()
        {
            Vertexes.Clear();
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Введите х:");
                    var x = ValidParseData.CheckedValueInt();
                    Console.WriteLine("Введите y:");
                    var y = ValidParseData.CheckedValueInt();
                    Vertexes.Add(new Vertex(x, y));
                }
                return new Polygon(Vertexes);
            }
        }
        public static Polygon CreatePolygon(List<int> values)
        {
            var list = new List<Vertex>();
            for (int i = 0; i < values.Count - 1; i += 2)
            {
                list.Add(new Vertex(values[i], values[i + 1]));
            }
            return new Polygon(list);
        }
        public override string ToString()
        {
            return $"Многоугольник: A({Vertexes[0].X};{Vertexes[0].Y}), B({Vertexes[1].X};{Vertexes[1].Y}), C({Vertexes[2].X};{Vertexes[2].Y}), D({Vertexes[3].X};{Vertexes[3].Y}), E({Vertexes[4].X};{Vertexes[4].Y})";
        }
    }
}
