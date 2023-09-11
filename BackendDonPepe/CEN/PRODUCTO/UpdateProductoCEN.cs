using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.PRODUCTO
{
    public class UpdateProductoCEN
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int usuarioActualiza { get; set; }
    }
}
