using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {



		//[Telefono] [varchar] (15) NULL,
		//[IdTransaccion] [varchar] (50) NULL,



		public int IdVenta { get; set; }
		public int ClienteId { get; set; }
		public int TotalProducto { get; set; }
		public decimal MontoTotal { get; set; }
		public string Contacto { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string SectorId { get; set; }
		public string FechaTexto { get; set; }
		public string IdTransaccion { get; set; }


		public List<DetalleVenta> oDetalleVenta { get; set; }

	}
}
