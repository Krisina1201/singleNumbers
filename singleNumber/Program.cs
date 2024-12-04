using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Ввод значений
        Console.WriteLine("Введите целочисленные числа без пробела, через запятую:");
        string[] nums = Console.ReadLine().Split(',');
        int[] array = new int[nums.Length];
        List<int> necessaryNumbers = new List<int>(); // Список для хранения двух уникальных чисел

        for (int i = 0; i < nums.Length; i++)
        {
            // Проверяем, является ли строка числом
            if (int.TryParse(nums[i], out array[i]) == false)
            {
                Console.WriteLine($"'{nums[i]}' не является допустимым целым числом.");
                return; // Выход из программы при ошибочном вводе
            }
        }

        // Словарь для подсчета количества вхождений чисел
        Dictionary<int, int> countingNumbers = new Dictionary<int, int>();
        foreach (int num in array)
        {
            if (!countingNumbers.ContainsKey(num))
            {
                countingNumbers.Add(num, 1); // Если число не встречалось, добавляем его с количеством 1
            }
            else
            {
                countingNumbers[num]++; // Увеличиваем счетчик для существующего числа
            }
        }

        // Поиск чисел, которые встречаются только один раз
        foreach (int num in countingNumbers.Keys)
        {
            if (countingNumbers[num] == 2)
            {
                necessaryNumbers.Add(num); // Сохраняем уникальное число в список

                // Если мы уже нашли два числа, выходим из цикла
                if (necessaryNumbers.Count >= 2)
                {
                    break;
                }
            }
        }

        // Вывод результата
        if (necessaryNumbers.Count == 2)
        {
            Console.WriteLine($"Искомые числа: {necessaryNumbers[0]}, {necessaryNumbers[1]}");
        }
        else
        {
            Console.WriteLine("Ошибка ввода, таких цифр не найдено или найдено меньше двух.");
        }
    }
}
