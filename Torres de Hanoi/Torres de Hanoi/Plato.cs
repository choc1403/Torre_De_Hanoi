using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torres_de_Hanoi
{
    class Plato:Button
    {
        //Variables globales de la clase
        Boolean Down;
        public int NroSerie;
        public Torre T;
        public Torre[] Torres;
        int TorreActual, Torrenueva;
        int PosicionInicialX, PosicionInicialY;
        int PosicionBase1, PosicionBase2, PosicionBase3;
        int AnchoPlatos;
        int AnchoBases, UbicacionBaseY;
        Label TxtContador;
        int Nroplatos;
        int MovimientosMinimos;
        Bitmap[] Imagenes;
        //Constructor que va a ser utilizado para inicializar algunas variables
        public Plato(int Ancho, int Alto,int NroSerie,int B1,int B2,int B3, int AnchoPlatos, Torre[] ArregloTorre, int AnchoBases, int PosY, Label TxtContador, int NroPlatos, Bitmap[] Img)
        {
            Imagenes = Img;
            this.Width = Ancho;
            this.Height = Alto;
            Colorear(NroSerie);
            PosicionBase1 = B1;
            PosicionBase2 = B2;
            PosicionBase3 = B3;
            Torres = ArregloTorre;
            TorreActual = 0;
            Torrenueva = 0;
            this.NroSerie = NroSerie;
            this.AnchoBases = AnchoBases;
            this.UbicacionBaseY = PosY;
            this.Nroplatos = NroPlatos;
            this.TxtContador = TxtContador;
            MovimientosMinimos =(int) Math.Pow(2, Nroplatos) - 1;
            //Se añaden los eventos que va a generar movimiento de los platos
            this.MouseDown += new MouseEventHandler(EventoDown);
            this.MouseUp += new MouseEventHandler(EventoUp);
            this.MouseMove += new MouseEventHandler(EventoMover);
            this.AnchoPlatos = AnchoPlatos;
            Down = false;
        }
        void Colorear(int NroSerie)
        {
            //Método que sirve para colocar las texturas en los platos
            switch (NroSerie)
            {
                case 1:
                    this.BackgroundImage = Imagenes[0];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 2:
                    this.BackgroundImage = Imagenes[1];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 3:
                    this.BackgroundImage = Imagenes[2];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    this.BackgroundImage = Imagenes[3];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 5:
                    this.BackgroundImage = Imagenes[4];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 6:
                    this.BackgroundImage = Imagenes[5];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 7:
                    this.BackgroundImage = Imagenes[0];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 8:
                    this.BackgroundImage = Imagenes[1];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 9:
                    this.BackgroundImage = Imagenes[2];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 10:
                    this.BackgroundImage = Imagenes[3];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    this.BackgroundImage = Imagenes[4];
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
            }
        }
        //Método utilizado para mover el plato en las torres
        public void CambiarTorre(Torre Nueva,Torre Antigua)
        {
            T = Nueva;
            T.AñadirPlato(Antigua.RetirarPlato());
        }
        //Evento que se produce cuando se presiona el ratón
        void EventoDown(Object Sender, EventArgs e)
        {
            Down = true;
            PosicionInicialX = this.Left;
            PosicionInicialY = this.Top;

        }
        //Evento que se produce cuando se deja de presionar el ratón
        //Método que sirve para posicionar el plato según la torre en la que se ubicó
        void EventoUp(Object Sender, EventArgs e)
        {
            Down = false;
            if (!Comprobar())
            {
                this.Left = PosicionInicialX;
                this.Top = PosicionInicialY;
            }
            else
            {
                if (TorreActual == 0)
                {
                    this.Left = PosicionBase1 + AnchoBases /2 - this.Width / 2;
                    this.Top = UbicacionBaseY - (Torres[TorreActual].NroElementos*this.Height);
                }
                if (TorreActual == 1)
                {
                    this.Left = PosicionBase2 + AnchoBases / 2 - (this.Width/2) ;
                    this.Top = UbicacionBaseY - (Torres[TorreActual].NroElementos * this.Height);
                }
                if (TorreActual == 2)
                {
                    this.Left = PosicionBase3 + AnchoBases / 2 - this.Width / 2;
                    this.Top = UbicacionBaseY - (Torres[TorreActual].NroElementos * this.Height);
                }
                this.TxtContador.Text = (int.Parse(TxtContador.Text)+1)+"";
                ComprobarVictoria();
                PosicionInicialX = this.Left;
                PosicionInicialY = this.Top;
            }
            
        }
        //Evento que verigica si se completó el juego y si se utilzó el mínimo número de movimientos
        void ComprobarVictoria()
        {
            if (Torres[2].NroElementos == Nroplatos)
            {
                if(int.Parse(TxtContador.Text)<= MovimientosMinimos)
                {
                    MessageBox.Show("Felicidades ganaste el juego");
                }
                else
                {
                    MessageBox.Show("Felicidades terminaste el juego");
                }
            }
        }
        //Evento utilizado mientras se presiona el ratón que
        //se utiliza para mover el plato
        void EventoMover(Object Sender, EventArgs e)
        {
            if (Down && T.UltimoElemento().Equals(this))
            {
                this.Top = MousePosition.Y - this.Height;
                this.Left=MousePosition.X - this.Width / 2;
            }
        }
        //Método utilizado para saber si es posible dejar el plato en la posición actual
        bool Comprobar()
        {
            bool Admitido=false;
            if((this.Left>PosicionBase1 && this.Left < PosicionBase1 + AnchoPlatos))
            {
                Torrenueva = 0;
                if (Torres[Torrenueva].NroSerieFinal()>=NroSerie || Torres[Torrenueva].NroSerieFinal()==0)
                {
                    CambiarTorre(Torres[Torrenueva], T);
                    Admitido = true;
                    TorreActual = Torrenueva;
                }

            }
            if ((this.Left > PosicionBase2 && this.Left < PosicionBase2 + AnchoPlatos))
            {
                Torrenueva = 1;
                if (Torres[Torrenueva].NroSerieFinal() >= NroSerie || Torres[Torrenueva].NroSerieFinal() == 0)
                {
                    CambiarTorre(Torres[Torrenueva], T);
                    Admitido = true;
                    TorreActual = Torrenueva;
                }

            }
            if ((this.Left > PosicionBase3 && this.Left < PosicionBase3 + AnchoPlatos))
            {
                Torrenueva = 2;
                if (Torres[Torrenueva].NroSerieFinal() >= NroSerie || Torres[Torrenueva].NroSerieFinal() == 0)
                { 
                    CambiarTorre(Torres[Torrenueva], T);
                    Admitido = true;
                    TorreActual = Torrenueva;
                }

            }
            return Admitido;
        }
    }
}
