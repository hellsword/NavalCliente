namespace Naval_cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ip_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.puerto_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.username_text = new System.Windows.Forms.TextBox();
            this.conectar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batalla Naval";
            // 
            // ip_text
            // 
            this.ip_text.Location = new System.Drawing.Point(212, 107);
            this.ip_text.Margin = new System.Windows.Forms.Padding(5);
            this.ip_text.Name = "ip_text";
            this.ip_text.Size = new System.Drawing.Size(214, 35);
            this.ip_text.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Puerto: ";
            // 
            // puerto_text
            // 
            this.puerto_text.Location = new System.Drawing.Point(212, 175);
            this.puerto_text.Name = "puerto_text";
            this.puerto_text.Size = new System.Drawing.Size(214, 35);
            this.puerto_text.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tu Nombre: ";
            // 
            // username_text
            // 
            this.username_text.Location = new System.Drawing.Point(212, 242);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(214, 35);
            this.username_text.TabIndex = 6;
            // 
            // conectar_btn
            // 
            this.conectar_btn.BackColor = System.Drawing.Color.LimeGreen;
            this.conectar_btn.ForeColor = System.Drawing.SystemColors.Window;
            this.conectar_btn.Location = new System.Drawing.Point(320, 318);
            this.conectar_btn.Name = "conectar_btn";
            this.conectar_btn.Size = new System.Drawing.Size(137, 39);
            this.conectar_btn.TabIndex = 7;
            this.conectar_btn.Text = "Conectar";
            this.conectar_btn.UseVisualStyleBackColor = false;
            this.conectar_btn.Click += new System.EventHandler(this.conectar_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(532, 392);
            this.Controls.Add(this.conectar_btn);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.puerto_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip_text);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox puerto_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.Button conectar_btn;
    }
}

