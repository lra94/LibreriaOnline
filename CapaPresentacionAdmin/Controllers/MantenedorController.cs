using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}