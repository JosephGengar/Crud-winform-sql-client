using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDwf
{
    public partial class FormAgregar : Form
    {
        private int? id;
        public FormAgregar(int? Id = null)
        {
            this.id = Id;
            InitializeComponent();
            if (this.id != null)
            {
                CargarDatos();
                this.Text = "Editar";
            }
        }
        private void CargarDatos()
        {
            //devuelve los datos del modelo seguir el id al dialog
            Personas oPersonas = new Personas();
            PersonasModel oPerM = oPersonas.Obtener((int)id);
            txtNombre.Text = oPerM.Nombre;
            txtApellido.Text = oPerM.Apellido;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Personas oPersonas = new Personas();
            try
            {
                if (id == null)
                {
                    oPersonas.Agregar(txtNombre.Text, txtApellido.Text);
                    MessageBox.Show("Persona Agregada con exito!");
                }
                else
                {
                    oPersonas.Editar(txtNombre.Text, txtApellido.Text, (int)id);
                    MessageBox.Show("Persona Modificada con exito!!");
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Error!!" + ex.Message);;
            }
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
