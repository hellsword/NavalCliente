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
                        ns = client.GetStream();
                        envia_mensaje(username);

                        Form1.CheckForIllegalCrossThreadCalls = false;

                        //thread = new Thread(o => RecibeDatos((TcpClient)o));  

                        prepa.chat_text.Text = "Conectado al servidor con ip: " + ip + " y port: " + PORT + "\n\n";
                        //thread.Start(client);
                        envia_mensaje("zzz");
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

            prepa.Show(this);

        }


        public void imprime()
        {
            prepa.chat_text.Text = prepa.chat_text.Text + "zzzzzzzzzzzz";
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

        #region IForm Members
        public void envia_mensaje(string data)
        {
            /*
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            ns.Write(buffer, 0, buffer.Length);
            */
            ip_text.Text = ip_text.Text + data;
        }
        #endregion


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

        private void button1_Click(object sender, EventArgs e)
        {
            envia_mensaje("bla");
        }
    }
}
