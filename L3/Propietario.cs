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

        public string Dpi { get => dpi; set => dpi = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Propietario()
        {
            dpi = Dpi;
            nombre = Nombre;
            apellido = Apellido;
        }
    }
}
