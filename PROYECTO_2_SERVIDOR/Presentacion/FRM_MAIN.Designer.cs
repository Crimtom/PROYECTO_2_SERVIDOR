namespace PROYECTO_2_SERVIDOR.Presentacion
{
    partial class FRM_MAIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.BT_MANTEN_PADRON = new System.Windows.Forms.Button();
            this.BT_SOCKET_COM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú Principal";
            // 
            // BT_MANTEN_PADRON
            // 
            this.BT_MANTEN_PADRON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_MANTEN_PADRON.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_MANTEN_PADRON.Location = new System.Drawing.Point(58, 99);
            this.BT_MANTEN_PADRON.Name = "BT_MANTEN_PADRON";
            this.BT_MANTEN_PADRON.Size = new System.Drawing.Size(263, 86);
            this.BT_MANTEN_PADRON.TabIndex = 1;
            this.BT_MANTEN_PADRON.Text = "Mantenimiento de Padrón";
            this.BT_MANTEN_PADRON.UseVisualStyleBackColor = true;
            this.BT_MANTEN_PADRON.Click += new System.EventHandler(this.BT_MANTEN_PADRON_Click);
            // 
            // BT_SOCKET_COM
            // 
            this.BT_SOCKET_COM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_SOCKET_COM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SOCKET_COM.Location = new System.Drawing.Point(58, 223);
            this.BT_SOCKET_COM.Name = "BT_SOCKET_COM";
            this.BT_SOCKET_COM.Size = new System.Drawing.Size(263, 86);
            this.BT_SOCKET_COM.TabIndex = 2;
            this.BT_SOCKET_COM.Text = "Socket de comunicación";
            this.BT_SOCKET_COM.UseVisualStyleBackColor = true;
            this.BT_SOCKET_COM.Click += new System.EventHandler(this.BT_SOCKET_COM_Click);
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 377);
            this.Controls.Add(this.BT_SOCKET_COM);
            this.Controls.Add(this.BT_MANTEN_PADRON);
            this.Controls.Add(this.label1);
            this.Name = "FRM_MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_MANTEN_PADRON;
        private System.Windows.Forms.Button BT_SOCKET_COM;
    }
}