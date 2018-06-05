﻿using System;
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
        turno tur = new turno();

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
                        Text = String.Format("{0}", i * 20 + j + 1),// es el boton en su campo texto
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


        public void establece_turno(string turno)
        {
            turno_player = Convert.ToBoolean(turno);
            chat_box.Text = chat_box.Text + "turno: " + turno;

            control_turno();
        }


        private void control_turno()
        {
            if (!turno_player)
            {
                tur.ShowDialog(this);
            }
            else
            {
                tur.Hide();
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
            Button botonSel = sender as Button;
            botonSel.BackColor = Color.Red;

            //Invoca la funcion enviar_mensaje en el formulario form1 mediante una Interfaz
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null && turno_player)
                formInterface.envia_mensaje("turno:" + true);
            else if (formInterface != null && !turno_player)
                formInterface.envia_mensaje("turno:" + false);
        }
    }
}
