using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
=======
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51


namespace CarreraDeCaballosV1
{
    public partial class Form1 : Form
    {
        Socket server;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
        Thread atender;
        string rutaCaballo = Path.Combine(Application.StartupPath, "imagenes", "caballo.png");
        string rutaFinish = Path.Combine(Application.StartupPath, "imagenes", "finish.png");
        int caballoGanador;
<<<<<<< HEAD
=======
=======
        string rutaCaballo = Path.Combine(Application.StartupPath, "imagenes", "caballo.png");
        string rutaFinish = Path.Combine(Application.StartupPath, "imagenes", "finish.png");

>>>>>>> 6c07e1f8fc865ad0000d023dc0581b15d18521c4
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caballo1.Image = Image.FromFile(rutaCaballo);
            caballo2.Image = Image.FromFile(rutaCaballo);
            caballo3.Image = Image.FromFile(rutaCaballo);
            finish.Image = Image.FromFile(rutaFinish);
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51


        }

        private void AtenderServidor()
        {
            try
            {
                while (true)
                {
                    byte[] msg2 = new byte[512];
                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    string respuesta = trozos[1].Split('\0')[0];

                    switch (codigo)
                    {
                        case 0://Respuesta a Cerrar Sesión
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("El jugador ha cerrado la sesion correctamente 👋");
                            });
                            break;
                        case 1://Respuesta a Iniciar Sesión
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show(respuesta);
                                puntosActualesLBL.Text = (trozos[2]);
<<<<<<< HEAD
                                labelidpartida.Text = (trozos[3]);
=======
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
                            });
                            break;
                        case 2://Resupesta a Registrarse
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show(respuesta);
                            });
                            break;
                        case 3://Consulta historial
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show(respuesta);
                            });
                            break;
                        case 4://Consulta duración
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show(respuesta);
                            });
                            break;
                        case 5://Consulta limite de edad
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show(respuesta);
                            });
                            break;
                        case 6://Notificacion usuarios conectados
                            this.Invoke((MethodInvoker)delegate
                            {
                                int num = int.Parse(trozos[1]); // número de conectados
                                listBoxConectados.Items.Clear();

                                for (int i = 0; i < num; i++)
                                {
                                    string usuario = trozos[2 + i];
                                    listBoxConectados.Items.Add(usuario);

                                }
                            });
                            break;
                        case 7://Notificacion de partida
                            this.Invoke((MethodInvoker)delegate
                            {
                                caballoGanador = int.Parse(respuesta);
                                string resultado = trozos[2];
                                double beneficio = Convert.ToDouble(trozos[3], CultureInfo.InvariantCulture);

                                resultadoCarreraLBL.Text = ("Caballo ganador: " + caballoGanador +
                                "\nResultado: " + resultado +
                                "\nBeneficio: " + beneficio);
                                puntosActualesLBL.Text = (trozos[4]);
                            });
