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
    }
}
