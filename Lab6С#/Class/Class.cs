using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classs
{
    public class Class
    {
        private readonly int a, b, c, d;

        public Class (int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        private double Calculating()
        {
            double result = 0;
            try
            {
                result = (a * b / 4 - 1) / (Math.Sqrt(41 - d) - b * a + c);
                if (Math.Sqrt(41 - d) - b * a + c == 0)
                    throw new Exception("Деление на ноль.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            return Math.Round(result, 5);
        }

        public void Output()
        {
            try
            {
                if (!Char.IsDigit(Convert.ToChar(Convert.ToInt32(Calculating()))))
                    Console.WriteLine("Object = " + Calculating());
            }
            catch (OverflowException) { }
        }
    }
}
