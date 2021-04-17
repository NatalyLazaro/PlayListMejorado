using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.listaCircular
{
    class ListaCircular
    {
        public NodoC lc;

        public ListaCircular()
        {
            lc = null;
        }

        public ListaCircular insertar(string entrada)
        {
            NodoC nuevo;
            nuevo = new NodoC(entrada);
            if (lc != null)
            { 
                //Lista no vacia 
                nuevo.enlace = lc.enlace;
                lc.enlace = nuevo;
            }
            lc = nuevo;
            return this;
        }

        public void eliminar(string entrada)
        {
            NodoC actual;
            bool encontrado = false;
            //Bucle de busqueda
            actual = lc;
            while ((actual.enlace != lc) && (!encontrado))
            {
                encontrado = (actual.enlace.dato.Equals(entrada));
                if (!encontrado)
                {
                    actual = actual.enlace;
                }
            }
            encontrado = (actual.enlace.dato.Equals(entrada));
            //Enlace de Nodo anterior con el siguiente
            if (encontrado)
            {
                NodoC p;
                p = actual.enlace; //Nodo a eliminar
                if (lc == lc.enlace)
                {
                    lc = null;
                }
                else
                {
                    if (p == lc)
                    {
                        lc = actual; //Se borra el elemento reclamado por lc
                    }
                    actual.enlace = p.enlace;
                }
                p = null;
            }
        }


        public void borrarLista()
        {
            NodoC p;
            if (lc != null)
            {
                p = lc;
                do
                {
                    NodoC t;
                    t = p;
                    p = p.enlace;
                    t = null; // no es estrictamente necesario
                } while (p != lc);
            }
            else
            {
                Console.WriteLine("\n\t Lista vacía.");
            }
            lc = null;
        }



        public void recorrer()
        {
            NodoC p;
            if (lc != null)
            {
                p = lc.enlace; // siguiente nodo al de acceso
                do
                {
                    Console.Write("\t" + p.dato);
                    p = p.enlace;
                } while (p != lc.enlace);
            }
            else
            {
                Console.Write("\t Lista Circular vacía.");
            }
        }

        public bool repetir(bool x)
        {
            if (x)
            {
                x = false;
            }
            else
            {
                x = true;
            }
            return x;
        }
    }
}
