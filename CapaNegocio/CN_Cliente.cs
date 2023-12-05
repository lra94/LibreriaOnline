using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objCapaDato = new CD_Cliente();

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El Apellido no puede estar vacio!";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo no puede estar vacio!";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Clave = CN_Recursos.ConvertirShat256(obj.Clave);
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public List<Cliente> Listar()
        {
            return objCapaDato.Listar();
        }

        //Cambiar Clave de Cliente
        public bool CambiarClave(int idcliente, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.CambiarClave(idcliente, nuevaclave, out Mensaje);
        }

        //Reestablecer Clave de Cliente
        public bool ReestablecerClave(int idcliente, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave = CN_Recursos.GenerarClaveAleatoria();
            bool resultado = objCapaDato.ReestablecerClave(idcliente, CN_Recursos.ConvertirShat256(nuevaclave), out Mensaje);

            if (resultado)
            {
                string asunto = "Libreria Online - Reestablecer clave";
                string mensaje_correo = $"<h3>Su cuenta fue reestablecida correctamente</h3></br><p>Su nueva clave temporal es: {nuevaclave}</p>";
                bool respuesta = CN_Recursos.EnviarCorreo(correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    return true;
                }
                else
                {
                    Mensaje = "No se pudo enviar el correo.";
                    return false;
                }
            }
            else
            {
                Mensaje = "No se pudo reestablecer la clave.";
                return false;
            }

        }
    }
}
