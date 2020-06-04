using System;
using DataStruct;

namespace Lab7s2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct<double> list = new MyStruct<double>();
            list.Add(1.0);
            list.Add(4.5);
            list.Add(-76.6338);
            list.Add(-7);
            list.Add(0.000000000000001);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveAllElementsAfterTheMax();
            list.Show();
            Console.WriteLine(list.Average());
            Console.WriteLine(list.SmallerThanAverageCount());
            Console.ReadKey();
        }
    }
}
