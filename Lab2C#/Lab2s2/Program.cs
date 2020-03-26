using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib2;

namespace Lab2s2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ind = -1;
            Ryadok r1 = new Ryadok(Console.ReadLine().ToCharArray());
            Ryadok r2 = new Ryadok(Console.ReadLine().ToCharArray());
            Ryadok r3 = new Ryadok(Console.ReadLine().ToCharArray());
            Ryadok r4 = new Ryadok(Console.ReadLine().ToCharArray());
            Container main = new Container();
            main.Add(ref main.Text, r1, ref ind);
            main.Add(ref main.Text, r3, ref ind);
            main.Add(ref main.Text, r4, ref ind);
            Output(main.Text, ind);
            main.Remove(ref main.Text, r3, ref ind);
            Output(main.Text, ind);
            main.Clear(ref main.Text, ref ind);
            Output(main.Text, ind);
            main.Add(ref main.Text, r3, ref ind);
            main.Add(ref main.Text, r2, ref ind);
            main.Add(ref main.Text, r2, ref ind);
            Output(main.Text, ind);
            Console.WriteLine(main.Find(main.Text, r2, ind));
            main.Replace(ref main.Text, r2, r1, ind);
            Output(main.Text, ind);
            Console.ReadKey();
        }

        static void Output(Ryadok[] Text, int ind)
        {
            for (int i = 0; i <= ind; i++)
                Console.Write(Text[i].str);
            Console.WriteLine();
        }
    }
}