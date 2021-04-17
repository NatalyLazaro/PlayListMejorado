using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.listaDoblementeE
{
    class IteradorDobleE
    {
        public Nodo actual;

        public IteradorDobleE(ListaDobleE ld)
        {
            actual = ld.cabeza;
        }

        public Nodo next()
        {
            Nodo a;
            a = actual;
            if (actual != null)
            {
                actual = actual.adelante;
            }
            return a;
        }

        public Nodo prior ()
        {
            Nodo a;
            a = actual;
            if (actual != null)
            {
                actual = actual.atras;
            }
            return a;
        }
    }
}
