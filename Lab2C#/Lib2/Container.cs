using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib2
{
    public class Container
    {
        public Ryadok[] Text;

        public Container()
        {
            Text = new Ryadok[5];
        }

        public Ryadok this[int index]
        {
            get
            {
                return Text[index];
            }
            set
            {
                Text[index] = value;
            }
        }

        public void Add(ref Ryadok[] text, Ryadok ryadok, ref int ind)
        {
            ind++;
            text[ind] = ryadok;
        }

        public void Remove(ref Ryadok[] text, Ryadok ryadok, ref int ind)
        {
            int i = 0;
            while(i <= ind)
            {
                if (text[i] == ryadok)
                    break;
                i++;
            }
            while (i < ind)
            {
                text[i] = text[i + 1];
                i++;
            }
            ind--;
        }

        public void Clear(ref Ryadok[] text, ref int ind)
        {
            int l = ind;
            for (int i = 0; i <= l; i++)
                Remove(ref text, text[i], ref ind);
        }

        public int Find(Ryadok[] text, Ryadok ryadok, int ind)
        {
            int c = 0;
            for (int i = 0; i <= ind; i++)
                if (text[i] == ryadok)
                    c++;
            return c;
        }

        public void Replace(ref Ryadok[] text, Ryadok ryadok0, Ryadok ryadok1, int ind)
        {
            for (int i = 0; i <= ind; i++)
                if (text[i] == ryadok0)
                {
                    text[i] = ryadok1;
                    break;
                }
        }
    }
}
