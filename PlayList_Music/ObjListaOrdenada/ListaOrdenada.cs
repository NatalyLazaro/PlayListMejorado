using PlayList_Music.ListaPuntos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.ObjListaOrdenada
{
    class ListaOrdenada : lista
    {
        public ListaOrdenada insertaOrden(string entrada)
        {
            NodoO nuevo;
            nuevo = new NodoO(entrada);
            if (primero == null)
            {
                primero = nuevo;
            }
            else if (entrada.CompareTo(primero.getDato()) < 0)
            {
                nuevo.setEnlace(primero);
                primero = nuevo;
            }
            else
            {
                //busqueda del nodo anterior, a partir de aqui se hara la insercion
                NodoO anterior, p;
                anterior = p = primero;
                while ((p.getEnlace() != null) && (entrada.CompareTo(p.getDato())) > 0)
                {
                    anterior = p;
                    p = p.getEnlace();
                }
                if (entrada.CompareTo(p.getDato()) > 0)
                {
                    anterior = p;
                }
                nuevo.setEnlace(anterior.getEnlace());
                anterior.setEnlace(nuevo);

            }
            return this;

        }
    }
}