
namespace Torres_de_Hanoi
{
    partial class TorreDeHanoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TorreDeHanoi));
            this.button1 = new System.Windows.Forms.Button();
            this.txtUsuarioJugador = new System.Windows.Forms.Label();
            this.btIniciar = new System.Windows.Forms.Button();
            this.definirDisco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(441, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Resolver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUsuarioJugador
            // 
            this.txtUsuarioJugador.AutoSize = true;
            this.txtUsuarioJugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioJugador.Location = new System.Drawing.Point(109, 15);
            this.txtUsuarioJugador.Name = "txtUsuarioJugador";
            this.txtUsuarioJugador.Size = new System.Drawing.Size(122, 20);
            this.txtUsuarioJugador.TabIndex = 2;
            this.txtUsuarioJugador.Text = "UsuarioJugador";
            // 
            // btIniciar
            // 
            this.btIniciar.BackColor = System.Drawing.Color.DarkRed;
            this.btIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btIniciar.Location = new System.Drawing.Point(336, 42);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(75, 23);
            this.btIniciar.TabIndex = 4;
            this.btIniciar.Text = "Iniciar";
            this.btIniciar.UseVisualStyleBackColor = false;
            this.btIniciar.Click += new System.EventHandler(this.button3_Click);
            // 
            // definirDisco
            // 
            this.definirDisco.BackColor = System.Drawing.Color.DarkRed;
            this.definirDisco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.definirDisco.ForeColor = System.Drawing.Color.White;
            this.definirDisco.FormattingEnabled = true;
            this.definirDisco.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.definirDisco.Location = new System.Drawing.Point(176, 42);
            this.definirDisco.Name = "definirDisco";
            this.definirDisco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.definirDisco.Size = new System.Drawing.Size(121, 21);
            this.definirDisco.TabIndex = 5;
            this.definirDisco.Text = "Numero de discos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Determine la cantidad de discos:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "JUGADOR:";
            // 
            // TorreDeHanoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(849, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.definirDisco);
            this.Controls.Add(this.txtUsuarioJugador);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TorreDeHanoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TorreDeHanoi";
            this.Load += new System.EventHandler(this.TorreDeHanoi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TorreDeHanoi_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TorreDeHanoi_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtUsuarioJugador;
        private System.Windows.Forms.Button btIniciar;
        private System.Windows.Forms.ComboBox definirDisco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}