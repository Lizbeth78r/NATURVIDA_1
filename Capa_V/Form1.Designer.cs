namespace Capa_V
{
    partial class frm_inicio_sesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_usuario = new System.Windows.Forms.TextBox();
            this.TXT_contraseña = new System.Windows.Forms.TextBox();
            this.BTN_ingresar = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 34);
            this.label2.TabIndex = 1;
            // 
            // TXT_usuario
            // 
            this.TXT_usuario.Location = new System.Drawing.Point(223, 105);
            this.TXT_usuario.Name = "TXT_usuario";
            this.TXT_usuario.Size = new System.Drawing.Size(140, 20);
            this.TXT_usuario.TabIndex = 2;
            // 
            // TXT_contraseña
            // 
            this.TXT_contraseña.Location = new System.Drawing.Point(223, 228);
            this.TXT_contraseña.Name = "TXT_contraseña";
            this.TXT_contraseña.PasswordChar = '*';
            this.TXT_contraseña.Size = new System.Drawing.Size(140, 20);
            this.TXT_contraseña.TabIndex = 3;
            // 
            // BTN_ingresar
            // 
            this.BTN_ingresar.Location = new System.Drawing.Point(258, 317);
            this.BTN_ingresar.Name = "BTN_ingresar";
            this.BTN_ingresar.Size = new System.Drawing.Size(75, 23);
            this.BTN_ingresar.TabIndex = 5;
            this.BTN_ingresar.Text = "INGRESAR";
            this.BTN_ingresar.UseVisualStyleBackColor = true;
            this.BTN_ingresar.Click += new System.EventHandler(this.BTN_ingresar_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(254, 65);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(81, 24);
            this.label32.TabIndex = 6;
            this.label32.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contraseña";
            // 
            // frm_inicio_sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(626, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.BTN_ingresar);
            this.Controls.Add(this.TXT_contraseña);
            this.Controls.Add(this.TXT_usuario);
            this.Controls.Add(this.label2);
            this.Name = "frm_inicio_sesion";
            this.Text = "Inicio sesion";
            this.Load += new System.EventHandler(this.frm_inicio_sesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_usuario;
        private System.Windows.Forms.TextBox TXT_contraseña;
        private System.Windows.Forms.Button BTN_ingresar;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
    }
}

