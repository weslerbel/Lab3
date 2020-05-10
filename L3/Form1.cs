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
            MostrarDatos("propietario");
        }

        void MostrarDatos(string clase)
        {
            dataGridView1.DataSource = null;
            if (clase=="propietario")
            {
                LeerTxtPropietarios();
                dataGridView1.DataSource = propietarios;
            }
            if (clase == "propiedades")
            {
                LeerTxtPropiedad();
                dataGridView1.DataSource = propiedades;
            }
            dataGridView1.Refresh();
        }

        #region Metodos de Propietario

        void LeerTxtPropietarios()
        {
            try
            {
                if (!File.Exists(filename_propietario))
                {
                    MessageBox.Show("Aun no existen registros!, Agregue paginas para crearlo!", "Advertencia");
                }
                else
                {
                    propietarios = new List<Propietario>();
                    propietario = new Propietario();
                    string[] registro = new string[3];
                    string prueba = "";
                    FileStream stream = new FileStream(filename_propietario, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(stream);
                    prueba = reader.ReadLine();

                    while (prueba != null)
                    {
                        registro = prueba.Split(';');
                        propietario.Dpi = registro[0];
                        propietario.Nombre = registro[1];
                        propietario.Apellido = registro[2];
                        propietarios.Add(propietario);
                        prueba = reader.ReadLine();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
                    writer.WriteLine(p.Dpi + ";" + p.Nombre + ";" + p.Apellido);
                }
                writer.Close();
            }
            else
            {
                FileStream stream = new FileStream(filename_propietario, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propietarios)
                {
                    writer.WriteLine(p.Dpi + "," + p.Nombre + "," + p.Apellido);
                }
                writer.Close();
            }
            MessageBox.Show("Guardado con Exito!", "Confirmacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Metodos de Propiedad
        void LeerTxtPropiedad()
        {
            try
            {
                if (!File.Exists(filename_propiedades))
                {
                    MessageBox.Show("Aun no existen Registros!, Agregue paginas para crearlo!", "Advertencia");
                }
                else
                {
                    propiedades = new List<Propiedad>();
                    propiedad = new Propiedad();
                    string[] registro = new string[3];
                    string datos = "";
                    FileStream stream = new FileStream(filename_propiedades, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(stream);
                    datos = reader.ReadLine();
                    while (datos != null)
                    {
                        registro = datos.Split(';');
                        propiedad.No_casa = Convert.ToInt32(registro[0]);
                        propiedad.Dpi_duenio = registro[1];
                        propiedad.Cuota_mantenimiento = Convert.ToDouble(registro[2]);
                        propiedades.Add(propiedad);
                        datos = reader.ReadLine();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
                    writer.WriteLine(p.No_casa + ";" + p.Dpi_duenio + ";" + p.Cuota_mantenimiento);
                }
                writer.Close();
            }
            else
            {
                FileStream stream = new FileStream(filename_propiedades, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                foreach (var p in propiedades)
                {
                    writer.WriteLine(p.No_casa + ";" + p.Dpi_duenio + ";" + p.Cuota_mantenimiento);
                }
                writer.Close();
            }
            MessageBox.Show("Guardado con Exito!", "Confirmacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


        private void Button3_Click(object sender, EventArgs e)
        {
            propiedad = new Propiedad();
            propiedad.No_casa = Convert.ToInt32(txtNoCasa.Text);
            propiedad.Cuota_mantenimiento = Convert.ToDouble(txtCuota.Text);
            propiedad.Dpi_duenio = cmbxDPI.SelectedItem.ToString();
            propiedades.Add(propiedad);
            GuardarTxtPropiedad();
            MostrarDatos("propiedades");
        }



        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cargarCMBXDPI();
        }
        void cargarCMBXDPI()
        {
            LeerTxtPropietarios();
            foreach (var item in propietarios)
            {
                cmbxDPI.Items.Add(item.Dpi);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MostrarDatos("propietario");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos("propiedades");
            cargarCMBXDPI();
            LeerTxtPropietarios();
        }

       
    }
}

