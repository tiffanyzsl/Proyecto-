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
            this.radioButtonHistorial = new System.Windows.Forms.RadioButton();
            this.radioButtonDuracion = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxHistorial = new System.Windows.Forms.TextBox();
            this.textBoxDuracion = new System.Windows.Forms.TextBox();
            this.textBoxLimiteEdad = new System.Windows.Forms.TextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnDesconectarse = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
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
            this.lblUsername.Location = new System.Drawing.Point(35, 153);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 16);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(58, 172);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 22);
            this.textBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 222);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(58, 242);
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
            this.lblEdad.Location = new System.Drawing.Point(41, 287);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(135, 16);
            this.lblEdad.TabIndex = 7;
            this.lblEdad.Text = "Edad (nuevo usuario)";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(58, 307);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(100, 22);
            this.textBoxEdad.TabIndex = 8;
            // 
            // radioButtonHistorial
            // 
            this.radioButtonHistorial.AutoSize = true;
            this.radioButtonHistorial.Location = new System.Drawing.Point(239, 214);
            this.radioButtonHistorial.Name = "radioButtonHistorial";
            this.radioButtonHistorial.Size = new System.Drawing.Size(363, 20);
            this.radioButtonHistorial.TabIndex = 9;
            this.radioButtonHistorial.TabStop = true;
            this.radioButtonHistorial.Text = "Dame el ID del jugador que quieras consultar el historial:";
            this.radioButtonHistorial.UseVisualStyleBackColor = true;
            // 
            // radioButtonDuracion
            // 
            this.radioButtonDuracion.AutoSize = true;
            this.radioButtonDuracion.Location = new System.Drawing.Point(239, 240);
            this.radioButtonDuracion.Name = "radioButtonDuracion";
            this.radioButtonDuracion.Size = new System.Drawing.Size(373, 20);
            this.radioButtonDuracion.TabIndex = 10;
            this.radioButtonDuracion.TabStop = true;
            this.radioButtonDuracion.Text = "Dame el ID de la partida que quieras consular la duracion:";
            this.radioButtonDuracion.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(239, 266);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(409, 20);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dame el ID de la partida que quieras consultar el limite de edad:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxHistorial
            // 
            this.textBoxHistorial.Location = new System.Drawing.Point(608, 214);
            this.textBoxHistorial.Name = "textBoxHistorial";
            this.textBoxHistorial.Size = new System.Drawing.Size(100, 22);
            this.textBoxHistorial.TabIndex = 12;
            // 
            // textBoxDuracion
            // 
            this.textBoxDuracion.Location = new System.Drawing.Point(618, 242);
            this.textBoxDuracion.Name = "textBoxDuracion";
            this.textBoxDuracion.Size = new System.Drawing.Size(100, 22);
            this.textBoxDuracion.TabIndex = 13;
            // 
            // textBoxLimiteEdad
            // 
            this.textBoxLimiteEdad.Location = new System.Drawing.Point(654, 266);
            this.textBoxLimiteEdad.Name = "textBoxLimiteEdad";
            this.textBoxLimiteEdad.Size = new System.Drawing.Size(100, 22);
            this.textBoxLimiteEdad.TabIndex = 14;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(392, 321);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(180, 71);
            this.btnConsulta.TabIndex = 15;
            this.btnConsulta.Text = "CONSULTAR";
            this.btnConsulta.UseVisualStyleBackColor = true;
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
            this.lblNombre.Location = new System.Drawing.Point(35, 85);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(151, 16);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre (nuevo usuario)";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(58, 105);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 22);
            this.textBoxNombre.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnDesconectarse);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.textBoxLimiteEdad);
            this.Controls.Add(this.textBoxDuracion);
            this.Controls.Add(this.textBoxHistorial);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButtonDuracion);
            this.Controls.Add(this.radioButtonHistorial);
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
        private System.Windows.Forms.RadioButton radioButtonHistorial;
        private System.Windows.Forms.RadioButton radioButtonDuracion;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBoxHistorial;
        private System.Windows.Forms.TextBox textBoxDuracion;
        private System.Windows.Forms.TextBox textBoxLimiteEdad;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnDesconectarse;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
    }
}

