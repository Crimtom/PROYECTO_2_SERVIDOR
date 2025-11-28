using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_2_SERVIDOR.Presentacion
{
    public partial class FRM_MAIN : Form
    {
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void BT_SOCKET_COM_Click(object sender, EventArgs e)
        {
            try
            {
                Principal socket = new Principal();
                socket.Show();
                // Verifica si el formulario socket está abierto para poder cerrar el menú principal
                if (Application.OpenForms.OfType<Principal>().Any())
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error tras intentar abrir el menú de Socket de Comunicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
