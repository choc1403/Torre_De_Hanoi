
namespace Torres_de_Hanoi
{
    partial class Confirmacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirmacion));
            this.btnJugarDeNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJugarDeNuevo
            // 
            this.btnJugarDeNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugarDeNuevo.ForeColor = System.Drawing.Color.White;
            this.btnJugarDeNuevo.Location = new System.Drawing.Point(101, 139);
            this.btnJugarDeNuevo.Name = "btnJugarDeNuevo";
            this.btnJugarDeNuevo.Size = new System.Drawing.Size(89, 24);
            this.btnJugarDeNuevo.TabIndex = 0;
            this.btnJugarDeNuevo.Text = "Volver A Jugar";
            this.btnJugarDeNuevo.UseVisualStyleBackColor = true;
            this.btnJugarDeNuevo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(330, 139);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button2_Click);
            // 
            // Confirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(529, 280);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnJugarDeNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Confirmacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJugarDeNuevo;
        private System.Windows.Forms.Button btnSalir;
    }
}