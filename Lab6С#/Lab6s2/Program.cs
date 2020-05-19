using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classs;

namespace Lab6s2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Class[] objects = new Class[10];
            int[] numbers = new int[4] { 0, 0, 0, 41 };
            objects[0] = new Class(numbers[0], numbers[1], numbers[2], numbers[3]);
            objects[0].Output();
            for (int i = 1; i < 10; i++)
                try
                {
                    for (int j = 0; j < 4; j++)
                    {
                        numbers[j] = rand.Next(51);
                        Console.Write(numbers[j] + "  ");
                    }
                    Console.WriteLine();
                    if (numbers[3] > 41)
                        throw new Exception("Отрицательное значение под корнем.");
                    objects[i] = new Class(numbers[0], numbers[1], numbers[2], numbers[3]);
                    objects[i].Output();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            Console.ReadKey();
        }
    }
}
