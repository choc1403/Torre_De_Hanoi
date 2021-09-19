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
        public static String nombreJugador;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombreJugador = textBox1.Text;
            if(nombreJugador != "")
            {
                Carga ir = new Carga();
                ir.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("DEBE DE INGRESAR CON UN NOMBRE PARA CONTINUAR");
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();

            }
        }
    }
}
