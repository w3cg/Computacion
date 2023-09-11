using CEN.CATEGORIA;
using CEN.HELPERS;
using CEN.REQUEST;
using CLN;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost("listarCategoria")]
        public IActionResult ListCategorias([FromBody] CategoriaRequest Crequest) 
        {
            try
            {
                ClnCategoria cln = new();
                var request = cln.ListarCategoria(Crequest);
                return Ok(request);
            }
            catch (Exception ex)
            {
                CenControlError error = new()
                {
                    Tipo = "R",
                    Codigo = "EX",
                    Mensaje = ex.Message
                };
                return BadRequest(error);
            }
        }

        [HttpPost("agregarCategoria")]
        public IActionResult AgregarCategorias([FromBody] InsertCategoriaCEN Crequest)
        {
            try
            {
                ClnCategoria cln = new();
                var request = cln.AgregarCategoria(Crequest);
                return Ok(request);
            }
            catch (Exception ex)
            {
                CenControlError error = new()
                {
                    Tipo = "R",
                    Codigo = "EX",
                    Mensaje = ex.Message
                };
                return BadRequest(error);
            }
        }
    }
}
