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
                        PresioneParaContinuar();
                        break;
                    case "2":
                        PresioneParaContinuar();
                        break;
                    case "3":
                        PresioneParaContinuar();
                        break;
                    case "4":
                        PresioneParaContinuar();
                        break;
                    case "5":
                        Console.Clear();
                        miSistema.MostrarAeropuertos();
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
            Console.WriteLine("5 - Listado de aeropuertos");
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

        static int ObtenerNumeros(string mensaje)
        {
            bool exito = false;
            int numero = 0;

            while (!exito)
            {
                Console.Write(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);

                if (!exito) MensajeError("Ingrese un valor numérico");
            }

            return numero;
        }
    }
}

