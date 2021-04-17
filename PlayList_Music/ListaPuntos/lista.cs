using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.ListaPuntos
{
    class lista
    {
        public NodoO primero;
        public lista()
        {
            primero = null;
        }


        public NodoO buscarPosicion(int posicion)
        {
            NodoO indice;
            int i;
            if (posicion < 0)
            {
                return null;
            }
            indice = primero;
            for (i = 1; (i < posicion) && (indice != null); i++)
            {
                indice = indice.enlace;
            }
            return indice;
        }

        public lista insertarUltimo(NodoO ultimo, string entrada)
        {
            ultimo.enlace = new NodoO(entrada);
            ultimo = ultimo.enlace;
            return this;
        }

        public lista insertarCabeza(NodoO cabeza, string valor)
        {
            cabeza.enlace = new NodoO(valor);
            cabeza = cabeza.enlace;
            return this;
        }


        public NodoO buscarLista(string destino)
        {
            NodoO indice;
            for (indice = primero; indice != null; indice = indice.enlace)
            {
                if (destino == indice.dato)
                {
                    return indice;
                }
            }
            return null;
        }

        public void eliminar(string entrada)
        {
            NodoO actual, anterior;
            bool encontrado;
            //inicializa los apuntadores
            actual = primero;
            anterior = null;
            encontrado = false;
            //busqueda del nodo anterior
            while ((actual != null) && (encontrado))
            {
                encontrado = (actual.dato == entrada);
                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }
            //enlace del nodo anterior con el siguiente
            if (actual != null)
            {
                if (actual == primero)
                {
                    primero = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
                actual = null;
            }
        }


        public lista insertarLista(string testigo, string entrada)
        {
            NodoO nuevo, anterior;
            anterior = buscarLista(testigo);
            if (anterior != null)
            {
                nuevo = new NodoO(entrada);
                nuevo.enlace = anterior.enlace;
                anterior.enlace = nuevo;
            }
            return this;
        }

        public void visualizar()
        {
            NodoO n;
            int k = 0;
            n = primero;
            while (n != null)
            {
                Console.Write(n.dato + " ");
                n = n.enlace;
                k++;
                Console.WriteLine(k % 15 != 0 ? " " : "\n");
            }
        }
    }
}
