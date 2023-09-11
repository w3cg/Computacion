using CEN.CATEGORIA;
using CEN.HELPERS;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CEN.REQUEST;
using System.Data;

namespace CAD
{
    public class CadCategoria
    {
        public CenControlError ListarCategorias(CategoriaRequest request)
        {
            CenControlError response = new();
            SqlConnection _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            List<ListCategoriaCEN> list = new();
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ObtenerCategorias", _sqlConexion);
                cmd.Parameters.AddWithValue("@pCodigo", request.pCodigo);
                cmd.Parameters.AddWithValue("@pNombre", request.pNombre);
                cmd.Parameters.AddWithValue("@ppage", request.ppage);
                cmd.Parameters.AddWithValue("@pcount", request.pcount);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ListCategoriaCEN()
                        {
                            idCategoria = Int32.Parse(reader["ID"].ToString()),
                            codigo = reader["CODIGO"].ToString(),
                            nombre = reader["NOMBRE"].ToString()
                        });
                    }
                }
                bool tipoRespuesta = list.Count == 0;
                //"C" - Creacion, "R" - Lectura, "U" - Modificacion, "D" - Eliminacion
                response.Tipo = "R";
                response.Mensaje = tipoRespuesta ? "No se encontraron resultados" : "Operacion exitosa";
                response.Codigo = tipoRespuesta ? "EX" : "OK";
                response.Cuerpo = new Paginado
                {
                    Pagina = request.ppage,
                    Tamanio = request.pcount,
                    TotalResultados = this.ContarCategorias(request),
                    Data = list
                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _sqlConexion.Close();
            }

        }
            public CenControlError AgregarCategoria(InsertCategoriaCEN request)
            {
                CenControlError response = new();
                SqlConnection _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
                SqlCommand cmd;
                try
                {
                    _sqlConexion.Open();
                    cmd = new SqlCommand("sp_IUDCategoria", _sqlConexion);
                    cmd.Parameters.AddWithValue("@pId", null);
                    cmd.Parameters.AddWithValue("@pCodigo", request.codigo);
                    cmd.Parameters.AddWithValue("@pNombre", request.nombre);
                    cmd.Parameters.AddWithValue("@pAccion", "I");
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {   
                       while (reader.Read()) 
                       {
                        response.Tipo = "C";
                        response.Codigo = reader["CODIGO"].ToString();
                        response.Mensaje = reader["MENSAJE"].ToString();
                    }
                    }
                    //"C" - Creacion, "R" - Lectura, "U" - Modificacion, "D" - Eliminacion
                    return response;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    _sqlConexion.Close();
                }
            }
            private int ContarCategorias(CategoriaRequest request)
        {
            int total = 0;
            SqlConnection _sqlConexion = new SqlConnection(Constants.Cadena_conexion);
            SqlCommand cmd;
            try
            {
                _sqlConexion.Open();
                cmd = new SqlCommand("sp_ContarCategorias", _sqlConexion);
                cmd.Parameters.AddWithValue("@pCodigo", request.pCodigo == null ? null : request.pCodigo.Trim());
                cmd.Parameters.AddWithValue("@pNombre", request.pNombre == null ? null : request.pNombre.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = Int32.Parse(reader["TOTAL_REGISTROS"].ToString());
                    }
                }
                return total;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _sqlConexion.Close();
            }
        }
    }
}
