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
    }
}
