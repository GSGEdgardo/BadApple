using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadApple
{
    public class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool EsBlanco { get; set; }

        public Nodo(int x, int y, bool esBlanco)
        {
            X = x;
            Y = y;
            EsBlanco = esBlanco;
        }
    }
}
