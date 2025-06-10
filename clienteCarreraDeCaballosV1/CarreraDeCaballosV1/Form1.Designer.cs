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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.lblTituloUsuariosConectados = new System.Windows.Forms.Label();
            this.caballo1 = new System.Windows.Forms.PictureBox();
            this.caballo2 = new System.Windows.Forms.PictureBox();
            this.caballo3 = new System.Windows.Forms.PictureBox();
            this.btnjugar = new System.Windows.Forms.Button();
            this.timerCarrera = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.finish = new System.Windows.Forms.PictureBox();
            this.TextBoxCaballoEligido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxApuestaEligida = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.resultadoCarreraLBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.puntosActualesLBL = new System.Windows.Forms.Label();
            this.listBoxConectados = new System.Windows.Forms.ListBox();
            this.invitarBTN = new System.Windows.Forms.Button();
            this.timerConectados = new System.Windows.Forms.Timer(this.components);
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.puntosBOX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cerrarsesionBTN = new System.Windows.Forms.Button();
            this.dueloBTN = new System.Windows.Forms.Button();
            this.confirmarapuestaBTN = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.labelidpartida = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.caballo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caballo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caballo3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finish)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConectarse
            // 
            this.btnConectarse.BackColor = System.Drawing.Color.LimeGreen;
            this.btnConectarse.Location = new System.Drawing.Point(9, 10);
            this.btnConectarse.Margin = new System.Windows.Forms.Padding(2);
            this.btnConectarse.Name = "btnConectarse";
            this.btnConectarse.Size = new System.Drawing.Size(92, 38);
            this.btnConectarse.TabIndex = 0;
            this.btnConectarse.Text = "Conectarse";
            this.btnConectarse.UseVisualStyleBackColor = false;
            this.btnConectarse.Click += new System.EventHandler(this.btnConectarse_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(11, 64);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(26, 79);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(76, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(11, 106);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(26, 120);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(76, 20);
            this.textBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(123, 120);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(49, 20);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(123, 200);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(76, 28);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(10, 196);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(108, 13);
            this.lblEdad.TabIndex = 7;
            this.lblEdad.Text = "Edad (nuevo usuario)";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(24, 210);
            this.textBoxEdad.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(76, 20);
            this.textBoxEdad.TabIndex = 8;
            // 
            // c_historial
            // 
            this.c_historial.AutoSize = true;
            this.c_historial.Location = new System.Drawing.Point(898, 43);
            this.c_historial.Margin = new System.Windows.Forms.Padding(2);
            this.c_historial.Name = "c_historial";
            this.c_historial.Size = new System.Drawing.Size(315, 17);
            this.c_historial.TabIndex = 9;
            this.c_historial.TabStop = true;
            this.c_historial.Text = "Dame el nombre de usuarios que quieras consultar el historial:";
            this.c_historial.UseVisualStyleBackColor = true;
            // 
            // c_duracion
            // 
            this.c_duracion.AutoSize = true;
            this.c_duracion.Location = new System.Drawing.Point(898, 64);
            this.c_duracion.Margin = new System.Windows.Forms.Padding(2);
            this.c_duracion.Name = "c_duracion";
            this.c_duracion.Size = new System.Drawing.Size(298, 17);
            this.c_duracion.TabIndex = 10;
            this.c_duracion.TabStop = true;
            this.c_duracion.Text = "Dame el ID de la partida que quieras consular la duracion:";
            this.c_duracion.UseVisualStyleBackColor = true;
            // 
            // c_limite
            // 
            this.c_limite.AutoSize = true;
            this.c_limite.Location = new System.Drawing.Point(898, 85);
            this.c_limite.Margin = new System.Windows.Forms.Padding(2);
            this.c_limite.Name = "c_limite";
            this.c_limite.Size = new System.Drawing.Size(325, 17);
            this.c_limite.TabIndex = 11;
            this.c_limite.TabStop = true;
            this.c_limite.Text = "Dame el ID de la partida que quieras consultar el limite de edad:";
            this.c_limite.UseVisualStyleBackColor = true;
            // 
            // id_jugador
            // 
            this.id_jugador.Location = new System.Drawing.Point(1214, 38);
            this.id_jugador.Margin = new System.Windows.Forms.Padding(2);
            this.id_jugador.Name = "id_jugador";
            this.id_jugador.Size = new System.Drawing.Size(79, 20);
            this.id_jugador.TabIndex = 12;
            // 
            // id_partida
            // 
            this.id_partida.Location = new System.Drawing.Point(1197, 61);
            this.id_partida.Margin = new System.Windows.Forms.Padding(2);
            this.id_partida.Name = "id_partida";
            this.id_partida.Size = new System.Drawing.Size(79, 20);
            this.id_partida.TabIndex = 13;
            // 
            // id_partida1
            // 
            this.id_partida1.Location = new System.Drawing.Point(1222, 83);
            this.id_partida1.Margin = new System.Windows.Forms.Padding(2);
            this.id_partida1.Name = "id_partida1";
            this.id_partida1.Size = new System.Drawing.Size(79, 20);
            this.id_partida1.TabIndex = 14;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(1222, 120);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(82, 20);
            this.btnConsulta.TabIndex = 15;
            this.btnConsulta.Text = "CONSULTAR";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnDesconectarse
            // 
            this.btnDesconectarse.BackColor = System.Drawing.Color.Firebrick;
            this.btnDesconectarse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDesconectarse.Location = new System.Drawing.Point(9, 287);
            this.btnDesconectarse.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesconectarse.Name = "btnDesconectarse";
            this.btnDesconectarse.Size = new System.Drawing.Size(92, 38);
            this.btnDesconectarse.TabIndex = 16;
            this.btnDesconectarse.Text = "Desconectar";
            this.btnDesconectarse.UseVisualStyleBackColor = false;
            this.btnDesconectarse.Click += new System.EventHandler(this.btnDesconectarse_Click);
            // 
            // lblTituloUsuariosConectados
            // 
            this.lblTituloUsuariosConectados.AutoSize = true;
            this.lblTituloUsuariosConectados.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloUsuariosConectados.Location = new System.Drawing.Point(297, 12);
            this.lblTituloUsuariosConectados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloUsuariosConectados.Name = "lblTituloUsuariosConectados";
            this.lblTituloUsuariosConectados.Size = new System.Drawing.Size(156, 18);
            this.lblTituloUsuariosConectados.TabIndex = 21;
            this.lblTituloUsuariosConectados.Text = "Usuarios conectados:";
            // 
            // caballo1
            // 
            this.caballo1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("caballo1.ErrorImage")));
            this.caballo1.InitialImage = ((System.Drawing.Image)(resources.GetObject("caballo1.InitialImage")));
            this.caballo1.Location = new System.Drawing.Point(0, 2);
            this.caballo1.Margin = new System.Windows.Forms.Padding(2);
            this.caballo1.Name = "caballo1";
            this.caballo1.Size = new System.Drawing.Size(62, 34);
            this.caballo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caballo1.TabIndex = 23;
            this.caballo1.TabStop = false;
            // 
            // caballo2
            // 
            this.caballo2.Location = new System.Drawing.Point(2, 2);
            this.caballo2.Margin = new System.Windows.Forms.Padding(2);
            this.caballo2.Name = "caballo2";
            this.caballo2.Size = new System.Drawing.Size(62, 34);
            this.caballo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caballo2.TabIndex = 24;
            this.caballo2.TabStop = false;
            // 
            // caballo3
            // 
            this.caballo3.Location = new System.Drawing.Point(2, 2);
            this.caballo3.Margin = new System.Windows.Forms.Padding(2);
            this.caballo3.Name = "caballo3";
            this.caballo3.Size = new System.Drawing.Size(62, 34);
            this.caballo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caballo3.TabIndex = 25;
            this.caballo3.TabStop = false;
            // 
            // btnjugar
            // 
            this.btnjugar.Location = new System.Drawing.Point(16, 603);
            this.btnjugar.Margin = new System.Windows.Forms.Padding(2);
            this.btnjugar.Name = "btnjugar";
            this.btnjugar.Size = new System.Drawing.Size(79, 44);
            this.btnjugar.TabIndex = 26;
            this.btnjugar.Text = "JUGAR SOLO";
            this.btnjugar.UseVisualStyleBackColor = true;
            this.btnjugar.Click += new System.EventHandler(this.btnjugar_Click);
            // 
            // timerCarrera
            // 
            this.timerCarrera.Tick += new System.EventHandler(this.timerCarrera_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.caballo1);
            this.panel1.Location = new System.Drawing.Point(16, 464);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 38);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.caballo2);
            this.panel2.Location = new System.Drawing.Point(16, 507);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 39);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.caballo3);
            this.panel3.Location = new System.Drawing.Point(16, 551);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 40);
            this.panel3.TabIndex = 28;
            // 
            // finish
            // 
            this.finish.Location = new System.Drawing.Point(771, 466);
            this.finish.Margin = new System.Windows.Forms.Padding(2);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(32, 127);
            this.finish.TabIndex = 29;
            this.finish.TabStop = false;
            // 
            // TextBoxCaballoEligido
            // 
            this.TextBoxCaballoEligido.Location = new System.Drawing.Point(13, 347);
            this.TextBoxCaballoEligido.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxCaballoEligido.Name = "TextBoxCaballoEligido";
            this.TextBoxCaballoEligido.Size = new System.Drawing.Size(76, 20);
            this.TextBoxCaballoEligido.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 332);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Elige el caballo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 376);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Elige la apuesta";
            // 
            // TextBoxApuestaEligida
            // 
            this.TextBoxApuestaEligida.Location = new System.Drawing.Point(13, 391);
            this.TextBoxApuestaEligida.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxApuestaEligida.Name = "TextBoxApuestaEligida";
            this.TextBoxApuestaEligida.Size = new System.Drawing.Size(76, 20);
            this.TextBoxApuestaEligida.TabIndex = 32;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // resultadoCarreraLBL
            // 
            this.resultadoCarreraLBL.AutoSize = true;
            this.resultadoCarreraLBL.Location = new System.Drawing.Point(818, 498);
            this.resultadoCarreraLBL.Name = "resultadoCarreraLBL";
            this.resultadoCarreraLBL.Size = new System.Drawing.Size(0, 13);
            this.resultadoCarreraLBL.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(818, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Resultado de la partida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Puntos actuales:";
            // 
            // puntosActualesLBL
            // 
            this.puntosActualesLBL.AutoSize = true;
            this.puntosActualesLBL.Location = new System.Drawing.Point(215, 394);
            this.puntosActualesLBL.Name = "puntosActualesLBL";
            this.puntosActualesLBL.Size = new System.Drawing.Size(0, 13);
            this.puntosActualesLBL.TabIndex = 37;
            // 
            // listBoxConectados
            // 
            this.listBoxConectados.FormattingEnabled = true;
            this.listBoxConectados.Location = new System.Drawing.Point(300, 33);
            this.listBoxConectados.Name = "listBoxConectados";
            this.listBoxConectados.Size = new System.Drawing.Size(153, 95);
            this.listBoxConectados.TabIndex = 38;
            // 
            // invitarBTN
            // 
            this.invitarBTN.Location = new System.Drawing.Point(300, 134);
            this.invitarBTN.Name = "invitarBTN";
            this.invitarBTN.Size = new System.Drawing.Size(75, 23);
            this.invitarBTN.TabIndex = 39;
            this.invitarBTN.Text = "INVITAR";
            this.invitarBTN.UseVisualStyleBackColor = true;
            this.invitarBTN.Click += new System.EventHandler(this.invitarBTN_Click);
            // 
            // listBoxChat
            // 
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.HorizontalScrollbar = true;
            this.listBoxChat.Location = new System.Drawing.Point(1111, 341);
            this.listBoxChat.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(205, 251);
            this.listBoxChat.TabIndex = 40;
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(1115, 605);
            this.textBoxChat.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(189, 20);
            this.textBoxChat.TabIndex = 41;
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(1183, 628);
            this.btnChat.Margin = new System.Windows.Forms.Padding(2);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(56, 19);
            this.btnChat.TabIndex = 42;
            this.btnChat.Text = "ENVIAR";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // puntosBOX
            // 
            this.puntosBOX.Location = new System.Drawing.Point(24, 168);
            this.puntosBOX.Margin = new System.Windows.Forms.Padding(2);
            this.puntosBOX.Name = "puntosBOX";
            this.puntosBOX.Size = new System.Drawing.Size(76, 20);
            this.puntosBOX.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Puntos";
            // 
            // cerrarsesionBTN
            // 
            this.cerrarsesionBTN.Location = new System.Drawing.Point(13, 246);
            this.cerrarsesionBTN.Margin = new System.Windows.Forms.Padding(2);
            this.cerrarsesionBTN.Name = "cerrarsesionBTN";
            this.cerrarsesionBTN.Size = new System.Drawing.Size(116, 22);
            this.cerrarsesionBTN.TabIndex = 46;
            this.cerrarsesionBTN.Text = "CERRAR SESION";
            this.cerrarsesionBTN.UseVisualStyleBackColor = true;
            this.cerrarsesionBTN.Click += new System.EventHandler(this.cerrarsesionBTN_Click);
            // 
            // dueloBTN
            // 
            this.dueloBTN.Location = new System.Drawing.Point(116, 603);
            this.dueloBTN.Margin = new System.Windows.Forms.Padding(2);
            this.dueloBTN.Name = "dueloBTN";
            this.dueloBTN.Size = new System.Drawing.Size(67, 44);
            this.dueloBTN.TabIndex = 47;
            this.dueloBTN.Text = "JUGAR ONLINE";
            this.dueloBTN.UseVisualStyleBackColor = true;
            this.dueloBTN.Click += new System.EventHandler(this.dueloBTN_Click);
            // 
            // confirmarapuestaBTN
            // 
            this.confirmarapuestaBTN.Location = new System.Drawing.Point(9, 425);
            this.confirmarapuestaBTN.Name = "confirmarapuestaBTN";
            this.confirmarapuestaBTN.Size = new System.Drawing.Size(120, 23);
            this.confirmarapuestaBTN.TabIndex = 48;
            this.confirmarapuestaBTN.Text = "Confirmar la apuesta";
            this.confirmarapuestaBTN.UseVisualStyleBackColor = true;
            this.confirmarapuestaBTN.Click += new System.EventHandler(this.confirmarapuestaBTN_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(510, 30);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(202, 18);
            this.label.TabIndex = 50;
            this.label.Text = "Estas en la partida numero:";
            // 
            // labelidpartida
            // 
            this.labelidpartida.AutoSize = true;
            this.labelidpartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelidpartida.Location = new System.Drawing.Point(717, 35);
            this.labelidpartida.Name = "labelidpartida";
            this.labelidpartida.Size = new System.Drawing.Size(0, 13);
            this.labelidpartida.TabIndex = 51;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 658);
            this.Controls.Add(this.labelidpartida);
            this.Controls.Add(this.label);
            this.Controls.Add(this.confirmarapuestaBTN);
            this.Controls.Add(this.dueloBTN);
            this.Controls.Add(this.cerrarsesionBTN);
            this.Controls.Add(this.puntosBOX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.invitarBTN);
            this.Controls.Add(this.listBoxConectados);
            this.Controls.Add(this.puntosActualesLBL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultadoCarreraLBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxApuestaEligida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxCaballoEligido);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnjugar);
            this.Controls.Add(this.lblTituloUsuariosConectados);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.caballo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caballo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caballo3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finish)).EndInit();
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
        private System.Windows.Forms.Label lblTituloUsuariosConectados;
        private System.Windows.Forms.PictureBox caballo1;
        private System.Windows.Forms.PictureBox caballo2;
        private System.Windows.Forms.PictureBox caballo3;
        private System.Windows.Forms.Button btnjugar;
        private System.Windows.Forms.Timer timerCarrera;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox finish;
        private System.Windows.Forms.TextBox TextBoxCaballoEligido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxApuestaEligida;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label resultadoCarreraLBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label puntosActualesLBL;
        private System.Windows.Forms.ListBox listBoxConectados;
        private System.Windows.Forms.Button invitarBTN;
        private System.Windows.Forms.Timer timerConectados;
        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.TextBox puntosBOX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cerrarsesionBTN;
        private System.Windows.Forms.Button dueloBTN;
        private System.Windows.Forms.Button confirmarapuestaBTN;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelidpartida;
    }
}

