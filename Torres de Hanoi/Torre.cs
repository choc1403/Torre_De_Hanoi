using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Torre
    {
        //Genera n torres
        //Variables globales
        Disco[] Platos;
        public int NroElementos;
        //Constructor utilizado para inicializar las variables globales
        public Torre(int NroPlatos)
        {
            Platos = new Disco[NroPlatos];
            NroElementos = 0;
        }
        //Método que permite añadir platos a la torre
        public void AñadirPlato(Disco P)
        {
            this.Platos[NroElementos] = P;
            NroElementos++;
        }
        //Método que quita y devuelve los platos de la torre
        public Disco RetirarPlato()
        {
            NroElementos--;
            return Platos[NroElementos];
            
        }
        //Método que devuelve los platos de la torre
        public Disco UltimoElemento()
        {
            return Platos[NroElementos - 1];
        }
        //Método que retorna el número de serie de los platos
        public int NroSerieFinal()
        {
            if (NroElementos != 0)
            {
                return Platos[NroElementos - 1].NroSerie;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
