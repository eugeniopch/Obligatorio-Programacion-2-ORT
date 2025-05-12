using System.Text.RegularExpressions;
using Dominio;

namespace Consola
{
    internal class Program
    {
        static Sistema miSistema;

        static void Main(string[] args)
        {
            miSistema = new Sistema();

            string opcion = "";
            while (opcion != "0")
            {
                MostrarMenu();
                Console.Write("Ingrese una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListadoDeClientes();
                        PresioneParaContinuar();
                        break;
                    case "2":
                        VuelosCodigoAeropuerto();
                        PresioneParaContinuar();
                        break;
                    case "3":
                        AltaClienteOcasional();
                        PresioneParaContinuar();
                        break;
                    case "4":
                        ListarPublicacionesEntreFechas();
                        PresioneParaContinuar();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        MensajeError("Opción inválida");
                        PresioneParaContinuar();
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****** MENU ******");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1 - Listado de clientes");
            Console.WriteLine("2 - Obtener vuelos a partir de código de aeropuerto");
            Console.WriteLine("3 - Alta de cliente ocasional");
            Console.WriteLine("4 - Listado de pasajes entre dos fechas");
            Console.WriteLine("0 - Salir");
        }

        static void PresioneParaContinuar()
        {
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static string ObtenerPalabras(string mensaje)
        {
            Console.Write(mensaje);
            string dato = Console.ReadLine();
            return dato;
        }

        static DateTime PedirFecha(string mensaje)
        {
            bool exito = false;
            DateTime fecha = new DateTime();
            while (!exito)
            {
                Console.Write(mensaje + " [DD/MM/YYYY]:");
                exito = DateTime.TryParse(Console.ReadLine(), out fecha);

                if (!exito) MensajeError("ERROR: Debe ingresar una fecha en formato DD/MM/YYYY");
            }
            return fecha;
        }

        public static void ListadoDeClientes()
        {
            Console.Clear();
            Console.WriteLine("**** LISTADO DE CLIENTES ****");
            Console.WriteLine();

            try
            {
                List<Usuario> listadoUsuarios = miSistema.Usuarios;
                if (listadoUsuarios.Count == 0) throw new Exception("No hay clientes registrados en el sistema");

                foreach (Usuario u in listadoUsuarios)
                {
                    if (u is Cliente)
                    {
                        Console.WriteLine(u);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        public static void VuelosCodigoAeropuerto()
        {
            Console.Clear();
            string codAeropuerto = ObtenerPalabras("Ingrese el código del aeropuerto: ");

            List<Vuelo> vuelos = miSistema.ObtenerVuelosPorCodigoAeropuerto(codAeropuerto);
            if (vuelos.Count == 0)
            {
                Console.WriteLine("No se encontraron vuelos para ese aeropuerto.");
            }
            else
            {
                foreach (Vuelo v in vuelos)
                {
                    Console.WriteLine(v);
                }
            }
        }

        public static void AltaClienteOcasional() 
        {
            string email = ObtenerPalabras("Ingrese el email del cliente: ");
            string password = ObtenerPalabras("Ingrese el password del cliente: ");
            string documento = ObtenerPalabras("Ingrese el documento del cliente: ");
            string nombreCompleto = ObtenerPalabras("Ingrese el nombre completo del cliente: ");
            string nacionalidad = ObtenerPalabras("Ingrese la nacionalidad del cliente: ");

            try
            {
                ClienteOcasional co = new ClienteOcasional(email, password, documento, nombreCompleto, nacionalidad);
                miSistema.CrearUsuario(co);
                MensajeExito("El cliente ocasional fue creado exitosamente");
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        static void ListarPublicacionesEntreFechas()
        {
            DateTime fecha1 = PedirFecha("Ingrese fecha inicial: ");
            DateTime fecha2 = PedirFecha("Ingrese fecha final: ");
            List<Pasaje> listaPasajes = miSistema.ObtenerPasajesEntreFechas(fecha1, fecha2);
            if (listaPasajes.Count == 0)
            {
                MensajeError("No se encontraron pasajes entre esas fechas");
            }
            else
            {
                foreach (Pasaje p in listaPasajes)
                {
                    Console.WriteLine(p);
                }
            }
        }

    }
}

