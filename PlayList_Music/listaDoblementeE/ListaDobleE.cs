using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList_Music.listaDoblementeE
{
    class ListaDobleE
    {
        public Nodo cabeza;

        public ListaDobleE()
        {
            cabeza = null;
        }

        public ListaDobleE insertaCabezaLista(string entrada)
        {
            Nodo nuevo;
            nuevo = new Nodo(entrada);
            nuevo.adelante = cabeza;

            if (cabeza != null)
            {
                cabeza.atras = null;
            }
            cabeza = nuevo;
            return this;
        }

        public ListaDobleE insertaDespues(Nodo anterior, string entrada)
        {
            if (anterior == null)
            {
                insertaCabezaLista(entrada);
            }
            else
            {
                Nodo nuevo;
                nuevo = new Nodo(entrada);

                nuevo.adelante = anterior.adelante;
                if (anterior.adelante != null)
                {
                    anterior.adelante.atras = nuevo;
                }
                anterior.adelante = nuevo;
                nuevo.atras = anterior;
            }
            return this;
        }

        public void eliminar(string entrada)
        {
            Nodo actual;
            bool encontrado = false;
            actual = cabeza;

            //Bucle de busqueda
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato.Equals(entrada));
                if (!encontrado)
                {
                    actual = actual.adelante;
                }
            }

            //Enlace de Nodo anterior con el siguiente
            if (actual != null)
            {
                // Distinguir Nodo cabecera del resto de la lista
                if (actual == (cabeza))
                {
                    cabeza = actual.adelante;
                    if (actual.adelante != null)
                    {
                        actual.adelante.atras = null;
                    }
                }
                else if (actual.adelante != null)
                { 
                    // Este no es el ultimo Nodo (intermedio)
                    actual.atras.adelante = actual.adelante;
                    actual.adelante.atras = actual.atras;
                }
                else
                {
                    actual.atras.adelante = null;
                }
                actual = null;
            }
        }



        public void visualiza()
        {
            Nodo n;
            n = cabeza;
            while (n != null)
            {
                Console.Write(n.dato + "\n");
                n = n.adelante;
            }
        }
    }
}
