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
    public partial class Form1 : Form
    {
        public Form1()
        {
            //al form cambiarle la propiedad selection mode =a full row selected
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            Personas oPersonas = new Personas();
            if (oPersonas.Ok())
            {
                Actualizar();
                MessageBox.Show("Conexion Correcta");
            }
            else
            {
                MessageBox.Show("Problemas en la conexion!!!");
            }
        }

        private void Actualizar()
        {
            Personas oPersonas = new Personas();
            dataGridView1.DataSource = oPersonas.Obtener();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar frm = new FormAgregar();
            frm.ShowDialog(); // showdialog igual q angular, se tiene q cerrar este para seguir con el otro
            Actualizar();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch (Exception)
            {

                return null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                //utilizando la sobrecarga de constructor q hicimos
                FormAgregar frmEditar = new FormAgregar(id);
                frmEditar.ShowDialog();
                Actualizar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            try
            {
                if (id != null)
                {
                    Personas oPersonas = new Personas();
                    oPersonas.Borrar((int)id);
                    Actualizar();
                    MessageBox.Show("Persona Eliminada");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("ocurrio un error al eliminar" + ex.Message);;
            }
           
        }
    }
}
