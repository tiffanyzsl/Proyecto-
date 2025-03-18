using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
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
            string mensaje = "2/"  + "/" + textBoxUsername.Text + "/" + textBoxPassword.Text + "/" + textBoxNombre.Text + "/" + textBoxEdad.Text ;
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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (c_historial.Checked)
            {
                string mensaje = "3/" + id_jugador.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);
            }
            else if (c_duracion.Checked)
            {
                string mensaje = "4/" + id_partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[300];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);


            }
            else
            {
                string mensaje = "5/" + id_partida1.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[300];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);
            }
        }
    }
}
