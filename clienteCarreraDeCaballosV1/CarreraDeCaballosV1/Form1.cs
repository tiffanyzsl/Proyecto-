using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
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
            IPEndPoint ipep = new IPEndPoint(direc, 9080);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green; //Una vez conectado con exito el color de fondo pasa a verde
                MessageBox.Show("Conectado"); //y mostramos un mensaje en pantalla informando al cliente que se ha conectado.

            }
            catch (SocketException ex)
            {
                MessageBox.Show("No se ha podido conectar con el servidor"); //En caso de error mostramos mensaje informativo
                return;                                                      //y salimos del programa.
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

            MessageBox.Show(respuesta);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + textBoxNombre.Text + "/" + textBoxUsername.Text + "/" + textBoxPassword.Text + "/" + textBoxEdad.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[512];
            int bytesRecibidos = server.Receive(msg2);
            string respuesta = Encoding.ASCII.GetString(msg2, 0, bytesRecibidos).Trim('\0');  

            MessageBox.Show(respuesta);
        }

        private void btnDesconectarse_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            this.BackColor = Color.White;
            MessageBox.Show("Te has desconectado del servidor.");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
