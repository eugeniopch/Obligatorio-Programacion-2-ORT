using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass) 
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede estar vacío");
                if (string.IsNullOrEmpty(pass)) throw new Exception("La contraseña no puede estar vacía");
                Usuario usuario = miSistema.Login(email, pass);
                if (usuario == null) throw new Exception("Email o contraseña inválidos");

                HttpContext.Session.SetString("email", usuario.Email);
                HttpContext.Session.SetString("rol", usuario.Rol());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string email, string pass, string documento, string nombre, string nacionalidad)
        {
            if (HttpContext.Session.GetString("rol") == "Cliente" || HttpContext.Session.GetString("rol") == "Admin") return View("NoAutorizado");
            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede ser vacío");
                if (string.IsNullOrEmpty(pass)) throw new Exception("El password no puede ser vacío");
                if (string.IsNullOrEmpty(documento)) throw new Exception("El documento no puede ser vacío");
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser vacío");
                if (string.IsNullOrEmpty(nacionalidad)) throw new Exception("La nacionalidad no puede estar vacía");

                ClienteOcasional cliente = new ClienteOcasional(email, pass, documento, nombre, nacionalidad);
                miSistema.CrearUsuario(cliente);

                HttpContext.Session.SetString("email", cliente.Email);
                HttpContext.Session.SetString("rol", cliente.Rol());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Registro");
        }

    }
}
