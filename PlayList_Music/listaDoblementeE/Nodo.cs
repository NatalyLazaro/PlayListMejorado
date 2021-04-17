using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.listaDoblementeE
{
    class Nodo
    {
        public string dato;
        public Nodo adelante;
        public Nodo atras;

        public string getDato()
        {
            return dato;
        }

        public Nodo(string entrada)
        {
            dato = entrada;
            adelante = atras = null;
        }
    }
}
