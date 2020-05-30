using System;
using Library;

namespace Lab8s2
{
    class Class
    {
        public bool CompareArrays(double[] a, double[] b)
        {
            bool equals = true;
            for (int i = 0; i < Math.Min(a.GetLength(0), b.GetLength(0)); i++)
                if (a[i] == b[i])
                    equals = true;
                else
                {
                    equals = false;
                    break;
                }
            return equals;
        }

        public static bool CompareArraysStatic(double[] a, double[] b)
        {
            bool equals = true;
            for (int i = 0; i < Math.Min(a.GetLength(0), b.GetLength(0)); i++)
                if (a[i] == b[i])
                    equals = true;
                else
                {
                    equals = false;
                    break;
                }
            return equals;
        }
    }

    delegate bool Compare(double[] a, double[] b);

    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 1, 2, 5 }, b = { 1, 2, 5 };
            Class obj = new Class();
            Compare delegat = obj.CompareArrays;
            delegat += Class.CompareArraysStatic;
            Console.WriteLine(delegat(a, b));
            //Console.WriteLine(delegat(a, b));
            /*Internet user = new Internet();
            user.Refill(6);
            user.GetAccess();
            user.Refill(6);
            user.Traffic(2);
            user.Traffic(12);*/
            Console.ReadKey();
        }
    }
}
