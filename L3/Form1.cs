using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3
{
    public partial class Form1 : Form
    {
        List<Propietario> propietarios;
        List<Propiedad> propiedades;
        Propietario propietario;
        Propiedad propiedad;

        public Form1()
        {
            InitializeComponent();
            propietarios = new List<Propietario>();
            propiedades = new List<Propiedad>();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            propietario = new Propietario();
            propietario.Dpi = textBox1.Text;
            propietario.Nombre = textBox2.Text;
            propietario.Apellido = textBox3.Text;
            propietarios.Add(propietario);
            MostrarDatos();
        }

        void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propietarios;
            dataGridView1.Refresh();
        }
    }
}
