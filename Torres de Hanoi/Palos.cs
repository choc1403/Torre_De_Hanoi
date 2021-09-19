using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torres_de_Hanoi
{
    class Palos:Button
    {
        //Constructor de los palos de fondo que inhabilita las funciones click
        //de los palos al momento de ejecutar el programa
        public Palos(int Ancho, int Alto,Image Fondo)
        {
            this.Width = Ancho;
            this.Height = Alto;
            this.Enabled = false;
            this.BackgroundImage = Fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void InitializeComponent()
        {
            
            this.SuspendLayout();
            // 
            // Palos
            // 
            this.Click += new System.EventHandler(this.Palos_Click);
            this.ResumeLayout(false);

        }

        private void Palos_Click(object sender, EventArgs e)
        {

        }
    }
}
