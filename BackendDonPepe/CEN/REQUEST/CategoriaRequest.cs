using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.REQUEST
{
    public class CategoriaRequest
    {
        public string? pCodigo { get; set; }
        public string? pNombre { get; set; }
        public int ppage { get; set; }
        public int pcount { get; set; }
    }
}
