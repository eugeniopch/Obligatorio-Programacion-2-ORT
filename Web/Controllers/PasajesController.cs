using Dominio;
using Dominio.Comparadores;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PasajesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAutorizado");

            string rol = HttpContext.Session.GetString("rol");

            List<Pasaje> pasajes;

            if (rol == "Admin")
            {
                pasajes = miSistema.Pasajes;
                pasajes.Sort(new ComparadorPorFecha());
            }
            else
            {
                string email = HttpContext.Session.GetString("email");
                pasajes = miSistema.ObtenerPasajesDeCliente(email);
                pasajes.Sort();
            }

            ViewBag.Listado = pasajes;
            ViewBag.Rol = rol;
            return View();
        }
    }

}
