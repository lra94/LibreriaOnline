using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Ubicacion
    {
        private CD_Ubicacion objCapaDato = new CD_Ubicacion();

        public List<Provincia> ObtenerProvincia() 
        {
            return objCapaDato.ObtenerProvincia();
        }

        public List<Municipio> ObtenerMunicipio(string provinciaid)
        {
            return objCapaDato.ObtenerMunicipio(provinciaid);
        }

        public List<Sector> ObtenerSector(string municipioid, string provinciaid)
        {
            return objCapaDato.ObtenerSector(municipioid, provinciaid);
        }
    }
}
