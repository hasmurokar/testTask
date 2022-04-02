using System;
using System.Collections.Generic;

namespace testTask
{
    public static class ValidParseData
    {
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
