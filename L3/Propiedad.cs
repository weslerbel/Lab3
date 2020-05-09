using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Propiedad
    {
        private int no_casa;
        private int dpi_duenio;
        private double cuota_mantenimiento;

        public int No_casa { get => no_casa; set => no_casa = value; }
        public int Dpi_duenio { get => dpi_duenio; set => dpi_duenio = value; }
        public double Cuota_mantenimiento { get => cuota_mantenimiento; set => cuota_mantenimiento = value; }

        public Propiedad()
        {
            no_casa = No_casa;
            dpi_duenio = Dpi_duenio;
            cuota_mantenimiento = Cuota_mantenimiento;
        }
    }
}
