using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

        private void BT_MANTEN_PADRON_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_MESAS mesas = new FRM_MESAS();
                mesas.Show();
                if (Application.OpenForms.OfType<FRM_MESAS>().Any())
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error tras intentar abrir el menú de Mantenimiento de Mesas de Votación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
