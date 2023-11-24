using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string Descripcion { get; set; }

        public string CodigoIso { get; set; }
        public bool Activo { get; set; }
    }
}
