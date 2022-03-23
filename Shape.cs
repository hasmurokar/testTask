using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask
{
    abstract class Shape
    {
        public abstract double GetPerimetr();
        public abstract double GetArea();

        public static int CheckedValueInt()
        {
            string value;
            while (true)
            {
                value = Console.ReadLine();
                if (int.TryParse(value, out int val))
                {
                    return val;
                }
                else
                {
                    Console.WriteLine("Неверный формат. Повторите попытку.");
                }
            }
        }
    }
}
