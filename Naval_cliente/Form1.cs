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
                        //envia_nombre_cliente(username);
                        //thread = new Thread(o => RecibeDatos((TcpClient)o));
                        Form1.CheckForIllegalCrossThreadCalls = false;

                        chat_text.Text = "Conectado al servidor con ip: " + ip + " y port: " + PORT + "\n\n";

                        //Desplazar el cursor del TextBox hasta el final
                        chat_text.SelectionStart = chat_text.Text.Length;
                        chat_text.ScrollToCaret();

                        thread.Start(client);
                    }
                }
                catch (SocketException se)
                {
                    chat_text.Text = "No se pudo conectar al servidor: " + se.Message.ToString() + "\n";

                    //Desplazar el cursor del TextBox hasta el final
                    chat_text.SelectionStart = chat_text.Text.Length;
                    chat_text.ScrollToCaret();
                }

            }
            else
            {
                chat_text.Text = chat_text.Text + "Ya se encuentra conectado \n";

                //Desplazar el cursor del TextBox hasta el final
                chat_text.SelectionStart = chat_text.Text.Length;
                chat_text.ScrollToCaret();
            }
        }
    }
}
