using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace CapaDatos
{
    public class CD_Carrito
    {

        public bool ExisteCarrito(int clienteid, int productoid)
        {
            bool resultado = true;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ExisteCarrito", oconexion);
                    cmd.Parameters.AddWithValue("ClienteId", clienteid);
                    cmd.Parameters.AddWithValue("ProductoId", productoid);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool OperacionCarrito(int clienteid, int productoid, bool sumar, out string Mensaje)
        {
            bool resultado = true;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_OperacionCarrito", oconexion);
                    cmd.Parameters.AddWithValue("ClienteID", clienteid);
                    cmd.Parameters.AddWithValue("ProductoId", productoid);
                    cmd.Parameters.AddWithValue("Sumar", sumar);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public int CantidadEnCarrito (int clienteid)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("select COUNT(*) from Carrito  where ClienteId = @clienteid", oconexion);
                    cmd.Parameters.AddWithValue("@clienteid", clienteid);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
            }
            return resultado;
        }

        public List<Carrito> ListarProducto(int idcliente)
        {
            List<Carrito> lista = new List<Carrito>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from fn_obtenerCarritoCliente(@idcliente)";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idcliente", idcliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                    new Carrito()
                                    {
                                        oProducto = new Producto()
                                        {
                                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                            Titulo = dr["Titulo"].ToString(),
                                            oAutor = new Autor() { Descripcion = dr["DesAutor"].ToString() },                                       
                                            Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-DO")),
                                            RutaImagen = dr["RutaImagen"].ToString(),
                                            NombreImagen = dr["NombreImagen"].ToString()
                                        },
                                        Cantidad = Convert.ToInt32(dr["Cantidad"])

                                    }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Carrito>();

            }
            return lista;
        }

        public bool EliminarCarrito(int clienteid, int productoid)
        {
            bool resultado = true;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("spEliminarCarrito", oconexion);
                    cmd.Parameters.AddWithValue("ClienteId", clienteid);
                    cmd.Parameters.AddWithValue("ProductoId", productoid);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }


    }
}
