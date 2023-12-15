using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Carrito
    {
        private CD_Carrito objCapaDato = new CD_Carrito();

        public bool ExisteCarrito(int clienteid, int productoid)
        {
            return objCapaDato.ExisteCarrito(clienteid, productoid);
        }

        public bool OperacionCarrito(int clienteid, int productoid, bool sumar, out string Mensaje)
        {
            return objCapaDato.OperacionCarrito(clienteid, productoid, sumar, out Mensaje);
        }

        public int CantidadEnCarrito(int clienteid) 
        {
            return objCapaDato.CantidadEnCarrito(clienteid);
        }
    }
}
