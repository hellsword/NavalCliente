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

        public NavalWar()
        {
            InitializeComponent();


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

                    //boton_casilla[i, j].Click += new System.EventHandler(boton_Click);
                }
            }
        }
    }
}
