using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Dashboard
    {
        private CD_Dashboard objCapaDato = new CD_Dashboard();


        public Dashboard VerDashboard()
        {
            return objCapaDato.VerDashboard();
        }
    }
}
