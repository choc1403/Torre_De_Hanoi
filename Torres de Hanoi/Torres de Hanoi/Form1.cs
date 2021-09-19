using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torres_de_Hanoi
{
    public partial class Form1 : Form
    {
        //Variables globales
        int XAbs, YAbs;
        int AnchoPlatos, AltoPlatos, AnchoPalos, AltoPalos;
        int NroDePlatos;
        int ValorDeDecremento;
        Palos[] PalosTorres = new Palos[6];
        Plato[] Platos;
        Torre[] Torres = new Torre[3];
        int UbicacionYdelPalo;
        Plato PlatoTmp;
        Bitmap[] Imagenes;
        Bitmap PaloFondoVertical=new Bitmap(Application.StartupPath + @"\img\PaloFondoVertical.png");
        Bitmap PaloFondoHorizontal = new Bitmap(Application.StartupPath + @"\img\PaloFondoHorizontal.png");
        public Form1()
        {
            InitializeComponent();
            //Formulario en pantalla completa
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicialización de variables globales
            XAbs = 100;
            YAbs = 150;
            AnchoPlatos = 400;
            AnchoPalos = AnchoPlatos;
            AltoPlatos = 50;
            AltoPalos = 25;
            NroDePlatos = 10;
            ValorDeDecremento = 15;
            //Se cargan los platos en las torres
            Platos = new Plato[NroDePlatos];
            for(int i = 0; i < 3; i++)
            {
                Torres[i] = new Torre(NroDePlatos);
            }
            Imagenes = new Bitmap[6];
            //parte gráfica del programa
            CargarImagenes();
            this.button1.BackgroundImage = Imagenes[2];
            GenerarPalos();
            GenerarPlatos();
        }
        //Método que ayuda a cear los palos de fondo
        void GenerarPalos()
        {
            //Se cargan los palos en el arreglo de palos y se modifican sus atributos
            UbicacionYdelPalo = YAbs - 45;
            for (int i = 0; i < 3; i++)
            {
                PalosTorres[i] = new Palos(AnchoPalos, AltoPalos, PaloFondoHorizontal);
                this.Controls.Add(PalosTorres[i]);
                PalosTorres[i].Location = new Point(XAbs + (AnchoPalos + 100) * i,YAbs+(AltoPlatos * NroDePlatos + 50));
                PalosTorres[6-i-1] = new Palos(25, AltoPlatos * NroDePlatos + 50, PaloFondoVertical);
                this.Controls.Add(PalosTorres[6 - i - 1]);
                PalosTorres[6 - i - 1].Location = new Point((XAbs + (AnchoPalos + 100) * i) + AnchoPalos/2 - (25/2), YAbs + 15);
                PalosTorres[i].SendToBack();
                PalosTorres[6 - i - 1].SendToBack();
            }
        }
        void GenerarPlatos()
        {
            //Se crean los platos que se van a almacenar en un arreglo con los parámetros necesarios (posición y tamaño de los platos)
            for(int i = 0; i < NroDePlatos; i++)
            {
                
                Platos[i] = new Plato(AnchoPlatos - (ValorDeDecremento*2) * (NroDePlatos - i), AltoPlatos, i + 1,PalosTorres[0].Left,PalosTorres[1].Left,PalosTorres[2].Left,AnchoPlatos,Torres,AnchoPalos, YAbs + (AltoPlatos * NroDePlatos + 50),this.txtNroMovimientos,NroDePlatos,Imagenes);

                this.Controls.Add(Platos[i]);
                Platos[i].T = Torres[0];
                Platos[i].Location = new Point(XAbs + (ValorDeDecremento) * (NroDePlatos - i), YAbs  + ((i + 1) * AltoPlatos));
                Platos[i].BringToFront();
            }
            for (int i = 0; i < NroDePlatos; i++)
            {
                Torres[0].AñadirPlato(Platos[NroDePlatos - i - 1]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Método utilizado para iniciar el solucionador del problema
            Recursividad(0, 1, 2, NroDePlatos);
        }
        void MoverPlatos(int TorreOrigen, int TorreDestino)
        {
            //Método utilizado para mover los platos según la torre en la que está ubicado
            PlatoTmp = Torres[TorreOrigen].UltimoElemento();
            for (int i = PlatoTmp.Top; i > UbicacionYdelPalo; i--)
            {
                PlatoTmp.Top = i;
                PlatoTmp.Refresh();
                PalosTorres[TorreOrigen + 3].Refresh();
                PalosTorres[TorreDestino + 3].Refresh();
            }
            if (TorreOrigen < TorreDestino)
            {
                for (int i = PlatoTmp.Left; i < ((XAbs + (AnchoPalos + 100) * TorreDestino) + AnchoPalos / 2) - (PlatoTmp.Width / 2); i++)
                {
                    PlatoTmp.Left = i;
                    PlatoTmp.Refresh();
                }
            }
            else
            {
                for (int i = PlatoTmp.Left; i > ((XAbs + (AnchoPalos + 100) * TorreDestino) + AnchoPalos / 2) - (PlatoTmp.Width / 2); i--)
                {
                    PlatoTmp.Left = i;
                    PlatoTmp.Refresh();
                    
                }
            }
            
            for (int i = PlatoTmp.Top; i < YAbs + (AltoPlatos * (NroDePlatos-Torres[TorreDestino].NroElementos) + 1); i++)
            {
                PlatoTmp.Top = i;
                PlatoTmp.Refresh();
                PalosTorres[TorreOrigen + 3].Refresh();
                PalosTorres[TorreDestino + 3].Refresh();
            }
            PlatoTmp.CambiarTorre(Torres[TorreDestino], Torres[TorreOrigen]);
        }
        //Método recursivo que recibe el identificador de la torre en el arreglo de torres
        void Recursividad(int Origen, int Auxiliar, int Destino, int CantidadDePlatos)
        {
            if (CantidadDePlatos == 1)
            {
                MoverPlatos(Origen, Destino);
            }
            else
            {
                Recursividad(Origen, Destino, Auxiliar, CantidadDePlatos - 1);
                MoverPlatos(Origen, Destino);
                Recursividad(Auxiliar, Origen, Destino, CantidadDePlatos - 1);
            }
        }
        //Método utilizado para cargar las imágenes de fondo
        void CargarImagenes()
        {
            Imagenes[0]=new Bitmap(Application.StartupPath + @"\img\PlatoAmarillo.png");
            Imagenes[1] = new Bitmap(Application.StartupPath + @"\img\PlatoAzul.png");
            Imagenes[2] = new Bitmap(Application.StartupPath + @"\img\PlatoMorado.png");
            Imagenes[3] = new Bitmap(Application.StartupPath + @"\img\PlatoNaranja.png");
            Imagenes[4] = new Bitmap(Application.StartupPath + @"\img\PlatoRojo.png");
            Imagenes[5] = new Bitmap(Application.StartupPath + @"\img\PlatoVerde.png");
        }
    }
}
