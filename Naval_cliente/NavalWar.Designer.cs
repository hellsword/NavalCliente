namespace Naval_cliente
{
    partial class NavalWar
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
            this.chat_box = new System.Windows.Forms.TextBox();
            this.tablero1 = new System.Windows.Forms.Panel();
            this.tablero2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mensaje_txt = new System.Windows.Forms.TextBox();
            this.envia_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chat_box
            // 
            this.chat_box.Location = new System.Drawing.Point(86, 751);
            this.chat_box.Multiline = true;
            this.chat_box.Name = "chat_box";
            this.chat_box.Size = new System.Drawing.Size(1184, 123);
            this.chat_box.TabIndex = 0;
            // 
            // tablero1
            // 
            this.tablero1.Location = new System.Drawing.Point(12, 80);
            this.tablero1.Name = "tablero1";
            this.tablero1.Size = new System.Drawing.Size(665, 665);
            this.tablero1.TabIndex = 1;
            // 
            // tablero2
            // 
            this.tablero2.Location = new System.Drawing.Point(728, 80);
            this.tablero2.Name = "tablero2";
            this.tablero2.Size = new System.Drawing.Size(665, 665);
            this.tablero2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mi Tablero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1141, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tablero Rival";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(683, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 34);
            this.label3.TabIndex = 5;
            this.label3.Text = "VS";
            // 
            // mensaje_txt
            // 
            this.mensaje_txt.Location = new System.Drawing.Point(86, 885);
            this.mensaje_txt.Name = "mensaje_txt";
            this.mensaje_txt.Size = new System.Drawing.Size(954, 22);
            this.mensaje_txt.TabIndex = 6;
            // 
            // envia_btn
            // 
            this.envia_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.envia_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.envia_btn.Location = new System.Drawing.Point(1087, 880);
            this.envia_btn.Name = "envia_btn";
            this.envia_btn.Size = new System.Drawing.Size(89, 32);
            this.envia_btn.TabIndex = 7;
            this.envia_btn.Text = "Enviar";
            this.envia_btn.UseVisualStyleBackColor = false;
            // 
            // NavalWar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1358, 928);
            this.Controls.Add(this.envia_btn);
            this.Controls.Add(this.mensaje_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablero2);
            this.Controls.Add(this.tablero1);
            this.Controls.Add(this.chat_box);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "NavalWar";
            this.Text = "NavalWar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox chat_box;
        private System.Windows.Forms.Panel tablero1;
        private System.Windows.Forms.Panel tablero2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mensaje_txt;
        private System.Windows.Forms.Button envia_btn;
    }
}