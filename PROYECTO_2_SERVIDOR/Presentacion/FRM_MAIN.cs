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
                // Verifica si el formulario socket no está abierto para poder abrirlo
                if (Application.OpenForms.OfType<FRM_MESAS>().Any())
                {
                    MessageBox.Show("El menú de Socket de Comunicación no puede abrirse mientras el menú de Mantenimiento de Mesas de Votación está abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!Application.OpenForms.OfType<Principal>().Any())
                {
                    socket.Show();
                }
                else
                {
                    MessageBox.Show("El menú de Socket de Comunicación ya se encuentra abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Application.OpenForms.OfType<Principal>().Any())
                {
                    MessageBox.Show("El menú de Mantenimiento de Mesas de Votación no puede abrirse mientras el menú de Socket de Comunicación está abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!Application.OpenForms.OfType<FRM_MESAS>().Any())
                {
                    mesas.Show();
                }
                else
                {
                    MessageBox.Show("El menú de Mantenimiento de Mesas de Votación ya se encuentra abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error tras intentar abrir el menú de Mantenimiento de Mesas de Votación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }
    }
}