<<<<<<< HEAD
                            break;
                        case 8:
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (trozos.Length >= 4)  // Mensaje largo: 8/usuario_invitador/usuario_invitado/id_partida
                                {
                                    string usuario_invitador = trozos[2];
                                    string usuario_invitado = trozos[3];
                                    string id_partida = trozos[4];

                                    if (textBoxUsername.Text == usuario_invitado)
                                    {
                                        MessageBox.Show(trozos[1], "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);                                        // SOLO el invitado hace esto:
                                        var result = MessageBox.Show(
                                            $"¿Quieres aceptar la invitacion?",
                                            "Invitación recibida",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

                                        string mensajeRespuesta;
                                        if (result == DialogResult.Yes)
                                            mensajeRespuesta = $"9/aceptar/{usuario_invitador}/{usuario_invitado}/{id_partida}";
                                        else
                                            mensajeRespuesta = $"9/rechazar/{usuario_invitador}/{usuario_invitado}/{id_partida}";

                                        byte[] msgRespuesta = Encoding.ASCII.GetBytes(mensajeRespuesta);
                                        server.Send(msgRespuesta);
                                    }
                                }
                                else
                                {
                                    // Mensaje corto: confirmación para el invitador
                                    MessageBox.Show(trozos[1], "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            });
                            break;
                        case 9: // Invitación correcta
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (trozos.Length >= 4)
                                {
                                    int aceptado = int.Parse(respuesta);
                                    if (aceptado == 1)
                                    {
                                        MessageBox.Show(trozos[2]);
                                        labelidpartida.Text = (trozos[3]);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Has rechazado la invitacion");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(respuesta);
                                }

=======
                            break;                        
                        case 8: // Invitación a un jugador
                            this.Invoke((MethodInvoker)delegate
                            {
                                var result = MessageBox.Show(
                                    respuesta + "\n¿Quieres aceptar la invitación?",
                                    "Invitación recibida",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                                string mensajeRespuesta;
                                if (result == DialogResult.Yes)
                                    mensajeRespuesta = "9/aceptada";
                                else
                                    mensajeRespuesta = "9/rechazada";

                                byte[] msgRespuesta = Encoding.ASCII.GetBytes(mensajeRespuesta);
                                server.Send(msgRespuesta);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
                            });
                            break;
                        case 10: // Mensaje de chat
                            this.Invoke((MethodInvoker)delegate
                            {
                                string usuario = trozos[1];
                                string mensajeChat = trozos[2].Split('\0')[0];
                                listBoxChat.Items.Add(usuario + ": " + mensajeChat);
                            });
                            break;
                        case 12: // Mensaje de chat
                            this.Invoke((MethodInvoker)delegate
                            {
                                caballoGanador = int.Parse(respuesta);
<<<<<<< HEAD
=======

>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
                                // Resetear posiciones de los caballos
                                caballo1.Left = 0;
                                caballo2.Left = 0;
                                caballo3.Left = 0;
<<<<<<< HEAD
                                // Iniciar el timer
                                timerCarrera.Start();

                                puntosActualesLBL.Text = (trozos[2]);
                                string resultado = trozos[3];
                                double beneficio = Convert.ToDouble(trozos[4], CultureInfo.InvariantCulture);
                                resultadoCarreraLBL.Text = ("Caballo ganador: " + caballoGanador + "\nResultado: " + resultado +
                                "\nBeneficio: " + beneficio);
=======

                                // Iniciar el timer
                                timerCarrera.Start();

>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
                            });
                            break;
                    }
                }
            }
            catch (SocketException ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Error en la conexión con el servidor:\n" + ex.Message);
                });
            }
<<<<<<< HEAD
=======
=======
>>>>>>> 6c07e1f8fc865ad0000d023dc0581b15d18521c4
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51

        }

        private void btnConectarse_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50066);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.YellowGreen; //Una vez conectado con exito el color de fondo pasa a amarillo
                MessageBox.Show("Conectado"); //y mostramos un mensaje en pantalla informando al cliente que se ha conectado.

            }
            catch (SocketException ex)
            {
                MessageBox.Show("No se ha podido conectar con el servidor"); //En caso de error mostramos mensaje informativo
                return;                                                      //y salimos del programa.
            }

            //ponemos en marcha el thread que atenderá al servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Detenemos la ejecución para que el usuario corrija el error
            }
            else
            {
                string mensaje = "1/" + textBoxUsername.Text + "/" + textBoxPassword.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.BackColor = Color.Green; //Una vez conectado con exito el color de fondo pasa a verde

                string mensaje2 = "6/";
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg2);
            }
