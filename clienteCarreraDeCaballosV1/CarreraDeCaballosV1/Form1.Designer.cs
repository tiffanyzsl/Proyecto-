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
            this.lblListaConectados = new System.Windows.Forms.Label();
            this.lblTituloUsuariosConectados = new System.Windows.Forms.Label();
            this.btnListaConectados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConectarse
            // 
            this.btnConectarse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnConectarse.Location = new System.Drawing.Point(12, 12);
            this.btnConectarse.Name = "btnConectarse";
            this.btnConectarse.Size = new System.Drawing.Size(122, 47);
            this.btnConectarse.TabIndex = 0;
            this.btnConectarse.Text = "Conectarse";
            this.btnConectarse.UseVisualStyleBackColor = false;
            this.btnConectarse.Click += new System.EventHandler(this.btnConectarse_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(19, 111);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 16);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(42, 130);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 22);
            this.textBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 162);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(36, 182);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 22);
            this.textBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(239, 38);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(164, 63);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(238, 122);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(165, 63);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(19, 274);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(135, 16);
            this.lblEdad.TabIndex = 7;
            this.lblEdad.Text = "Edad (nuevo usuario)";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(36, 294);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(100, 22);
            this.textBoxEdad.TabIndex = 8;
            // 
            // c_historial
            // 
            this.c_historial.AutoSize = true;
            this.c_historial.Location = new System.Drawing.Point(239, 214);
            this.c_historial.Name = "c_historial";
            this.c_historial.Size = new System.Drawing.Size(363, 20);
            this.c_historial.TabIndex = 9;
            this.c_historial.TabStop = true;
            this.c_historial.Text = "Dame el ID del jugador que quieras consultar el historial:";
            this.c_historial.UseVisualStyleBackColor = true;
            // 
            // c_duracion
            // 
            this.c_duracion.AutoSize = true;
            this.c_duracion.Location = new System.Drawing.Point(239, 240);
            this.c_duracion.Name = "c_duracion";
            this.c_duracion.Size = new System.Drawing.Size(373, 20);
            this.c_duracion.TabIndex = 10;
            this.c_duracion.TabStop = true;
            this.c_duracion.Text = "Dame el ID de la partida que quieras consular la duracion:";
            this.c_duracion.UseVisualStyleBackColor = true;
            // 
            // c_limite
            // 
            this.c_limite.AutoSize = true;
            this.c_limite.Location = new System.Drawing.Point(239, 266);
            this.c_limite.Name = "c_limite";
            this.c_limite.Size = new System.Drawing.Size(409, 20);
            this.c_limite.TabIndex = 11;
            this.c_limite.TabStop = true;
            this.c_limite.Text = "Dame el ID de la partida que quieras consultar el limite de edad:";
            this.c_limite.UseVisualStyleBackColor = true;
            // 
            // id_jugador
            // 
            this.id_jugador.Location = new System.Drawing.Point(627, 213);
            this.id_jugador.Name = "id_jugador";
            this.id_jugador.Size = new System.Drawing.Size(100, 22);
            this.id_jugador.TabIndex = 12;
            // 
            // id_partida
            // 
            this.id_partida.Location = new System.Drawing.Point(636, 238);
            this.id_partida.Name = "id_partida";
            this.id_partida.Size = new System.Drawing.Size(100, 22);
            this.id_partida.TabIndex = 13;
            // 
            // id_partida1
            // 
            this.id_partida1.Location = new System.Drawing.Point(674, 264);
            this.id_partida1.Name = "id_partida1";
            this.id_partida1.Size = new System.Drawing.Size(100, 22);
            this.id_partida1.TabIndex = 14;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(392, 321);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(180, 71);
            this.btnConsulta.TabIndex = 15;
            this.btnConsulta.Text = "CONSULTAR";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnDesconectarse
            // 
            this.btnDesconectarse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDesconectarse.Location = new System.Drawing.Point(13, 363);
            this.btnDesconectarse.Name = "btnDesconectarse";
            this.btnDesconectarse.Size = new System.Drawing.Size(122, 47);
            this.btnDesconectarse.TabIndex = 16;
            this.btnDesconectarse.Text = "Desconectarse";
            this.btnDesconectarse.UseVisualStyleBackColor = false;
            this.btnDesconectarse.Click += new System.EventHandler(this.btnDesconectarse_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(19, 218);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(151, 16);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre (nuevo usuario)";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(42, 238);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 22);
            this.textBoxNombre.TabIndex = 18;
            // 
            // lblListaConectados
            // 
            this.lblListaConectados.AutoSize = true;
            this.lblListaConectados.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaConectados.Location = new System.Drawing.Point(486, 144);
            this.lblListaConectados.Name = "lblListaConectados";
            this.lblListaConectados.Size = new System.Drawing.Size(0, 24);
            this.lblListaConectados.TabIndex = 20;
            // 
            // lblTituloUsuariosConectados
            // 
            this.lblTituloUsuariosConectados.AutoSize = true;
            this.lblTituloUsuariosConectados.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloUsuariosConectados.Location = new System.Drawing.Point(491, 111);
            this.lblTituloUsuariosConectados.Name = "lblTituloUsuariosConectados";
            this.lblTituloUsuariosConectados.Size = new System.Drawing.Size(200, 24);
            this.lblTituloUsuariosConectados.TabIndex = 21;
            this.lblTituloUsuariosConectados.Text = "Usuarios conectados:";
            // 
            // btnListaConectados
            // 
            this.btnListaConectados.Location = new System.Drawing.Point(495, 38);
            this.btnListaConectados.Name = "btnListaConectados";
            this.btnListaConectados.Size = new System.Drawing.Size(169, 63);
            this.btnListaConectados.TabIndex = 22;
            this.btnListaConectados.Text = "LISTA CONECTADOS";
            this.btnListaConectados.UseVisualStyleBackColor = true;
            this.btnListaConectados.Click += new System.EventHandler(this.btnListaConectados_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListaConectados);
            this.Controls.Add(this.lblTituloUsuariosConectados);
            this.Controls.Add(this.lblListaConectados);
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
        private System.Windows.Forms.Label lblListaConectados;
        private System.Windows.Forms.Label lblTituloUsuariosConectados;
        private System.Windows.Forms.Button btnListaConectados;
    }
}

