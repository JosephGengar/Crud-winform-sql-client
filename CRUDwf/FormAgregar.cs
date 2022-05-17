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
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Personas oPersonas = new Personas();
            try
            {
                oPersonas.Agregar(txtNombre.Text, txtApellido.Text);
                MessageBox.Show("Persona Agregada con exito!");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un Error!!" + ex.Message);;
            }
        }
    }
}
