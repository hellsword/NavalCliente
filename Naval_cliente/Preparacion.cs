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
    public partial class Preparacion : Form
    {
        int num_casill = 1;
        List<clsDato> datos = new List<clsDato>();
        List<clsbarco> barcos = new List<clsbarco>();
        List<embarcacion> embarcacion = new List<embarcacion>();
        Graphics papel;
        int[,] tablero = new int[20, 20];

        public Preparacion()
        {
            InitializeComponent();
            jugar_btn.Hide();

        }

        private void chat_text_TextChanged(object sender, EventArgs e)
        {
            //Desplazar el cursor del TextBox hasta el final
            chat_text.SelectionStart = chat_text.Text.Length;
            chat_text.ScrollToCaret();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.envia_mensaje("config:nombre:portaaviones,inicio:1,fin:5-nombre:destructor,inicio:381,fin:384-nombre:blabla,inicio:20,fin:60-nombre:fragata1,inicio:21,fin:63");
           */
            
           
            int i, j, xi = 0, yi = 0;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);

            for (i = 0; i < 20; i++)
            {

                for (j = 0; j < 20; j++)
                {
                    clsDato lista;
                    lista = new clsDato();
                    papel.DrawRectangle(lapiz, xi, yi, 20, 20);
                    string casilla = num_casill.ToString();
                    using (Font myFont = new Font("Arial", 8))
                    {
                        papel.DrawString(casilla, myFont, Brushes.Black, new PointF(xi, yi));
                    }
                    // se agregan datos a la lista
                    tablero[i, j] = num_casill;
                    lista.casilla = num_casill;
                    lista.i = i;
                    lista.j = j;
                    lista.xi = xi;
                    lista.yi = yi;
                    datos.Add(lista); // se agregan elementos a la lista 
                    xi = xi + 20;
                    num_casill = num_casill + 1;
                }
                xi = 0;
                yi = yi + 20;
            }

            clsbarco bar;
            bar = new clsbarco();
            bar.nombre = "portaaviones";
            bar.espacio = 5;
            barcos.Add(bar);

            clsbarco bar1;
            bar1 = new clsbarco();
            bar1.nombre = "destructor";
            bar1.espacio = 4;
            barcos.Add(bar1);

            clsbarco bar2;
            bar2 = new clsbarco();
            bar2.nombre = "fragata1";
            bar2.espacio = 3;
            barcos.Add(bar2);

            clsbarco bar3;
            bar3 = new clsbarco();
            bar3.nombre = "fragata2";
            bar3.espacio = 3;
            barcos.Add(bar3);

            clsbarco bar4;
            bar4 = new clsbarco();
            bar4.nombre = "submarino";
            bar4.espacio = 2;
            barcos.Add(bar4);

            for (i = 0; i < 5; i++)
            {
                comboBox1.Items.Add(barcos[i].nombre);
            }

            for (i = 0; i < 5; i++)
            {
                listBox1.Items.Add(barcos[i].nombre + ":  " + barcos[i].espacio);
            }
            button1.Hide();
           
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Add(barcos[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string bar = comboBox1.Text;

            int rango_in = int.Parse(inicio.Text);
            int rango_fn = int.Parse(fin.Text);
            int rangox1 = 0, rangoy1 = 0, rangox2 = 0, rangoy2 = 0;
            int i, j = 0, aux = 0;
            int resul = 0;

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            System.Drawing.Graphics formGraphics;

            formGraphics = pictureBox1.CreateGraphics();
            papel = pictureBox1.CreateGraphics();

            for (i = 0; i < datos.Count; i++)
            {
                for (j = 0; j < datos.Count; j++)
                {
                    if (rango_in == datos[i].casilla && rango_fn == datos[j].casilla)
                    {
                        if (datos[i].i == datos[j].i)
                        {//busca en forma horizontal
                            if (datos[i].j < datos[j].j)
                            {
                                rangoy1 = datos[i].j;
                                rangox1 = datos[i].i;

                                rangox2 = datos[j].i;
                                rangoy2 = datos[j].j;
                            }
                            else
                            {

                                rangoy1 = datos[j].j;
                                rangox1 = datos[j].i;

                                rangox2 = datos[i].i;
                                rangoy2 = datos[i].j;
                            }
                            resul = rangoy2 - rangoy1;
                        }
                        else if (datos[i].j == datos[j].j)
                        {//busqueda en forma vertical
                            if (datos[i].i < datos[j].i)
                            {
                                rangoy1 = datos[i].j;
                                rangox1 = datos[i].i;

                                rangox2 = datos[j].i;
                                rangoy2 = datos[j].j;
                            }
                            else
                            {

                                rangoy1 = datos[j].j;
                                rangox1 = datos[j].i;

                                rangox2 = datos[i].i;
                                rangoy2 = datos[i].j;
                            }

                            resul = rangox2 - rangox1;
                        }
                        else
                        {//busqueda en diagonal
                            if (datos[i].i < datos[j].i)
                            {
                                rangoy1 = datos[i].j;
                                rangox1 = datos[i].i;

                                rangox2 = datos[j].i;
                                rangoy2 = datos[j].j;
                            }
                            else
                            {

                                rangoy1 = datos[j].j;
                                rangox1 = datos[j].i;

                                rangox2 = datos[i].i;
                                rangoy2 = datos[i].j;
                            }

                            resul = rangox2 - rangox1;
                        }

                    }
                }

            }

            for (i = 0; i < barcos.Count; i++)
            {
                if (bar == barcos[i].nombre)
                {
                    aux = barcos[i].espacio;
                }
            }

            if (aux - 1 != resul)
            {
                MessageBox.Show("no se puede realizar esta operacion");
            }
            else
            {
                //MessageBox.Show("se puede realizar esta operacion "+resul);
                int k = 0, var = resul;

                for (i = 0; i < datos.Count; i++)
                {
                    if (rangox1 == datos[i].i && rangoy1 == datos[i].j)
                    {

                        while (resul >= 0)
                        {
                            formGraphics.FillRectangle(myBrush, new Rectangle(datos[i + k].xi, datos[i + k].yi, 20, 20));
                            string casilla = datos[i + k].casilla.ToString();
                            using (Font myFont = new Font("Arial", 8))
                            {
                                papel.DrawString(casilla, myFont, Brushes.White, new PointF(datos[i + k].xi, datos[i + k].yi));

                            }
                            if (rangox1 == rangox2 && rangoy1 != rangoy2)
                            {// horizontal
                                k = k + 1;
                            }
                            if (rangox1 != rangox2 && rangoy1 == rangoy2)
                            {//vertical 
                                k = k + 20;
                            }
                            if (rangox1 + var == rangox2 && rangoy1 + var == rangoy2)
                            {
                                k = k + 21;
                            }
                            if (rangox1 + var == rangox2 && rangoy1 - var == rangoy2)
                            {
                                k = k + 19;
                            }


                            resul = resul - 1;
                        }

                    }

                }

                embarcacion emb = new embarcacion();
                emb.nombre = bar;
                emb.inicio = rango_in;
                emb.fin = rango_fn;
                emb.estado = "vivo";
                embarcacion.Add(emb);

                comboBox1.Items.Remove(bar);
                listBox1.Items.Remove(bar + ":  " + aux);
                inicio.Text = "";
                fin.Text = "";
                resul = 0;
                rangox1 = 0;
                rangoy1 = 0;
                rangox2 = 0;
                rangoy2 = 0;

                if(comboBox1.Items.Count == 0)
                {
                    jugar_btn.Show();
                }
            }
        }

        public void jugar_btn_Click(object sender, EventArgs e)
        {
            string config = "config:";


            for (int i = 0; i < embarcacion.Count(); i++)
            {
                config = config + "nombre:"+ embarcacion[i].nombre + ",";
                config = config + "inicio:"+ embarcacion[i].inicio + ",";
                config = config + "fin:" + embarcacion[i].fin;
                if(i < embarcacion.Count()-1)
                    config = config + "-";
                //anuncio = anuncio + embarcacion[i].estado + "-";
                //anuncio = anuncio + "\r\n";
            }
            
            //Invoca la funcion enviar_mensaje en el formulario form1 mediante una Interfaz
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.envia_mensaje(config);

            chat_text.Text = chat_text.Text + "esperando al rival... \r\n";
        }
    }
 }

