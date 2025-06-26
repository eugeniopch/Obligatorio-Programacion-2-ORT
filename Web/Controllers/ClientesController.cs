using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ClientesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") != "Admin") return View("NoAutorizado");

            List<Cliente> clientes = miSistema.ObtenerClientesOrdenadosPorDocumento();
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public IActionResult ModificarPuntos(string documento, int puntos)
        {
            try
            {
                ClientePremium cliente = miSistema.ObtenerClientePorDoc(documento) as ClientePremium;
                if (cliente == null) throw new Exception("Cliente no encontrado o no es premium.");
                cliente.ModificarPuntos(puntos);
                TempData["Exito"] = "Puntos actualizados.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Listado");
        }

        [HttpPost]
        public IActionResult CambiarElegibilidad(string documento)
        {
            try
            {
                ClienteOcasional cliente = miSistema.ObtenerClientePorDoc(documento) as ClienteOcasional;
                if (cliente == null) throw new Exception("Cliente no encontrado o no es ocasional.");
                cliente.CambiarEstadoElegible();
                TempData["Exito"] = "Elegibilidad modificada.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Listado");
        }
    }
}
