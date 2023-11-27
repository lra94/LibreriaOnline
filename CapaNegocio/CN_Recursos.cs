using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        //Encriptacion de texto a SHA256
        public static string ConvertirShat256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            //Usando la referencia de System.Security.Cryptography
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        //Generar Clave aleatoria
        public static string GenerarClaveAleatoria()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudCclave = 15;
            string claveAleatoria = string.Empty;
            for (int i = 0; i < longitudCclave; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                claveAleatoria += letra.ToString();
            }
            return claveAleatoria;

        }

        //Enviar clave por correo
        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("pruebacodigo15@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("pruebacodigo15@gmail.com", "naqu nxnq cwpi itda ")
                };

                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }

    }
}
