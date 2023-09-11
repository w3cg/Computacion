using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.USUARIO
{
    public class ListUsuarioCEN
    {
        public int idUsuario { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string fechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string correoElectronico { get; set; }
    }
}
