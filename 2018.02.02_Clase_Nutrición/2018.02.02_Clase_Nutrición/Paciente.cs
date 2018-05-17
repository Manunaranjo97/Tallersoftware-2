using _2018._02._02_Clase_Nutrición.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018._02._02_Clase_Nutrición
{
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<TipoDocumento>
                tiposDocumentos = new List<TipoDocumento>();

            tiposDocumentos.Add(new TipoDocumento()
            { Id = 1,Nombre = "Cedula de Ciudadania" });
            tiposDocumentos.Add(new TipoDocumento()
            { Id = 2, Nombre = "Tarjeta de Identidad" });
        }

        private void btnGuardar_Click(object sender, EventArgs e)

        {

         
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, " El nombre es Obligatorio");
              
            }
            else
            {
                erpMensaje.SetError(txtNombre, "");
            }
            // TODO: VALIDAR Numero de Documento

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La Fecha de nacimiento debe ser menor a la fecha actual");
                return;
            }
            
             
            Entidades.Paciente paciente = new Entidades.Paciente();
            paciente.PrimerNombre = txtNombre.Text;
            paciente.NumeroDocumento = Convert.ToInt64(txtNumeroDocumento.Text);
            paciente.FechaNacimiento = dtpFechaNacimiento.Value;
            paciente.TipoDocumento = cboTipoDocumento.SelectedItem as TipoDocumento;


            // forma elegante de convertirlo


            Control.ControlPaciente controlPaciente = new Control.ControlPaciente();
            controlPaciente.IngresarPaciente(paciente);

            MessageBox.Show("Paciente ingresado exitosamente");


        }

        private void Paciente_load(object sender, EventArgs e)
        {
            List<TipoDocumento>

        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 || (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }

        private void dtpFechaNacimiento_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                erpMensaje.SetError(dtpFechaNacimiento, "La Fecha de nacimiento debe ser menor a la fecha actual");

            }
            else
            {
                erpMensaje.SetError(dtpFechaNacimiento, string.Empty);

            }

            }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

