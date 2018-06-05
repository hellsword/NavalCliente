namespace Naval_cliente
{
    partial class Preparacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chat_text = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.inicio = new System.Windows.Forms.TextBox();
            this.fin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Barco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jugar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chat_text
            // 
            this.chat_text.Location = new System.Drawing.Point(674, 464);
            this.chat_text.Multiline = true;
            this.chat_text.Name = "chat_text";
            this.chat_text.Size = new System.Drawing.Size(246, 143);
            this.chat_text.TabIndex = 0;
            this.chat_text.Text = "Mensajes de chat (prueba)   -        borrar despues, esto debe ir en la ventana s" +
    "iguiente";
            this.chat_text.TextChanged += new System.EventHandler(this.chat_text_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(654, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Barcos";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ImageKey = "(ninguno)";
            this.button2.Location = new System.Drawing.Point(806, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // inicio
            // 
            this.inicio.Location = new System.Drawing.Point(806, 144);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(114, 24);
            this.inicio.TabIndex = 7;
            this.inicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.restriccion);
            // 
            // fin
            // 
            this.fin.Location = new System.Drawing.Point(806, 187);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(114, 24);
            this.fin.TabIndex = 8;
            this.fin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.restriccion);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(758, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(772, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fin";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(695, 250);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 208);
            this.listBox1.TabIndex = 11;
            // 
            // Barco
            // 
            this.Barco.AutoSize = true;
            this.Barco.Location = new System.Drawing.Point(692, 229);
            this.Barco.Name = "Barco";
            this.Barco.Size = new System.Drawing.Size(52, 18);
            this.Barco.TabIndex = 12;
            this.Barco.Text = "Barco:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(740, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Espacios ";
            // 
            // jugar_btn
            // 
            this.jugar_btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.jugar_btn.Location = new System.Drawing.Point(806, 32);
            this.jugar_btn.Name = "jugar_btn";
            this.jugar_btn.Size = new System.Drawing.Size(114, 36);
            this.jugar_btn.TabIndex = 14;
            this.jugar_btn.Text = "Jugar";
            this.jugar_btn.UseVisualStyleBackColor = true;
            this.jugar_btn.Click += new System.EventHandler(this.jugar_btn_Click);
            // 
            // Preparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1000, 619);
            this.Controls.Add(this.jugar_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Barco);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.inicio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chat_text);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Preparacion";
            this.Text = "Preparacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox chat_text;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox inicio;
        private System.Windows.Forms.TextBox fin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Barco;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button jugar_btn;
    }
}