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
    public partial class Form1 : Form
    {
        public string username;
        public NetworkStream ns;
        public TcpClient client = new TcpClient();
        public Thread thread;
        public Preparacion prepa = new Preparacion();

        int num_casill = 1;
        //List<clsLista> datos = new List<clsLista>();
        Graphics papel;


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
                        
                        client.Connect(ip, PORT);

                        //Console.WriteLine("Cliente conectado!!");
                        ns = client.GetStream();
                        envia_nombre_cliente(username);
                        thread = new Thread(o => RecibeDatos((TcpClient)o));
                        Form1.CheckForIllegalCrossThreadCalls = false;

                        prepa.chat_text.Text = "Conectado al servidor con ip: " + ip + " y port: " + PORT + "\n\n";

                        /*
                        int i, j, xi = 0, yi = 0;
                        papel = prepa.pi//pictureBox1.CreateGraphics();
                        Pen lapiz = new Pen(Color.Black);

                        for (i = 0; i < 20; i++)
                        {

                            for (j = 0; j < 20; j++)
                            {
                                papel.DrawRectangle(lapiz, xi, yi, 20, 20);
                                string casilla = num_casill.ToString();
                                using (Font myFont = new Font("Arial", 8))
                                {
                                    papel.DrawString(casilla, myFont, Brushes.Black, new PointF(xi, yi));
                                }

                                xi = xi + 20;
                                num_casill = num_casill + 1;
                            }
                            xi = 0;
                            yi = yi + 20;
                        }*/

                        thread.Start(client);
                    }
                }
                catch (SocketException se)
                {
                    prepa.chat_text.Text = "No se pudo conectar al servidor: " + se.Message.ToString() + "\n";
                }

            }
            else
            {
                prepa.chat_text.Text = prepa.chat_text.Text + "Ya se encuentra conectado \n";
            }
            

            prepa.Show();
        }


        private void RecibeDatos(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                prepa.chat_text.Text = prepa.chat_text.Text + Encoding.ASCII.GetString(receivedBytes, 0, byte_count);

            }
        }


        private void envia_nombre_cliente(string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            ns.Write(buffer, 0, buffer.Length);
        }


        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (client.Connected)
            {
                string mensaje_final = "ahi te van los datos estadisticos vieeeeja, son del usuario: " + username;
                byte[] buffer = Encoding.ASCII.GetBytes(mensaje_final);
                ns.Write(buffer, 0, buffer.Length);

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
    }
}
