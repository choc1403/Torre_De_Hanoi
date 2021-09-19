using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Torre
    {
        //Variables globales
        Plato[] Platos;
        public int NroElementos;
        //Constructor utilizado para inicializar las variables globales
        public Torre(int NroPlatos)
        {
            Platos = new Plato[NroPlatos];
            NroElementos = 0;
        }
        //Método que permite añadir platos a la torre
        public void AñadirPlato(Plato P)
        {
            this.Platos[NroElementos] = P;
            NroElementos++;
        }
        //Método que quita y devuelve los platos de la torre
        public Plato RetirarPlato()
        {
            NroElementos--;
            return Platos[NroElementos];
            
        }
        //Método que devuelve los platos de la torre
        public Plato UltimoElemento()
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
