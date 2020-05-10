using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string filename_propietario = @"C:\L3\Propietario.txt";
        public string filename_propiedades = @"C:\L3\Propiedades.txt";

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
            GuardarTxtPropietario();
            MostrarDatos();
        }

        void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propietarios;
            dataGridView1.Refresh();
        }


        void GuardarTxtPropietario()
        {
            if (!File.Exists(filename_propietario))
            {
                Directory.CreateDirectory(@"C:\L3");
                FileStream stream = new FileStream(filename_propietario, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propietarios)
                {
                    writer.WriteLine(p.Dpi);
                    writer.WriteLine(p.Nombre);
                    writer.WriteLine(p.Apellido);
                }
                writer.Close();
            }
            else
            {
                FileStream stream = new FileStream(filename_propietario, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propietarios)
                {
                    writer.WriteLine(p.Dpi);
                    writer.WriteLine(p.Nombre);
                    writer.WriteLine(p.Apellido);
                }
                writer.Close();
            }
            MessageBox.Show("Guardado con Exito!", "Confirmacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void GuardarTxtPropiedad()
        {
            if (!File.Exists(filename_propiedades))
            {
                Directory.CreateDirectory(@"C:\L3");
                FileStream stream = new FileStream(filename_propiedades, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propiedades)
                {
                    writer.WriteLine(p.No_casa);
                    writer.WriteLine(p.Dpi_duenio);
                    writer.WriteLine(p.Cuota_mantenimiento);
                }
                writer.Close();
            }
            else
            {
                FileStream stream = new FileStream(filename_propiedades, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propiedades)
                {
                    writer.WriteLine(p.No_casa);
                    writer.WriteLine(p.Dpi_duenio);
                    writer.WriteLine(p.Cuota_mantenimiento);
                }
                writer.Close();
            }
            MessageBox.Show("Guardado con Exito!", "Confirmacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

