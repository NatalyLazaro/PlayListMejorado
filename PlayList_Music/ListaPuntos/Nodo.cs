using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.ListaPuntos
{
    class NodoO
    {
        public string dato;
        public NodoO enlace;

        public NodoO(string x)
        {
            dato = x;
            enlace = null;
        }

        public NodoO(string x, NodoO n)
        {
            dato = x;
            enlace = n;
        }

        public string getDato()
        {
            return dato;
        }
        public NodoO getEnlace()
        {
            return enlace;
        }

        public void setEnlace(NodoO Enlace)
        {
            this.enlace = Enlace;
        }
    }
}
