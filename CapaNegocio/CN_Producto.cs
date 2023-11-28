using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        //Metodo Registrar Producto
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del libro no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del libro no puede estar vacio!";
            }
            else if(obj.oAutor.IdAutor == 0)
            {
                Mensaje = "Debe seleccionar un Autor!";
            }
            else if(obj.oGenero.IdGenero == 0)
            {
                Mensaje = "Debe seleccionar un Genero!";
            }
            else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del libro!";
            }
            else if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el stock del libro!";
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

        //Editar Producto
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del libro no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del libro no puede estar vacio!";
            }
            else if (obj.oAutor.IdAutor == 0)
            {
                Mensaje = "Debe seleccionar un Autor!";
            }
            else if (obj.oGenero.IdGenero == 0)
            {
                Mensaje = "Debe seleccionar un Genero!";
            }
            else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del libro!";
            }
            else if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el stock del libro!";
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

        //Guardar datos de Imagen
        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objCapaDato.GuararDatosImagen(obj, out Mensaje);

        }

        //Eliminar Producto
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
