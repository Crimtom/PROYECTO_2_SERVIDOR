namespace PROYECTO_2_SERVIDOR.Presentacion
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">
        /// true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.gbSocket = new System.Windows.Forms.GroupBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtBitacora = new System.Windows.Forms.TextBox();
            this.lblClientes = new System.Windows.Forms.Label();
            this.gbSocket.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSocket
            // 
            this.gbSocket.Controls.Add(this.btnDetener);
            this.gbSocket.Controls.Add(this.btnIniciar);
            this.gbSocket.Controls.Add(this.txtBitacora);
            this.gbSocket.Controls.Add(this.lblClientes);
            this.gbSocket.Location = new System.Drawing.Point(12, 12);
            this.gbSocket.Name = "gbSocket";
            this.gbSocket.Size = new System.Drawing.Size(560, 337);
            this.gbSocket.TabIndex = 0;
            this.gbSocket.TabStop = false;
            this.gbSocket.Text = "Socket de comunicación";
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(460, 22);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(90, 27);
            this.btnDetener.TabIndex = 3;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(364, 22);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 27);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtBitacora
            // 
            this.txtBitacora.Location = new System.Drawing.Point(16, 64);
            this.txtBitacora.Multiline = true;
            this.txtBitacora.Name = "txtBitacora";
            this.txtBitacora.ReadOnly = true;
            this.txtBitacora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBitacora.Size = new System.Drawing.Size(534, 257);
            this.txtBitacora.TabIndex = 1;
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new System.Drawing.Point(13, 29);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(125, 13);
            this.lblClientes.TabIndex = 0;
            this.lblClientes.Text = "Clientes conectados: 0";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.gbSocket);
            this.Name = "Principal";
            this.Text = "SERVIDOR PADRÓN - PRINCIPAL";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.gbSocket.ResumeLayout(false);
            this.gbSocket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSocket;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtBitacora;
        private System.Windows.Forms.Label lblClientes;
    }
}

