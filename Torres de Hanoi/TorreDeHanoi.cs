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
    public partial class TorreDeHanoi : Form
    {
        //Variables globales
        public static int numDiscos; //Variable que almacena la cantidad de discos
        public static int contador;
        public static int numMovimientos;
        
        int XAbs, YAbs;
        int AnchoDiscos, AltoDiscos, AnchoPalos, AltoPalos;
        int NroDeDiscos;
        int ValorDeDecremento;
        Palos[] PalosTorres = new Palos[6];
        Disco[] Discos;
        Torre[] Torres = new Torre[3];
        int UbicacionYdelPalo;
        Disco DiscoTmp;
        Bitmap[] Imagenes;
        Bitmap PaloFondoVertical = new Bitmap(Application.StartupPath + @"\img\PaloFondoVertical.png");
        Bitmap PaloFondoHorizontal = new Bitmap(Application.StartupPath + @"\img\PaloFondoHorizontal.png");
        public TorreDeHanoi()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            txtUsuarioJugador.Text = Form1.nombreJugador;                      
        }

        private void TorreDeHanoi_Load(object sender, EventArgs e)
        {
            
        }
        void GenerarPalos()
        {
            //Se cargan los palos en el arreglo de palos y se modifican sus atributos
            UbicacionYdelPalo = YAbs - 45;
            for (int i = 0; i < 3; i++)
            {
                PalosTorres[i] = new Palos(AnchoPalos, AltoPalos, PaloFondoHorizontal);
                this.Controls.Add(PalosTorres[i]);
                PalosTorres[i].Location = new Point(XAbs + (AnchoPalos + 100) * i, YAbs + (AltoDiscos *10 + 50));
                PalosTorres[6 - i - 1] = new Palos(25, AltoDiscos * 10 + 50, PaloFondoVertical);
                this.Controls.Add(PalosTorres[6 - i - 1]);
                PalosTorres[6 - i - 1].Location = new Point((XAbs + (AnchoPalos + 100) * i) + AnchoPalos / 2 - (25 / 2), YAbs + 15);
                PalosTorres[i].SendToBack();
                PalosTorres[6 - i - 1].SendToBack();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Método utilizado para iniciar el solucionador del problema
            //Modo de consola
            RecursividadConsola(0, 1, 2, NroDeDiscos);
            //Modo grafico
            Recursividad(0, 1, 2, NroDeDiscos);
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            if (definirDisco.Text != "Numero de discos")
            {
                
                button1.Enabled = true;
                numDiscos = Convert.ToInt32(definirDisco.Text);

                //Inicialización de variables globales
                XAbs = 100;
                YAbs = 160;
                AnchoDiscos = 300;
                AnchoPalos = AnchoDiscos;
                AltoDiscos = 50;
                AltoPalos = 25;
                NroDeDiscos = numDiscos;
                ValorDeDecremento = 10;
                //Se cargan los platos en las torres
                Discos = new Disco[NroDeDiscos];
                for (int i = 0; i < 3; i++)
                {
                    Torres[i] = new Torre(NroDeDiscos);
                }
                Imagenes = new Bitmap[6];
                //parte gráfica del programa
                CargarImagenes();
                this.button1.BackgroundImage = Imagenes[2];
                GenerarPalos();
                GenerarPlatos();
                //Calcula la cantidad de movimientos en n discos
                numMovimientos = (int)Math.Pow(2, NroDeDiscos) - 1;               
            }
            else
            {
                MessageBox.Show("DEBE DE INGRESAR UN NUMERO DE DISCOS:");
            }
            
        }        

        private void TorreDeHanoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();

            }
        }

        private void TorreDeHanoi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void GenerarPlatos()
        {
            //Se crean los platos que se van a almacenar en un arreglo con los parámetros necesarios (posición y tamaño de los platos)
            for (int i = 0; i < NroDeDiscos; i++)
            {

                Discos[i] = new Disco(AnchoDiscos - (ValorDeDecremento * 2) * (NroDeDiscos - i), AltoDiscos, i + 1, PalosTorres[0].Left, PalosTorres[1].Left, PalosTorres[2].Left, AnchoDiscos, Torres, AnchoPalos, YAbs + (AltoDiscos * NroDeDiscos + 50), NroDeDiscos, Imagenes);

                this.Controls.Add(Discos[i]);
                Discos[i].T = Torres[0];
                Discos[i].Location = new Point(XAbs + (ValorDeDecremento) * (NroDeDiscos - i), YAbs + ((i + 1) * AltoDiscos));
                Discos[i].BringToFront();
            }
            for (int i = 0; i < NroDeDiscos; i++)
            {
                Torres[0].AñadirPlato(Discos[NroDeDiscos - i - 1]);
            }
            
        }

        void MoverPlatos(int TorreOrigen, int TorreDestino)
        {
            //Método utilizado para mover los platos según la torre en la que está ubicado
            DiscoTmp = Torres[TorreOrigen].UltimoElemento();
            for (int i = DiscoTmp.Top; i > UbicacionYdelPalo; i--)
            {
                DiscoTmp.Top = i;
                DiscoTmp.Refresh();
                PalosTorres[TorreOrigen + 3].Refresh();
                PalosTorres[TorreDestino + 3].Refresh();
            }
            if (TorreOrigen < TorreDestino)
            {
                for (int i = DiscoTmp.Left; i < ((XAbs + (AnchoPalos + 100) * TorreDestino) + AnchoPalos / 2) - (DiscoTmp.Width / 2); i++)
                {
                    DiscoTmp.Left = i;
                    DiscoTmp.Refresh();
                }
            }
            else
            {
                for (int i = DiscoTmp.Left; i > ((XAbs + (AnchoPalos + 100) * TorreDestino) + AnchoPalos / 2) - (DiscoTmp.Width / 2); i--)
                {
                    DiscoTmp.Left = i;
                    DiscoTmp.Refresh();

                }
            }

            for (int i = DiscoTmp.Top; i < YAbs + (AltoDiscos * (NroDeDiscos - Torres[TorreDestino].NroElementos) + 1); i++)
            {
                DiscoTmp.Top = i;
                DiscoTmp.Refresh();
                PalosTorres[TorreOrigen + 3].Refresh();
                PalosTorres[TorreDestino + 3].Refresh();
            }
            DiscoTmp.CambiarTorre(Torres[TorreDestino], Torres[TorreOrigen]);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Métodos recursivo que recibe el identificador de la torre en el arreglo de torres
        void Recursividad(int Origen, int Auxiliar, int Destino, int CantidadDePlatos)
        {
            contador++;            
            if (CantidadDePlatos == 1)
            {                
                MoverPlatos(Origen, Destino);             
                if (contador   == numMovimientos)
                {
                    cerrarFrom();
                    this.Close();
                }

            }
            else
            {                
                Recursividad(Origen, Destino, Auxiliar, CantidadDePlatos - 1);
                MoverPlatos(Origen, Destino);
                Recursividad(Auxiliar, Origen, Destino, CantidadDePlatos - 1);
            }
        }

        void RecursividadConsola(int Origen, int Auxiliar,int Destino, int CantidadDePlatos)
        {                      
            if (CantidadDePlatos == 1)
            {                
                Console.WriteLine("PASA DE LA BASE "+Origen+ " A LA BASE "+Destino);                
            }
            else
            {
                RecursividadConsola(Origen, Destino, Auxiliar, CantidadDePlatos - 1);
                Console.WriteLine("PASA DE LA BASE " + Origen + " A LA BASE " + Destino);
                RecursividadConsola(Auxiliar, Origen, Destino, CantidadDePlatos - 1);
            }
        }
        void cerrarFrom()
        {
            Confirmacion preguntar = new Confirmacion();
            preguntar.Show();            
        }

        //Método utilizado para cargar las imágenes de fondo
        void CargarImagenes()
        {
            Imagenes[0] = new Bitmap(Application.StartupPath + @"\img\DiscoAmarillo.png");
            Imagenes[1] = new Bitmap(Application.StartupPath + @"\img\DiscoAzul.png");
            Imagenes[2] = new Bitmap(Application.StartupPath + @"\img\DiscoMorado.png");
            Imagenes[3] = new Bitmap(Application.StartupPath + @"\img\DiscoNaranja.png");
            Imagenes[4] = new Bitmap(Application.StartupPath + @"\img\DiscoRojo.png");
            Imagenes[5] = new Bitmap(Application.StartupPath + @"\img\DiscoVerde.png");
        }
        
    }
}
