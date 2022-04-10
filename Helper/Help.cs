using System;
using System.Collections.Generic;

namespace testTask
{
    public static class Help
    {
        /// <summary>
        /// Ввод числа типа int и его проверка
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Определение чисел из строки и сохранение их в список
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static List<int> ConvertToValues(string line)
        {
            var isFillNumber = false; //определяет является ли символ числом
            var number = "";
            var listValues = new List<int>();
            for (int i = 0; i < line.Length; i++) //каждая новая итерация цикла проверяет символ в строке
            {
                var letter = line[i].ToString(); //сохранение текущего символа
                if (int.TryParse(letter, out int result)) 
                {
                    isFillNumber = true;
                    number += result.ToString(); //если символ оказался числом, он сохраняется в строку
                    if (line.Length == i + 1) isFillNumber = false; 
                }
                else isFillNumber = false;

                var isReadyNumber = !isFillNumber && number.Length > 0; //определяет закончилось ли число
                if (isReadyNumber)
                {
                    listValues.Add(Convert.ToInt32(number));
                    number = "";
                    isFillNumber = true;
                }
            }
            return listValues;
        }
    }
}
