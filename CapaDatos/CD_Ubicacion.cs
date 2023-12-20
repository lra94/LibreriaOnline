using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Ubicacion
    {
        public List<Provincia> ObtenerProvincia()
        {
            List<Provincia> lista = new List<Provincia>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from Provincia";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                    new Provincia()
                                    {
                                        IdProvincia = dr["IdProvincia"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Provincia>();
            }
            return lista;
        }

        public List<Municipio> ObtenerMunicipio(string provinciaid)
        {
            List<Municipio> lista = new List<Municipio>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from Municipio where provinciaid = @ProvinciaId";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@ProvinciaId", provinciaid);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                    new Municipio()
                                    {
                                        IdMunicipio = dr["IdMunicipio"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Municipio>();
            }
            return lista;
        }

        public List<Sector> ObtenerSector(string municipioid, string provinciaid)
        {
            List<Sector> lista = new List<Sector>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from Sector where municipioid = @MunicipioId and ProvinciaId = @ProvinciaId";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@MunicipioId", municipioid);
                    cmd.Parameters.AddWithValue("@ProvinciaId", provinciaid);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                    new Sector()
                                    {
                                        IdSector = dr["IdSector"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString()
                                    }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Sector>();
            }
            return lista;
        }
    }
}
