using Playlist.ObjListaOrdenada;
using PlayList_Music.listaCircular;
using PlayList_Music.listaDoblementeE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayList_Music
{
    public partial class Form1 : Form
    {
        ListaDobleE ruta = new ListaDobleE();
        ListaDobleE nom_cancion = new ListaDobleE();
        ListaCircular canciones = new ListaCircular();
        bool cabeza = false, replay = false;
        IteradorDobleE load;
        string borrar_ruta;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ruta.eliminar(borrar_ruta);
            lstCanciones.Items.RemoveAt(i);
            i--;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                if (cabeza == false)
                {
                    ruta.insertaCabezaLista(openfile.FileName);
                    nom_cancion.insertaCabezaLista(openfile.SafeFileName);
                    cabeza = true;
                    lstCanciones.Items.Add(openfile.SafeFileName);
                }
                else
                {
                    ruta.insertaDespues(ruta.cabeza,openfile.FileName);
                    nom_cancion.insertaDespues(nom_cancion.cabeza, openfile.SafeFileName);
                    lstCanciones.Items.Add(openfile.SafeFileName);
                }
                
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            i--;
            load.prior();
            axWindowsMediaPlayer1.URL = borrar_ruta = load.actual.dato;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if(replay == false)
            {
                i++;
                load.next();
                axWindowsMediaPlayer1.URL = borrar_ruta = load.actual.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                if (canciones.lc.dato != null)
                {
                    canciones.lc = canciones.lc.enlace;
                }
                
                axWindowsMediaPlayer1.URL = canciones.lc.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            IteradorDobleE a = new IteradorDobleE(ruta);
            replay = canciones.repetir(replay);
            if (replay == false)
            {
                canciones.borrarLista();
            }
            else
            {
                while (a.actual != null)
                {
                    canciones.insertar(a.actual.dato);
                    a.next();
                }

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (replay == false)
            {
                load = new IteradorDobleE(ruta);
                axWindowsMediaPlayer1.URL = borrar_ruta = load.actual.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer1.URL = canciones.lc.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
