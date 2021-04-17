using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.listaCircular
{
    class NodoC
    {
        public string dato;
        public NodoC enlace;

        public NodoC(string entrada)
        {
            dato = entrada;
            enlace = this;
        }
    }
}
