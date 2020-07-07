using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImssAnalysis.Model
{
    public class CsvFD
    {
        public int IdSolicitud { get; set; }
        public string RegistroPatronal { get; set; }
        public string NombreCompania { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaEgreso { get; set; }
		public string UsuarioRegistro { get; set; }
    }
}
