namespace CarreraDeCaballosV1
{
    partial class Form1
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
            this.btnConectarse = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblEdad = new System.Windows.Forms.Label();
            this.textBoxEdad = new System.Windows.Forms.TextBox();
            this.c_historial = new System.Windows.Forms.RadioButton();
            this.c_duracion = new System.Windows.Forms.RadioButton();
            this.c_limite = new System.Windows.Forms.RadioButton();
            this.id_jugador = new System.Windows.Forms.TextBox();
            this.id_partida = new System.Windows.Forms.TextBox();
            this.id_partida1 = new System.Windows.Forms.TextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnDesconectarse = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConectarse
            // 
            this.btnConectarse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnConectarse.Location = new System.Drawing.Point(14, 15);
            this.btnConectarse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConectarse.Name = "btnConectarse";
            this.btnConectarse.Size = new System.Drawing.Size(137, 59);
            this.btnConectarse.TabIndex = 0;
            this.btnConectarse.Text = "Conectarse";
            this.btnConectarse.UseVisualStyleBackColor = false;
            this.btnConectarse.Click += new System.EventHandler(this.btnConectarse_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(21, 139);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(47, 163);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(112, 26);
            this.textBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(18, 203);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(40, 227);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(112, 26);
            this.textBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(269, 48);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(184, 79);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(268, 152);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(186, 79);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(21, 342);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(160, 20);
            this.lblEdad.TabIndex = 7;
            this.lblEdad.Text = "Edad (nuevo usuario)";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(40, 367);
            this.textBoxEdad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(112, 26);
            this.textBoxEdad.TabIndex = 8;
            // 
            // c_historial
            // 
            this.c_historial.AutoSize = true;
            this.c_historial.Location = new System.Drawing.Point(269, 268);
            this.c_historial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_historial.Name = "c_historial";
            this.c_historial.Size = new System.Drawing.Size(430, 24);
            this.c_historial.TabIndex = 9;
            this.c_historial.TabStop = true;
            this.c_historial.Text = "Dame el ID del jugador que quieras consultar el historial:";
            this.c_historial.UseVisualStyleBackColor = true;
            // 
            // c_duracion
            // 
            this.c_duracion.AutoSize = true;
            this.c_duracion.Location = new System.Drawing.Point(269, 300);
            this.c_duracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_duracion.Name = "c_duracion";
            this.c_duracion.Size = new System.Drawing.Size(441, 24);
            this.c_duracion.TabIndex = 10;
            this.c_duracion.TabStop = true;
            this.c_duracion.Text = "Dame el ID de la partida que quieras consular la duracion:";
            this.c_duracion.UseVisualStyleBackColor = true;
            // 
            // c_limite
            // 
            this.c_limite.AutoSize = true;
            this.c_limite.Location = new System.Drawing.Point(269, 332);
            this.c_limite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_limite.Name = "c_limite";
            this.c_limite.Size = new System.Drawing.Size(483, 24);
            this.c_limite.TabIndex = 11;
            this.c_limite.TabStop = true;
            this.c_limite.Text = "Dame el ID de la partida que quieras consultar el limite de edad:";
            this.c_limite.UseVisualStyleBackColor = true;
            // 
            // id_jugador
            // 
            this.id_jugador.Location = new System.Drawing.Point(705, 266);
            this.id_jugador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id_jugador.Name = "id_jugador";
            this.id_jugador.Size = new System.Drawing.Size(112, 26);
            this.id_jugador.TabIndex = 12;
            // 
            // id_partida
            // 
            this.id_partida.Location = new System.Drawing.Point(716, 298);
            this.id_partida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id_partida.Name = "id_partida";
            this.id_partida.Size = new System.Drawing.Size(112, 26);
            this.id_partida.TabIndex = 13;
            // 
            // id_partida1
            // 
            this.id_partida1.Location = new System.Drawing.Point(758, 330);
            this.id_partida1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id_partida1.Name = "id_partida1";
            this.id_partida1.Size = new System.Drawing.Size(112, 26);
            this.id_partida1.TabIndex = 14;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(441, 401);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(202, 89);
            this.btnConsulta.TabIndex = 15;
            this.btnConsulta.Text = "CONSULTAR";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnDesconectarse
            // 
            this.btnDesconectarse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDesconectarse.Location = new System.Drawing.Point(15, 454);
            this.btnDesconectarse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDesconectarse.Name = "btnDesconectarse";
            this.btnDesconectarse.Size = new System.Drawing.Size(137, 59);
            this.btnDesconectarse.TabIndex = 16;
            this.btnDesconectarse.Text = "Desconectarse";
            this.btnDesconectarse.UseVisualStyleBackColor = false;
            this.btnDesconectarse.Click += new System.EventHandler(this.btnDesconectarse_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 273);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(178, 20);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre (nuevo usuario)";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(47, 298);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(112, 26);
            this.textBoxNombre.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnDesconectarse);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.id_partida1);
            this.Controls.Add(this.id_partida);
            this.Controls.Add(this.id_jugador);
            this.Controls.Add(this.c_limite);
            this.Controls.Add(this.c_duracion);
            this.Controls.Add(this.c_historial);
            this.Controls.Add(this.textBoxEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnConectarse);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectarse;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox textBoxEdad;
        private System.Windows.Forms.RadioButton c_historial;
        private System.Windows.Forms.RadioButton c_duracion;
        private System.Windows.Forms.RadioButton c_limite;
        private System.Windows.Forms.TextBox id_jugador;
        private System.Windows.Forms.TextBox id_partida;
        private System.Windows.Forms.TextBox id_partida1;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnDesconectarse;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
    }
}

