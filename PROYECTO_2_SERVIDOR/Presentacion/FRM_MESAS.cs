using PROYECTO_2_SERVIDOR.Logica;
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
        Cla_Padron Padron = new Cla_Padron();

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            //  Limpia los espacios de texto
            try
            {
                if (TXT_CEDULA.Text != "" || TXT_NOMBRE.Text != "" || TXT_NUM_MESA.Text != "" || TXT_CENT_VOTA.Text != "")
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

        private void TXT_CEDULA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Valida que solo se ingresen números en el campo Cédula
                bool cedula_texto;
                if (!string.IsNullOrEmpty(TXT_CEDULA.Text))
                {
                    cedula_texto = TXT_CEDULA.Text.All(char.IsDigit);
                    if (!cedula_texto)
                    {
                        MessageBox.Show("Por favor, ingrese solo números en el campo Cédula.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TXT_CEDULA.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al intentar procesar el cambio en el campo Cédula: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TXT_NOMBRE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool nombre_texto;
                if (!string.IsNullOrEmpty(TXT_NOMBRE.Text))
                {
                    nombre_texto = TXT_NOMBRE.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
                    if (!nombre_texto)
                    {
                        MessageBox.Show("Por favor, ingrese solo letras y espacios en el campo Nombre.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TXT_NOMBRE.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al intentar procesar el cambio en el campo Nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_MESAS_Load(object sender, EventArgs e)
        {
            CB_ESTADO.Items.Add("Activo");
            
            CB_ESTADO.SelectedIndex = 0;
        }

        private void BT_GRABAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXT_CEDULA.Text == "" || TXT_NOMBRE.Text == "" ||
                    TXT_NUM_MESA.Text == "" || TXT_CENT_VOTA.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool fallecido = (CB_ESTADO.SelectedItem.ToString() == "Inactivo");


                bool resultado = Padron.Grabar(
                    TXT_CEDULA.Text.Trim(),
                    TXT_NOMBRE.Text.Trim(),
                    TXT_NUM_MESA.Text.Trim(),
                    TXT_CENT_VOTA.Text.Trim(),
                    false
                );

                if (resultado)
                {
                    MessageBox.Show("Datos almacenados correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo almacenar la información.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar grabar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXT_CEDULA.Text == "")
                {
                    MessageBox.Show("Debe ingresar la cédula que desea eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool eliminado = Padron.Eliminar(TXT_CEDULA.Text.Trim());

                if (eliminado)
                {
                    MessageBox.Show("La persona ha sido marcada como fallecida.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La cédula ingresada no existe en el padrón.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CB_ESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
