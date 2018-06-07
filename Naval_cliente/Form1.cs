using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Naval_cliente
{
    public partial class Form1 : Form, IForm
    {
        public string username;
        public string rival;
        public string permiso;
        public NetworkStream ns;
        public TcpClient client = new TcpClient();
        public Thread thread;
        public Preparacion prepa = new Preparacion();
        public NavalWar navalWar = new NavalWar();
        public string turno;

        int num_casill = 1;
        List<embarcacion> embarcaciones = new List<embarcacion>();
        List<embarcacion> mi_flota = new List<embarcacion>();
        Graphics papel;

        static readonly object _lock = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void conectar_btn_Click(object sender, EventArgs e)
        {
            if (!client.Connected)
            {
                try
                {
                    if (ip_text.Text.Length > 0 && puerto_text.Text.Length > 0 && username_text.Text.Length > 0)
                    {
                        IPAddress ip = IPAddress.Parse(ip_text.Text);
                        int PORT = Int32.Parse(puerto_text.Text);
                        username = username_text.Text;
                        prepa.username = username;
                        
                        client.Connect(ip, PORT);
                        ns = client.GetStream();
                        envia_mensaje(username);
                        

                        Form1.CheckForIllegalCrossThreadCalls = false;

                        thread = new Thread(o => RecibeDatos((TcpClient)o));  

                        prepa.chat_text.Text = "Conectado al servidor con ip: " + ip + " y port: " + PORT + "\r\n";
                        thread.Start(client);
                    }
                }
                catch (SocketException se)
                {
                    prepa.chat_text.Text = "No se pudo conectar al servidor: " + se.Message.ToString() + "\r\n";
                }

            }
            else
            {
                prepa.chat_text.Text = prepa.chat_text.Text + "Ya se encuentra conectado \r\n";
            }
            

            prepa.Show(this);
            navalWar.Show(this);
            navalWar.Hide();

        }


        public void recibe_flota(string data)
        {
            string[] datos = data.Split(':');
            recibe_embarcaciones(data, datos, mi_flota);
            navalWar.mi_flota = mi_flota;
        }
        

        private void RecibeDatos(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                string[] datos = data.Split(':');

                if (datos[0] == "config")
                {
                    recibe_embarcaciones(data, datos, embarcaciones);

                }
                else if (datos[0] == "ready")
                {
                    iniciar_juego();
                    navalWar.embarcaciones = embarcaciones;
                    //navalWar.mi_flota = embarcaciones;
                    turno = datos[1];
                    navalWar.establece_turno(turno);
                }
                else if (datos[0] == "turno")
                {
                    turno = datos[1];
                    navalWar.establece_turno(turno);
                }
                else if (datos[0] == "rival")
                {
                    rival = datos[1];

                    navalWar.establece_usuarios(username, rival);

                    //navalWar.chat_box.Text = navalWar.chat_box.Text + username + " vs " + rival;
                    prepa.chat_text.Text = prepa.chat_text.Text + rival;
                }
                else if (datos[0] == "mensaje")
                {
                    navalWar.escribe_mensaje(datos[1]);
                }
                else if (datos[0] == "mov")
                {
                    navalWar.recibe_indices(datos[1]);
                }
                else if (datos[0] == "victoria")
                {
                    Puntuacion puntuacion = new Puntuacion();
                    navalWar.tur.Hide();

                    string[] datos2 = datos[1].Split(',');

                    if (datos2[0] == "si")
                    {
                        puntuacion.label1.Text = "Victoria";
                        puntuacion.textBox1.Text = datos2[1] + "\r\n";
                        puntuacion.textBox1.Text = puntuacion.textBox1.Text + datos2[2] + "\r\n";
                        puntuacion.textBox1.Text = puntuacion.textBox1.Text + datos2[3] + "\r\n";
                    }
                    else if (datos2[0] == "no")
                    {
                        puntuacion.label1.Text = "Derrota";
                        puntuacion.textBox1.Text = datos2[1] + "\r\n";
                        puntuacion.textBox1.Text = puntuacion.textBox1.Text + datos2[2] + "\r\n";
                        puntuacion.textBox1.Text = puntuacion.textBox1.Text + datos2[3] + "\r\n";
                    }

                    puntuacion.ShowDialog(this);

                    navalWar.Dispose();
                    
                    Dispose();
                }
                /*
                else if (datos[0] == "permiso")
                {
                    prepa.permiso = datos[1];
                }
                */
            }

        }


        private void recibe_embarcaciones(string data, string[] datos, List<embarcacion> flota)
        {
            data = data.Substring(datos[0].Length + 1, data.Length - (datos[0].Length + 1));
            //MessageBox.Show(data);
            /*
            prepa.chat_text.Text = prepa.chat_text.Text + "data: " + data + "\r\n";
            prepa.chat_text.Text = prepa.chat_text.Text + "tamaño config: " + datos[0].Length + "\r\n";
            prepa.chat_text.Text = prepa.chat_text.Text + "tamaño data: " + data.Length + "\r\n";
            */
            datos = data.Split('-');

            for (int i = 0; i < datos.Length; i++)
            {

                string[] atributos = datos[i].Split(',');

                //prepa.chat_text.Text = prepa.chat_text.Text + valores[1] + "\r\n";

                embarcacion embarc = new embarcacion();
                embarc.nombre = atributos[0].Split(':')[1];
                embarc.inicio = Convert.ToInt32(atributos[1].Split(':')[1]);
                embarc.fin = Convert.ToInt32(atributos[2].Split(':')[1]);
                embarc.estado = "vivo";
                embarc.celdas = new List<int>();
                flota.Add(embarc);
                //navalWar.mi_flota.Add(embarc);
            }

            rellena_celdas(flota);
        }


        private void rellena_celdas(List<embarcacion> flota)
        {
            foreach (embarcacion c in flota)
            {
                /*
                navalWar.chat_box.Text = navalWar.chat_box.Text + "nombre: " + c.nombre + "\r\n";
                navalWar.chat_box.Text = navalWar.chat_box.Text + "inicio: " + c.inicio + "\r\n";
                navalWar.chat_box.Text = navalWar.chat_box.Text + "fin: " + c.fin + "\r\n";
                */

                int indice = c.inicio - 1;
                int inicio_fila = indice / 20;
                int inicio_columna = indice - inicio_fila * 20;

                indice = c.fin - 1;
                int fin_fila = indice / 20;
                int fin_columna = indice - fin_fila * 20;
                /*
                navalWar.chat_box.Text = navalWar.chat_box.Text + "inicio: " + inicio_fila + ", ";
                navalWar.chat_box.Text = navalWar.chat_box.Text + inicio_columna + "\r\n";
                navalWar.chat_box.Text = navalWar.chat_box.Text + "fin: " + fin_fila + ", ";
                navalWar.chat_box.Text = navalWar.chat_box.Text + fin_columna + "\r\n";
                */

                c.celdas.Add(inicio_fila);
                c.celdas.Add(inicio_columna);

                while (inicio_fila < fin_fila || inicio_columna < fin_columna)
                {
                    if (inicio_fila < fin_fila && inicio_columna < fin_columna)
                    {
                        inicio_fila++;
                        inicio_columna++;
                    }
                    else if (inicio_fila < fin_fila)
                    {
                        inicio_fila++;
                    }
                    else if (inicio_columna < fin_columna)
                    {
                        inicio_columna++;
                    }
                    c.celdas.Add(inicio_fila);
                    c.celdas.Add(inicio_columna);
                }
            }

        }


        private void iniciar_juego()
        {
            navalWar.Show(this);
            prepa.Dispose();
        }


        public void envia_mensaje(string data)
        {
            
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            ns.Write(buffer, 0, buffer.Length);
        }
        


        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (client.Connected)
            {
                client.Client.Shutdown(SocketShutdown.Send);
                thread.Join();
                ns.Close();
                client.Close();
                Application.Exit();
            }
            Application.Exit();
        }

        private void ip_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void puerto_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ip_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.Connected)
            {
                client.Client.Shutdown(SocketShutdown.Send);
                thread.Join();
                ns.Close();
                client.Close();
                Application.Exit();
            }
            Application.Exit();
        }
    }
}
