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
        int num_casill = 1,contador=0;
        List<clsDato> datos = new List<clsDato>();
        List<clsbarco> barcos = new List<clsbarco>();
        List<embarcacion> embarcacion = new List<embarcacion>();
        List<Almacen> ver_casill = new List<Almacen>();
        String[] celda = new string[2];
        Button[,] boton_casilla = new Button[20, 20];
        public NavalWar navalWar = new NavalWar();

        public string username;
        public string permiso;

        public Preparacion()
        {
            InitializeComponent();

            chat_text.Text = chat_text.Text + username;

            //jugar_btn.Hide();

            int i, j;
            celda[0] = "";
            celda[1] = "";

            for ( i = 0; i < 20; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    boton_casilla[i, j] = new Button
                    {
                        Font = new Font("Arial", 6),
                        Width = 31,
                        Height = 31,
                        Text = String.Format("{0}", num_casill),// es el boton en su campo texto
                        Top = i * 31,
                        Left = j * 31
                    };
                    //Panel contenedor = new Panel();
                    this.Controls.Add(boton_casilla[i, j]);
                    //asientoSel = boton[i, j].Text; //el campo texto de boton lo paso a una variable pero toma el ultimo valor del ciclo for

                    boton_casilla[i, j].Click += new System.EventHandler(boton_Click);
                    clsDato lista;
                    lista = new clsDato();
                    lista.casilla = num_casill;
                    lista.i = i;
                    lista.j = j;
                    lista.xi = Top;
                    lista.yi = Left;
                    datos.Add(lista);

                    Almacen lista2;
                    lista2 = new Almacen();

                    lista2.numero = num_casill;
                    lista2.estado = "libre";
                    ver_casill.Add(lista2);

                    num_casill = num_casill + 1;
                }
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



        }

        private void boton_Click(object sender, EventArgs e)
        {
            Button botonSel = sender as Button;

            //comprueba que el boton no haya sido seleccionado antes
            //en caso de ya existir, lo elimina
            if (celda[0] == botonSel.Text)
            {
                celda[0] = "";
                inicio.Text = celda[0];
                botonSel.BackColor = Color.Black;
            }
            else if (celda[1] == botonSel.Text)
            {
                celda[1] = "";
                fin.Text = celda[1];
                botonSel.BackColor = Color.Black;
            }

            //si el boton no ha sido seleccionado, registra su valor
            if (celda[0] == "")
            {
                celda[0] = botonSel.Text;
                inicio.Text = celda[0];
                botonSel.BackColor = Color.Red;
            }
            else if (celda[1] == "")
            {
                celda[1] = botonSel.Text;
                fin.Text = celda[1];
                botonSel.BackColor = Color.Red;
            }

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
            int resul = 0,resul2=0;

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

                            resul2 = Math.Abs(rangoy2 - rangoy1);
                            resul = rangox2 - rangox1;
                            if ((resul - resul2) == 0)
                            {
                                resul = rangox2 - rangox1;
                            }
                            else {
                                resul = 0;
                            }
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


            //MessageBox.Show("resul2 " + resul2);
            if (aux - 1 != resul)
            {
                MessageBox.Show("no se puede realizar esta operacion");

                celda[0] = "";
                celda[1] = "";
                for (i = 0; i < datos.Count; i++)
                {
                    for (j = 0; j < datos.Count; j++)
                    {
                        if (rango_in == datos[i].casilla && rango_fn == datos[j].casilla)
                        {
                            boton_casilla[datos[i].i, datos[i].j].BackColor = Color.Black;
                            boton_casilla[datos[j].i, datos[j].j].BackColor = Color.Black;
                        }
                    }

                }
            }
            else
            {
                //MessageBox.Show("se puede realizar esta operacion "+resul);
                int k = 0, var = resul, verificador = 0, var2 = resul;

                for (i = 0; i < datos.Count; i++)
                {
                    if (rangox1 == datos[i].i && rangoy1 == datos[i].j)
                    {
                        while (var2 >= 0) {
                            if (datos[i + k].casilla == ver_casill[i + k].numero)
                            {
                                if (ver_casill[i + k].estado == "libre") { // se cuenta si las casillas que se ocuparan estan libre o no 
                                    verificador = verificador + 1;
                                    
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
                                {// para movimientos en diagonal 
                                    k = k + 21;
                                }
                                if (rangox1 + var == rangox2 && rangoy1 - var == rangoy2)
                                {// para movimientos en diagonal 
                                    k = k + 19;
                                }
                            }
                            var2 = var2 - 1;
                        }
                    }
                }
                
                //MessageBox.Show("resul " + resul);
                //MessageBox.Show("verificador " + verificador);
                k = 0;
                if (resul == verificador - 1)
                {
                    for (i = 0; i < datos.Count; i++)
                    {
                        if (rangox1 == datos[i].i && rangoy1 == datos[i].j)
                        {

                            while (resul >= 0)
                            {
                                boton_casilla[datos[i + k].i, datos[i + k].j].BackColor = Color.Blue;
                                boton_casilla[datos[i + k].i, datos[i + k].j].Enabled = false; // se que se precione este boton como uno de los rangos 
                                ver_casill[i + k].estado = "ocupado"; // se marcan las casillas 
                                if (rangox1 == rangox2 && rangoy1 != rangoy2)
                                {// horizontal
                                    k = k + 1;
                                }
                                if (rangox1 != rangox2 && rangoy1 == rangoy2)
                                {//vertical 
                                    k = k + 20;
                                }
                                if (rangox1 + var == rangox2 && rangoy1 + var == rangoy2)
                                {// para movimientos en diagonal 
                                    k = k + 21;
                                }
                                if (rangox1 + var == rangox2 && rangoy1 - var == rangoy2)
                                {// para movimientos en diagonal 
                                    k = k + 19;
                                }


                                resul = resul - 1;
                            }

                        }

                    }
                    contador = contador + 1; 
                    comboBox1.Items.Remove(bar);
                    listBox1.Items.Remove(bar + ":  " + aux);
                }
                else {
                    MessageBox.Show("alguna de las casillas dentro del rango ya esta ocupada. \nVuelva a elegir un nuevo rango de casillas");

                    for (i = 0; i < datos.Count; i++)
                    {
                        for (j = 0; j < datos.Count; j++)
                        {
                            if (rango_in == datos[i].casilla && rango_fn == datos[j].casilla)
                            {
                                boton_casilla[datos[i].i, datos[i].j].BackColor = Color.Black;
                                boton_casilla[datos[j].i, datos[j].j].BackColor = Color.Black;
                            }
                        }

                    }

                }

                embarcacion emb = new embarcacion();
                emb.nombre = bar;
                emb.inicio = rango_in;
                emb.fin = rango_fn;
                emb.estado = "vivo";
                embarcacion.Add(emb);

                
                inicio.Text = "";
                fin.Text = "";
                resul = 0;
                rangox1 = 0;
                rangoy1 = 0;
                rangox2 = 0;
                rangoy2 = 0;
                celda[0] = "";
                celda[1] = "";
                verificador = 0;

                if (contador == 5)
                {
                    button2.Enabled = false;
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
                formInterface.recibe_flota(config);

            if (formInterface != null)
                formInterface.envia_mensaje(config);

            if (formInterface != null)
                formInterface.envia_mensaje("rival:" + username);

            chat_text.Text = chat_text.Text + "esperando al rival... \r\n";
           










            /*

            string config = "config:nombre:portaaviones,inicio:1,fin:5-nombre:fragata1,inicio:94,fin:134-nombre:destructor,inicio:256,fin:313-nombre:fragata2,inicio:182,fin:222-nombre:submarino,inicio:106,fin:127";

            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.recibe_flota(config);

            if (formInterface != null)
                formInterface.envia_mensaje(config);

            if (formInterface != null)
                formInterface.envia_mensaje("rival:" + username);
            */


            /*
            bool turno = Convert.ToBoolean(permiso);

            if (turno && contador == 5)
            {
                string config = "config:nombre:portaaviones,inicio:1,fin:5-nombre:fragata1,inicio:94,fin:134-nombre:destructor,inicio:256,fin:313-nombre:fragata2,inicio:182,fin:222-nombre:submarino,inicio:106,fin:127";

                IForm formInterface = this.Owner as IForm;

                if (formInterface != null)
                    formInterface.recibe_flota(config);

                if (formInterface != null)
                    formInterface.envia_mensaje(config);

                if (formInterface != null)
                    formInterface.envia_mensaje("rival:" + username);
            }
            else {

                MessageBox.Show("todavia no se encuentra rival");
            }
            */


        }

        private void restriccion(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar)) // para que no ingresen caracteres en los textbox
            {
                e.Handled = true;
            }



        }

    }
 }

