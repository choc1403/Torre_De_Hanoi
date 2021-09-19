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
    
    public partial class Carga : Form
    {
        public static int cargando;
        public Carga()
        {
            InitializeComponent();
        }

        private void Carga_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            txtUsuario.Text = Form1.nombreJugador;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cargando++;
            progressBar1.Value = cargando;
            txtCarga.Text = "" + cargando + "%";
            switch (cargando)
            {
                case 1:
                    txtMensaje.Text = "LOS COMPONENTES ESTAN SIENDO CARGADOS";                    
                    break;

                case 10:
                    txtMensaje.Text = "MUCHAS GRACIAS POR HABER INICIADO";
                    break;

                case 20:
                    txtMensaje.Text = "EN UN MOMENTO EMPIEZA";
                    break;                

                case 50:
                    txtMensaje.Text = "YA VAMOS POR LA MITAD DEL PROCESO";
                    break;
                case 100:
                    txtMensaje.Text = "FINALIZADO";
                    timer1.Enabled = false;
                    cargando = 0;
                    TorreDeHanoi ir = new TorreDeHanoi();
                    ir.Show();
                    Visible = false;
                    break;
            }

        }
    }
}
