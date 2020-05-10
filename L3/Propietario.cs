using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Propietario
    {
        private string dpi;
        private string nombre;
        private string apellido;
        private int cnt_propiedades;

        public string Dpi { get => dpi; set => dpi = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cnt_propiedades { get => cnt_propiedades; set => cnt_propiedades = value; }

        public Propietario()
        {
            dpi = Dpi;
            nombre = Nombre;
            apellido = Apellido;
            cnt_propiedades = Cnt_propiedades;
        }
    }
}
