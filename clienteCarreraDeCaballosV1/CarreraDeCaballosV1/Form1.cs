using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace CarreraDeCaballosV1
{
    public partial class Form1: Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConectarse_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 8080);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                MessageBox.Show("No se ha podido conectar con el servidor");
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + textBoxUsername.Text + "/" + textBoxPassword.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[512];
            int bytesRecibidos = server.Receive(msg2);
            string respuesta = Encoding.ASCII.GetString(msg2, 0, bytesRecibidos).Trim('\0');

            if (respuesta == "El usuario y/o la contrase￱a no son correctos")
            {

            }
            else
            {
                Form2 form2 = new Form2(server);
                form2.Show();

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + textBoxUsername.Text + "/" + textBoxPassword.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[512];
            int bytesRecibidos = server.Receive(msg2);
            string respuesta = Encoding.ASCII.GetString(msg2, 0, bytesRecibidos).Trim('\0');  // Limpiar la respuesta

            MessageBox.Show(respuesta);

            if (respuesta == "No se han obtenido datos")
            {

            }
            else
            {
                Form2 f2 = new Form2(server);
                f2.Show();
            }
        }
    }
}
