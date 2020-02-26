using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            bool e;
            Console.Write("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Inc(a);
            Console.Write("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter third number: ");
            c = Convert.ToInt32(Console.ReadLine());
            e = Equal(b, c);
            if (e) Console.WriteLine("Numbers are equal.");
            else Console.WriteLine("Numbers are not equal.");
            Console.ReadKey();
        }

        static void Inc(int a)
        {
            if (a == -1)
                a = 0;
            else
            {
                int bita, i = 0;
                bita = a & (1 << 0);
                while (bita != 0)
                {
                    a = a ^ (1 << i);
                    i++;
                    bita = a & (1 << i);
                }
                a = a ^ (1 << i);
            }
            Console.WriteLine(a);
        }

        static bool Equal(int b, int c)
        {
            int bitb, bitc, i;
            for (i = 0; i <= sizeof(int); i++)
            {
                bitb = b & (1 << i);
                bitc = c & (1 << i);
                if (bitb != bitc)
                    break;
            }
            if (i == sizeof(int) + 1) return true;
            else return false;
        }
    }
}
