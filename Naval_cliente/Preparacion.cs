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
        //List<clsLista> datos = new List<clsLista>();
        Graphics papel;

        public Preparacion()
        {
            InitializeComponent();
            
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
            MessageBox.Show("1) Antes de empezar el juego, pocisionar los barcos\n 2) En cada partida se podra abordar una sola casilla\n 3) El que termine con todos los barcos del oponente gana");

            int i, j, xi = 0, yi = 0;
            papel = pictureBox1.CreateGraphics();
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
            }
        }
    }
}
