namespace CarreraDeCaballosV1
{
    partial class Form2
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
            this.consultaHistorial = new System.Windows.Forms.RadioButton();
            this.consultaDuracion = new System.Windows.Forms.RadioButton();
            this.consultaLimiteEdad = new System.Windows.Forms.RadioButton();
            this.textBoxHistorial = new System.Windows.Forms.TextBox();
            this.textBoxDuracion = new System.Windows.Forms.TextBox();
            this.textBoxLimiteEdad = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consultaHistorial
            // 
            this.consultaHistorial.AutoSize = true;
            this.consultaHistorial.Location = new System.Drawing.Point(64, 45);
            this.consultaHistorial.Name = "consultaHistorial";
            this.consultaHistorial.Size = new System.Drawing.Size(363, 20);
            this.consultaHistorial.TabIndex = 0;
            this.consultaHistorial.TabStop = true;
            this.consultaHistorial.Text = "Dame el ID del jugador que quieras consultar el historial:";
            this.consultaHistorial.UseVisualStyleBackColor = true;
            // 
            // consultaDuracion
            // 
            this.consultaDuracion.AutoSize = true;
            this.consultaDuracion.Location = new System.Drawing.Point(64, 82);
            this.consultaDuracion.Name = "consultaDuracion";
            this.consultaDuracion.Size = new System.Drawing.Size(376, 20);
            this.consultaDuracion.TabIndex = 1;
            this.consultaDuracion.TabStop = true;
            this.consultaDuracion.Text = "Dame el ID de la partida que quieras consultar la duración:";
            this.consultaDuracion.UseVisualStyleBackColor = true;
            // 
            // consultaLimiteEdad
            // 
            this.consultaLimiteEdad.AutoSize = true;
            this.consultaLimiteEdad.Location = new System.Drawing.Point(64, 117);
            this.consultaLimiteEdad.Name = "consultaLimiteEdad";
            this.consultaLimiteEdad.Size = new System.Drawing.Size(409, 20);
            this.consultaLimiteEdad.TabIndex = 2;
            this.consultaLimiteEdad.TabStop = true;
            this.consultaLimiteEdad.Text = "Dame el ID de la partida que quieras consultar el limite de edad:";
            this.consultaLimiteEdad.UseVisualStyleBackColor = true;
            // 
            // textBoxHistorial
            // 
            this.textBoxHistorial.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxHistorial.Location = new System.Drawing.Point(447, 45);
            this.textBoxHistorial.Name = "textBoxHistorial";
            this.textBoxHistorial.Size = new System.Drawing.Size(125, 22);
            this.textBoxHistorial.TabIndex = 3;
            // 
            // textBoxDuracion
            // 
            this.textBoxDuracion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxDuracion.Location = new System.Drawing.Point(458, 82);
            this.textBoxDuracion.Name = "textBoxDuracion";
            this.textBoxDuracion.Size = new System.Drawing.Size(128, 22);
            this.textBoxDuracion.TabIndex = 4;
            // 
            // textBoxLimiteEdad
            // 
            this.textBoxLimiteEdad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxLimiteEdad.Location = new System.Drawing.Point(493, 117);
            this.textBoxLimiteEdad.Name = "textBoxLimiteEdad";
            this.textBoxLimiteEdad.Size = new System.Drawing.Size(116, 22);
            this.textBoxLimiteEdad.TabIndex = 5;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(545, 328);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(191, 71);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.textBoxLimiteEdad);
            this.Controls.Add(this.textBoxDuracion);
            this.Controls.Add(this.textBoxHistorial);
            this.Controls.Add(this.consultaLimiteEdad);
            this.Controls.Add(this.consultaDuracion);
            this.Controls.Add(this.consultaHistorial);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton consultaHistorial;
        private System.Windows.Forms.RadioButton consultaDuracion;
        private System.Windows.Forms.RadioButton consultaLimiteEdad;
        private System.Windows.Forms.TextBox textBoxHistorial;
        private System.Windows.Forms.TextBox textBoxDuracion;
        private System.Windows.Forms.TextBox textBoxLimiteEdad;
        private System.Windows.Forms.Button btnConsultar;
    }
}