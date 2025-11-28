using System;
using System.Windows.Forms;
using PROYECTO_2_SERVIDOR.Logica;

namespace PROYECTO_2_SERVIDOR.Presentacion
{
    public partial class Principal : Form
    {
        private Cla_Servidor _servidor = new Cla_Servidor();

        public Principal()
        {
            InitializeComponent();

            // Conectar eventos del servidor con el formulario
            _servidor.OnLog += Servidor_OnLog;
            _servidor.OnCambioClientes += Servidor_OnCambioClientes;
        }

        // Evento que el diseñador espera (está hookeado en el Designer)
        private void Principal_Load(object sender, EventArgs e)
        {
            // Por ahora no hace nada
        }

        // Muestra la bitácora en el TextBox
        private void Servidor_OnLog(string mensaje)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Servidor_OnLog), mensaje);
                return;
            }

            txtBitacora.AppendText(mensaje + Environment.NewLine);
        }

        // Muestra los clientes conectados
        private void Servidor_OnCambioClientes(int cantidad)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(Servidor_OnCambioClientes), cantidad);
                return;
            }

            lblClientes.Text = "Clientes conectados: " + cantidad;
        }

        // Botón INICIAR SERVIDOR
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            _servidor.Iniciar(30000);
        }

        // Botón DETENER SERVIDOR
        private void btnDetener_Click(object sender, EventArgs e)
        {
            _servidor.Detener();
        }
    }
}


