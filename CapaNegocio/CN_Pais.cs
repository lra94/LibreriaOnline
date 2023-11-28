using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Pais
    {
        private CD_Pais objCapaDato = new CD_Pais();

        public List<Pais> Listar()
        {
            return objCapaDato.Listar();
        }

        //Metodo Registrar Pais
        public int Registrar(Pais obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del Pais no puede estar vacio!";
            }
            if (string.IsNullOrEmpty(obj.CodigoIso) || string.IsNullOrWhiteSpace(obj.CodigoIso))
            {
                Mensaje = "El Codigo Iso del Pais no puede estar vacio!";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        //Editar Pais
        public bool Editar(Pais obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del Pais no puede estar vacio!";
            }
            if (string.IsNullOrEmpty(obj.CodigoIso) || string.IsNullOrWhiteSpace(obj.CodigoIso))
            {
                Mensaje = "El Codigo Iso del Pais no puede estar vacio!";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        //Eliminar Pais
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
