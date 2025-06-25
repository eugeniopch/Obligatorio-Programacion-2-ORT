using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VuelosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Listado(string? codigo)
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAutorizado");

            if (string.IsNullOrEmpty(codigo))
            {
                ViewBag.Listado = miSistema.Vuelos;
            }
            else
            {
                ViewBag.Listado = miSistema.ObtenerVuelosPorCodigoAeropuerto(codigo);
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult DetalleVuelo(string codigo)
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAutorizado");

            Vuelo v = miSistema.ObtenerVueloPorId(codigo);
            ViewBag.Vuelo = v;
            return View(); 
        }
    }
}
