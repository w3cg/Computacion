using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.HELPERS
{
    public class Paginado
    {
        public int Pagina { get; set; }
        public int Tamanio { get; set; }
        public int TotalResultados { get; set; }
        public object Data { get; set; }
    }
}
