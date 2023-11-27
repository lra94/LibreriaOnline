using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();


        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        ////Clave aleatoria
        //public static string GenerarClaveAleatoria()
        //{
        //    Random rdn = new Random();
        //    string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
        //    int longitud = caracteres.Length;
        //    char letra;
        //    int longitudCclave = 15;
        //    string claveAleatoria = string.Empty;
        //    for (int i = 0; i < longitudCclave; i++)
        //    {
        //        letra = caracteres[rdn.Next(longitud)];
        //        claveAleatoria += letra.ToString();
        //    }
        //    return claveAleatoria;

        //}

        //Registrar Usuario
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El Apellido del usuario no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del usuario no puede estar vacio!";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = CN_Recursos.GenerarClaveAleatoria(); //GenerarClaveAleatoria();
                string asunto = "Libreria Online - Registro de cuenta";
                string mensaje_correo = $"<h3>Su cuenta fue creada correctamente</h3></br><p>Su clave temporal es:{clave}</p>";

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = CN_Recursos.ConvertirShat256(clave);
                    return objCapaDato.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "No se puede enviar el coreo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        //Editar usuario
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El Apellido del usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del usuario no puede estar vacio";
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

        //Eliminar usuario
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }



    }
}
