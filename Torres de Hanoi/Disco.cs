using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torres_de_Hanoi
{
    class Disco:Button
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
        public Disco(int Ancho, int Alto,int NroSerie,int B1,int B2,int B3, int AnchoPlatos, Torre[] ArregloTorre, int AnchoBases, int PosY, int NroPlatos, Bitmap[] Img)
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
            MovimientosMinimos =(int) Math.Pow(2, Nroplatos) - 1;
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
    }
}
