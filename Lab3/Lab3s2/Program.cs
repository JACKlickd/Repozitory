using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3s2
{
    class Program
    {

        class Lab
        {
            private char[,] arr;

            public Lab(char[,] array)
            {
                arr = array;
            }

            public string this[int index]
            {
                get
                {
                    if (index < 0 || index > arr.GetUpperBound(1))
                        throw new IndexOutOfRangeException();
                    StringBuilder s = new StringBuilder();
                    for (int i = 0; i < arr.GetLength(0); i++)
                        s.Append(arr[i, index]);
                    return s.ToString();
                }
            }

            public int Arr
            {
                get
                {
                    int c = 0;
                    for (int i = 0; i < arr.GetLength(0); i++)
                        for (int j = 0; j < arr.GetLength(1); j++)
                            if (char.IsDigit(arr[i, j]))
                                ++c;
                    return c;
                }
            }
        }

        static void Main(string[] args)
        {
            char[,] array = { { 'a', '5', 'n', 'R', '`' }, { 'X', 'k', '9', '/', 'Z' }, { '6', '0', 'k', 'a', 't' }, { 'P', 'G', 'k', 'f', 'H' } };
            Lab a = new Lab(array);
            Console.WriteLine(a[0]);
            Console.WriteLine(a.Arr);
            Console.ReadKey();
        }
    }
}
