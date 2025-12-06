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
    public partial class FRM_MESAS : Form
    {
        public FRM_MESAS()
        {
            InitializeComponent();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            //  Limpia los espacios de texto
            try
            {
                if (TXT_CEDULA.Text != "" && TXT_NOMBRE.Text != "" && TXT_NUM_MESA.Text != "" && TXT_CENT_VOTA.Text != "")
                {
                    TXT_CEDULA.Text = "";
                    TXT_NOMBRE.Text = "";
                    TXT_NUM_MESA.Text = "";
                    TXT_CENT_VOTA.Text = "";
                    MessageBox.Show("Los campos han sido limpiados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Todos los campos ya se encuentran vacíos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al intentar limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
