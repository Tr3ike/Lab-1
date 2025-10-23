using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

internal class Program_1
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите размер выборки: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("введите мин значение: ");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("введите макс значение: ");
        int max = int.Parse(Console.ReadLine());
        int[] mass = new int[n];
        Random random = new Random();
        for (int i = 0; i < mass.Length; i++)
        {
            mass[i] = random.Next(min, max);
        }
        Console.WriteLine("Массив: " + string.Join(", ", mass));
        //Вычисление среднего арифметического
        int m = 0;
        for (int i = 0; i < n; i++)
        {
            m += mass[i];
        }
        m = m / mass.Length;
        Console.WriteLine("Среднее Ариф: " + m);

        //Расчет стандартного отклонения
        double k = 0, x = 0;
        double stdDev = k;
        for (int i = 0; i < n; i++)
        {
            k = mass[i] - m;
            k = Math.Pow(k, 2);
            x += k;
        }
        stdDev = x / n;
        stdDev = Math.Sqrt(stdDev);
        Console.WriteLine("Стандартное отклонение: " + stdDev);

        int maxR = mass.Max();
        int minR = mass.Min();

        int range = maxR - minR;
        Console.WriteLine("Размах: " + range);

        //Сортировка массива
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (mass[j] > mass[j + 1])
                {
                    int temp = mass[j];
                    mass[j] = mass[j + 1];
                    mass[j + 1] = temp;
                }
            }
        }

        //Вычисление медианы
        double median;
        if (n % 2 == 0)
        {
            median = (mass[n / 2 - 1] + mass[n / 2]) / 2.0;
        }
        else
        {
            median = mass[n / 2];
        }
        Console.WriteLine("Медиана: " + median);

        // Вычисляем количество значений в каждом интервале
        int numIntervals = (int)Math.Ceiling(1 + 3.322 * Math.Log10(n));
        double intervalWidth = (max - min) / (double)numIntervals;
        int[] intervalCounts = new int[numIntervals];

        for (int i = 0; i < n; i++)
        {
            int intervalIndex = (int)((mass[i] - min) / intervalWidth);
            if (intervalIndex == numIntervals)
            {
                intervalIndex = numIntervals - 1;
            }
            intervalCounts[intervalIndex]++;
        }

        Console.WriteLine("Количество значений в каждом интервале:");
        for (int i = 0; i < numIntervals; i++)
        {
            double intervalStart = min + i * intervalWidth;
            double intervalEnd = min + (i + 1) * intervalWidth;
            Console.WriteLine($"Интервал [{intervalStart:F2}, {intervalEnd:F2}): {intervalCounts[i]}");
        }
    }
}
