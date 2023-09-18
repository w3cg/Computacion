using CAD;
using CEN.CATEGORIA;
using CEN.HELPERS;
using CEN.REQUEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnCategoria
    {
        public CenControlError ListarCategoria(CategoriaRequest request)
        { 
            CadCategoria cad = new();
            return cad.ListarCategorias(request);
        }

        public CenControlError AgregarCategoria(InsertCategoriaCEN request)
        {
            CadCategoria cad = new();
            return cad.AgregarCategoria(request);
        }
        public CenControlError EditarCategoria(UpdateCategoriaCEN request)
        {
            CadCategoria cad = new();
            return cad.EditarCategoria(request);
        }
        public CenControlError EliminarCategoria(DeleteCategoriaCEN request)
        {
            CadCategoria cad = new();
            return cad.EliminarCategoria(request);
        }
    }
}
