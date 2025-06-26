using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ComprasController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpPost]
        public IActionResult ComprarPasaje(string numVuelo, DateTime fechaVuelo, Equipaje equipaje)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente") throw new Exception("Sólo los clientes pueden comprar");
                string email = HttpContext.Session.GetString("email");
                Cliente cliente = miSistema.ObtenerClientePorEmail(email);
                miSistema.CrearPasaje(numVuelo, cliente.Documento, equipaje, fechaVuelo);
                TempData["Exito"] = $"Pasaje comprado correctamente para el vuelo {numVuelo}.";
                return RedirectToAction("Listado", "Pasajes");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Vuelo = miSistema.ObtenerVueloPorId(numVuelo);
                return RedirectToAction("DetalleVuelo", "Vuelos");
            }
        }
    }

}
