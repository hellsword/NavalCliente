using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_cliente
{
    public partial class NavalWar : Form
    {
        public Button[,] boton_casilla_jugador = new Button[20, 20];
        public Button[,] boton_casilla_rival = new Button[20, 20];
        public string username;
        public string rival;
        bool turno_player;
        public turno tur = new turno();
        int inicio = 0;
        public List<embarcacion> mi_flota = new List<embarcacion>();
        public List<embarcacion> embarcaciones = new List<embarcacion>();
        int flota_restante_jugador = 0;
        int flota_restante_rival = 5;

        public NavalWar()
        {
            InitializeComponent();
            
            /*
            Form1 form1 = new Form1();
            label1.Text = form1.username;
            */

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    boton_casilla_jugador[i, j] = new Button
                    {
                        Font = new Font("Arial", 4, FontStyle.Bold),
                        Width = 25,
                        Height = 25,
                        Text = String.Format("{0}", i * 20 + j + 1),// es el boton en su campo texto
                        Top = i * 25,
                        Left = j * 25
                    };

                    //Panel contenedor = new Panel();
                    tablero1.Controls.Add(boton_casilla_jugador[i, j]);
                    //asientoSel = boton[i, j].Text; //el campo texto de boton lo paso a una variable pero toma el ultimo valor del ciclo for

                    //boton_casilla[i, j].Click += new System.EventHandler(boton_Click);

                }
            }
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    boton_casilla_rival[i, j] = new Button
                    {
                        Font = new Font("Arial", 4, FontStyle.Bold),
                        Width = 25,
                        Height = 25,
                        Text = String.Format("{0}", i + "," + j),// es el boton en su campo texto
                        Top = i * 25,
                        Left = j * 25
                    };

                    //Panel contenedor = new Panel();
                    tablero2.Controls.Add(boton_casilla_rival[i, j]);
                    //asientoSel = boton[i, j].Text; //el campo texto de boton lo paso a una variable pero toma el ultimo valor del ciclo for

                    boton_casilla_rival[i, j].Click += new System.EventHandler(boton_Click);
                }
            }

            
        }


        public void recibe_mi_flota()
        {
            foreach (embarcacion c in mi_flota)
            {
                flota_restante_jugador++;
                for (int i = 0; i < c.celdas.Count; i++)
                {
                    boton_casilla_jugador[c.celdas[i], c.celdas[i + 1]].BackColor = Color.AliceBlue;
                    i++;
                }
                
            }
        }


        public void recibe_indices(string data)
        {
            string[] datos = data.Split(',');
            int i = Convert.ToInt32(datos[0]);
            int j = Convert.ToInt32(datos[1]);

            comprueba_casilla(i, j, mi_flota, boton_casilla_jugador);
        }


        private void comprueba_casilla(int fila, int columna, List<embarcacion> flota, Button[,] boton)
        {
            bool es_mar = true;


            foreach (embarcacion c in flota)
            {
                if (c.celdas.Count() != 0)
                {
                    for (int i = 0; i < c.celdas.Count(); i++)
                    {
                        if (fila == c.celdas[i] && columna == c.celdas[i + 1])
                        {
                            es_mar = false;
                            c.celdas.RemoveAt(i + 1);
                            c.celdas.RemoveAt(i);
                            chat_box.Text = chat_box.Text + "celdas:  "+ c.celdas.Count() +"\r\n";
                        }
                        i++;
                    }

                    if (c.celdas.Count() == 0)
                    {
                        chat_box.Text = chat_box.Text + "Una de nuestras embarcaciones ha sido destruida \r\n";
                        flota_restante_jugador--;
                    }
                }
                
            }

            chat_box.Text = chat_box.Text + "Tenemos " + flota_restante_jugador + " embarcaciones restantes \r\n";

            marca_casilla(fila, columna, es_mar, boton);
        }


        private void comprueba_casilla_enemiga(int fila, int columna, List<embarcacion> flota, Button[,] boton)
        {
            bool es_mar = true;

            foreach (embarcacion c in flota)
            {
                if (c.celdas.Count() != 0)
                {
                    for (int i = 0; i < c.celdas.Count(); i++)
                    {
                        if (fila == c.celdas[i] && columna == c.celdas[i + 1])
                        {
                            es_mar = false;
                            c.celdas.RemoveAt(i + 1);
                            c.celdas.RemoveAt(i);
                            chat_box.Text = chat_box.Text + "celdas:  " + c.celdas.Count() + "\r\n";
                        }
                        i++;
                    }

                    if (c.celdas.Count() == 0)
                    {
                        chat_box.Text = chat_box.Text + "Embarcacion enemiga destruida \r\n";
                        c.estado = "destruido";
                        flota_restante_rival--;
                    }
                }
            }

            if (victoria())
            {
                chat_box.Text = chat_box.Text + "Has ganado!!!!!!!!!! \r\n";
                IForm formInterface = this.Owner as IForm;

                if (formInterface != null)
                    formInterface.envia_mensaje("victoria:"+username);
            }

            chat_box.Text = chat_box.Text + "quedan " + flota_restante_rival + " embarcaciones enemigas restantes \r\n";
            marca_casilla(fila, columna, es_mar, boton);
        }


        private bool victoria()
        {
            foreach (embarcacion c in embarcaciones)
            {
                if (c.estado == "vivo")
                    return false;
            }

            return true;
        }


        private void marca_casilla(int fila, int columna, bool es_mar, Button[,] boton)
        {
            if (es_mar)
            {
                boton[fila, columna].BackColor = Color.Red;
            }
            else
            {
                boton[fila, columna].BackColor = Color.DarkOliveGreen;
            }

        }
       

        public void establece_turno(string turno)
        {
            turno_player = Convert.ToBoolean(turno);
            chat_box.Text = chat_box.Text + "turno: " + turno_player + "\r\n";

            if(inicio == 0)
            {
                recibe_mi_flota();
                inicio = 1;
            }
            
            control_turno();
        }

        
        private void control_turno()
        {
            
            if (turno_player)
            {
                this.Enabled = true;
                tur.Hide();
                chat_box.Text = chat_box.Text + "cierra dialog \r\n";
            }
            
        }


        public void establece_usuarios(string username, string rival)
        {
            this.username = username;
            this.rival = rival;
            label1.Text = username;
            label2.Text = rival;
            //chat_box.Text = chat_box.Text + username + " vs " + rival;
        }


        public void escribe_mensaje(string mensaje)
        {
            chat_box.Text = chat_box.Text + mensaje + "\r\n";
        }


        private void envia_btn_Click(object sender, EventArgs e)
        {
            chat_box.Text = chat_box.Text + "Yo: " + mensaje_txt.Text + "\r\n";
            //Invoca la funcion enviar_mensaje en el formulario form1 mediante una Interfaz
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.envia_mensaje("mensaje:"+username + ": " + mensaje_txt.Text);
        }


        private void boton_Click(object sender, EventArgs e)
        {

            /*
            chat_box.Text = chat_box.Text + "Has ganado!!!!!!!!!! \r\n";
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.envia_mensaje("victoria:" + username);

            */


            
            
            Button botonSel = sender as Button;
            
            //Invoca la funcion enviar_mensaje en el formulario form1 mediante una Interfaz
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null && turno_player)
            {
                string[] datos = botonSel.Text.Split(',');
                int i = Convert.ToInt32(datos[0]);
                int j = Convert.ToInt32(datos[1]);

                comprueba_casilla_enemiga(i, j, embarcaciones, boton_casilla_rival);

                formInterface.envia_mensaje("mov:" + botonSel.Text);

                turno_player = false;
                tur.Show(this);
                this.Enabled = false;
                //tur.label1.Text = tur.label1.Text + username;
                chat_box.Text = chat_box.Text + "turno: " + turno_player + "\r\n";
                chat_box.Text = chat_box.Text + "abre dialog \r\n";
                formInterface.envia_mensaje("turno:" + true);
            }
            

               /*
            else if (formInterface != null && !turno_player)
            {
                turno_player = true;
                this.Enabled = true;
                tur.Hide();
                chat_box.Text = chat_box.Text + "cierra dialog \r\n";
                formInterface.envia_mensaje("turno:" + false);
            }
            */

        }

        

        private void NavalWar_Load(object sender, EventArgs e)
        {
        }

        private void NavalWar_Shown(object sender, EventArgs e)
        {
        }

        private void chat_box_TextChanged(object sender, EventArgs e)
        {
            chat_box.SelectionStart = chat_box.Text.Length;
            chat_box.ScrollToCaret();
        }
    }
}