=======
            string mensaje = "1/" + textBoxUsername.Text + "/" + textBoxPassword.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.BackColor = Color.Green; //Una vez conectado con exito el color de fondo pasa a verde
            
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
            string.IsNullOrWhiteSpace(puntosBOX.Text) || string.IsNullOrWhiteSpace(textBoxEdad.Text))
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detenemos la ejecución para que el usuario corrija el error
            }

            // Verificar que puntos sea un número
            if (!int.TryParse(puntosBOX.Text, out _))
            {
                MessageBox.Show("El parámetro puntos debe contener un número.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que edad sea un número
            if (!int.TryParse(textBoxEdad.Text, out int edad))
            {
                MessageBox.Show("El parámetro edad debe contener un número.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que la edad sea mayor o igual a 16
            if (edad < 16)
            {
                MessageBox.Show("Debes tener al menos 16 años para continuar.", "Edad mínima requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todo está correcto, construimos y enviamos el mensaje
            string mensaje = "2/" + textBoxUsername.Text + "/" + textBoxPassword.Text + "/" + puntosBOX.Text + "/" + textBoxEdad.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

=======
<<<<<<< HEAD
            string mensaje = "2/" + textBoxUsername.Text + "/" + textBoxPassword.Text + "/" + puntosBOX.Text + "/" + textBoxEdad.Text;
=======
            string mensaje = "2/"  + textBoxUsername.Text + "/" + textBoxPassword.Text + "/" + textBoxNombre.Text + "/" + textBoxEdad.Text ;
>>>>>>> 6c07e1f8fc865ad0000d023dc0581b15d18521c4
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
        }

        private void btnDesconectarse_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            this.BackColor = Color.White;
            MessageBox.Show("Te has desconectado del servidor.");

            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            puntosActualesLBL.Text = "";
            resultadoCarreraLBL.Text = "";
            labelidpartida.Text = "";
=======

            this.BackColor = Color.White;
            MessageBox.Show("Te has desconectado del servidor.");
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
            //Close();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
           

            if (c_historial.Checked)
            {
                string mensaje = "3/" + id_jugador.Text;
                // Enviamos al servidor el nombre usuario
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else if (c_duracion.Checked)
            {
                string mensaje = "4/" + id_partida.Text;
                // Enviamos al servidor el id de partida
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


            }
            else
            {
                string mensaje = "5/" + id_partida1.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }

        private void btnjugar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string mensaje = "7/" + TextBoxCaballoEligido.Text + "/" + TextBoxApuestaEligida.Text + "/" + textBoxUsername.Text;
=======
            string mensaje = "7/" + TextBoxCaballoEligido.Text + "/" + TextBoxApuestaEligida.Text;
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Resetear posiciones de los caballos
            caballo1.Left = 0;
            caballo2.Left = 0;
            caballo3.Left = 0;

            // Iniciar el timer
            timerCarrera.Start();
        }

        private void timerCarrera_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (caballoGanador == 1)
                caballo1.Left += rnd.Next(10, 15);
            else
                caballo1.Left += rnd.Next(5, 10);

            if (caballoGanador == 2)
                caballo2.Left += rnd.Next(10, 15);
            else
                caballo2.Left += rnd.Next(5, 10);

            if (caballoGanador == 3)
                caballo3.Left += rnd.Next(10, 15);
            else
                caballo3.Left += rnd.Next(5, 10);

            int meta = finish.Left - caballo1.Width - 35;

            if (caballo1.Left >= meta || caballo2.Left >= meta || caballo3.Left >= meta)
            {
                timerCarrera.Stop();
            }
        }

        private void invitarBTN_Click(object sender, EventArgs e)
        {
            if (listBoxConectados.SelectedItem != null)
            {
                string invitado = listBoxConectados.SelectedItem.ToString();
<<<<<<< HEAD
                string mensaje = "8/" + textBoxUsername.Text + "/" + invitado;
=======
                string mensaje = "8/" + invitado;
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51

                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para invitar.");
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxChat.Text))
            {
                string mensaje = "10/" + textBoxUsername.Text + "/" + textBoxChat.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                // Mostrar el mensaje en el chat localmente
                listBoxChat.Items.Add(textBoxUsername.Text + ": " + textBoxChat.Text);
                textBoxChat.Clear();

            }
            else
            {
                MessageBox.Show("No ha puesto mensaje");
            }
        }

        private void cerrarsesionBTN_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.BackColor = Color.YellowGreen; //Una vez conectado con exito el color de fondo pasa a amarillo

<<<<<<< HEAD
            string mensaje2 = "6/";
            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            server.Send(msg2);

            puntosActualesLBL.Text = "";
            resultadoCarreraLBL.Text = "";
            labelidpartida.Text = "";
=======
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
        }

        private void dueloBTN_Click(object sender, EventArgs e)
        {
            string mensaje = "12/" + textBoxUsername.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

<<<<<<< HEAD
            //byte[] msg2 = new byte[512];
            //server.Receive(msg2);
            //string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
            //int codigo = Convert.ToInt32(trozos[0]);
            //caballoGanador = int.Parse(trozos[1].Split('\0')[0]);

            //// Resetear posiciones de los caballos
            //caballo1.Left = 0;
            //caballo2.Left = 0;
            //caballo3.Left = 0;

            //// Iniciar el timer
            //timerCarrera.Start();
=======
            byte[] msg2 = new byte[512];
            server.Receive(msg2);
            string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
            int codigo = Convert.ToInt32(trozos[0]);
            caballoGanador = int.Parse(trozos[1].Split('\0')[0]);

            // Resetear posiciones de los caballos
            caballo1.Left = 0;
            caballo2.Left = 0;
            caballo3.Left = 0;

            // Iniciar el timer
            timerCarrera.Start();
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51

        }

        private void confirmarapuestaBTN_Click(object sender, EventArgs e)
        {
            string mensaje = "11/" + textBoxUsername.Text + "/" + TextBoxCaballoEligido.Text + "/" + TextBoxApuestaEligida.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

<<<<<<< HEAD
            MessageBox.Show("La apuesta se ha guardao correctamente");
        }

=======
        }

        Random rnd = new Random();

        private void btnjugar_Click(object sender, EventArgs e)
        {
            // Resetear posiciones de los caballos
            caballo1.Left = 0;
            caballo2.Left = 0;
            caballo3.Left = 0;

            // Iniciar el timer
            timerCarrera.Start();
        }

        private void timerCarrera_Tick(object sender, EventArgs e)
        {
            // Mover los caballos con velocidad aleatoria
            caballo1.Left += rnd.Next(5, 15);
            caballo2.Left += rnd.Next(5, 15);
            caballo3.Left += rnd.Next(5, 15);

            int meta = finish.Left - caballo1.Width-23;

            // Verificar si algún caballo ha llegado a la meta
            if (caballo1.Left >= meta || caballo2.Left >= meta || caballo3.Left >= meta)
            {
                timerCarrera.Stop();

                string ganador = "";

                if (caballo1.Left >= meta)
                    ganador = "Caballo 1";
                else if (caballo2.Left >= meta)
                    ganador = "Caballo 2";
                else if (caballo3.Left >= meta)
                    ganador = "Caballo 3";

                MessageBox.Show($"¡El ganador es {ganador}!");
            }
        }

   
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
    }
}
