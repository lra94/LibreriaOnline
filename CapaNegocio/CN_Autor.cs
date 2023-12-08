using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Autor
    {
        private CD_Autor objCapaDato = new CD_Autor();

        public List<Autor> Listar()
        {
            return objCapaDato.Listar();
        }

        //Metodo Registrar Autor
        public int Registrar(Autor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "El Nombre del Autor no puede estar vacio!";
            }            
            else if (obj.oPais.IdPais == 0)
            {
                Mensaje = "Debe seleccionar un Pais!";
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

        //Editar Autor
        public bool Editar(Autor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "El Nombre del Autor no puede estar vacio!";
            }
            else if (obj.oPais.IdPais == 0)
            {
                Mensaje = "Debe seleccionar un Pais!";
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

        //Eliminar Autor
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

        public List<Autor> ListarAutorPorGenero(int idgenero)
        {
            return objCapaDato.ListarAutorPorGenero(idgenero);
        }
    }
}
