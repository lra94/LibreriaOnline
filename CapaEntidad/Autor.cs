using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Descripcion { get; set; }

        public Pais oPais { get; set; }
        public bool Activo { get; set; }
    }
}
