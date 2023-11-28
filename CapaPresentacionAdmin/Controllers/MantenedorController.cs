using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Genero()
        {
            return View();
        }
        public ActionResult Pais()
        {
            return View();
        }
        public ActionResult Autor()
        {
            return View();
        }
        public ActionResult Producto()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarGeneros()
        {
            List<Genero> oLista = new List<Genero>();

            oLista = new CN_Genero().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarGenero(Genero objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdGenero == 0)
            {
                resultado = new CN_Genero().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Genero().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarGenero(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Genero().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}