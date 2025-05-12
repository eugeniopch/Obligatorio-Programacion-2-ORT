using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Pasaje> _pasajes = new List<Pasaje>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();

        public List<Usuario> Usuarios
        {  
            get { return _usuarios; } 
        }

        public List<Vuelo> Vuelos
        {
            get { return _vuelos; }
        }

        public List<Ruta> Rutas
        {
            get { return _rutas; }
        }

        public Sistema()
        {
            PrecargarAeropuertos();
            PrecargarAviones();
            PrecargarRutas();
            PrecargarVuelos();
            PrecargarUsuarios();
            PrecargarPasajes();
        }

        public void PrecargarAeropuertos()
        {
            CrearAeropuerto(new Aeropuerto("JFK", "Nueva York", 15000, 5000));
            CrearAeropuerto(new Aeropuerto("LHR", "Londres", 17000, 5500));
            CrearAeropuerto(new Aeropuerto("NRT", "Tokio", 16000, 5200));
            CrearAeropuerto(new Aeropuerto("CDG", "París", 16500, 5100));
            CrearAeropuerto(new Aeropuerto("SYD", "Sídney", 14000, 4800));
            CrearAeropuerto(new Aeropuerto("DXB", "Dubái", 15500, 4900));
            CrearAeropuerto(new Aeropuerto("FRA", "Fráncfort", 15800, 5000));
            CrearAeropuerto(new Aeropuerto("GRU", "São Paulo", 13000, 4700));
            CrearAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 14500, 4950));
            CrearAeropuerto(new Aeropuerto("PEK", "Pekín", 15000, 5200));
            CrearAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 12000, 4500));
            CrearAeropuerto(new Aeropuerto("DEL", "Nueva Delhi", 13500, 4600));
            CrearAeropuerto(new Aeropuerto("MEX", "Ciudad de México", 12500, 4400));
            CrearAeropuerto(new Aeropuerto("YYZ", "Toronto", 14000, 4700));
            CrearAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 15000, 5000));
            CrearAeropuerto(new Aeropuerto("ICN", "Seúl", 15500, 5100));
            CrearAeropuerto(new Aeropuerto("SCL", "Santiago", 12800, 4500));
            CrearAeropuerto(new Aeropuerto("BKK", "Bangkok", 14500, 4800));
            CrearAeropuerto(new Aeropuerto("CAI", "El Cairo", 12000, 4300));
            CrearAeropuerto(new Aeropuerto("AKL", "Auckland", 13800, 4600));
        }

        public void PrecargarRutas()
        {
            CrearRuta("JFK", "LHR", 5567);  
            CrearRuta("NRT", "SYD", 7824);  
            CrearRuta("CDG", "DXB", 5245);  
            CrearRuta("FRA", "GRU", 9795);  
            CrearRuta("LAX", "PEK", 10064); 
            CrearRuta("JNB", "DEL", 8012);  
            CrearRuta("MEX", "YYZ", 3260);  
            CrearRuta("AMS", "ICN", 8592);  
            CrearRuta("SCL", "BKK", 7380);  
            CrearRuta("CAI", "AKL", 12800);  
            CrearRuta("LHR", "CDG", 344);   
            CrearRuta("SYD", "DXB", 12038); 
            CrearRuta("PEK", "JNB", 11800); 
            CrearRuta("DEL", "MEX", 11500);  
            CrearRuta("YYZ", "AMS", 6000);  
            CrearRuta("ICN", "SCL", 8200);   
            CrearRuta("BKK", "CAI", 7380);  
            CrearRuta("AKL", "JFK", 14100); 
            CrearRuta("GRU", "LAX", 9900);  
            CrearRuta("DXB", "NRT", 7930);  
            CrearRuta("CDG", "FRA", 480);   
            CrearRuta("LHR", "AMS", 370);   
            CrearRuta("PEK", "BKK", 3300);  
            CrearRuta("MEX", "SCL", 6600);  
            CrearRuta("ICN", "SYD", 8300);  
            CrearRuta("AKL", "CAI", 12800); 
            CrearRuta("DEL", "YYZ", 11700); 
            CrearRuta("GRU", "CAI", 10400); 
            CrearRuta("JNB", "SCL", 9200);  
            CrearRuta("LAX", "JFK", 3974);  
        }

        public void PrecargarAviones()
        {
            CrearAvion(new Avion("Boeing 737", 160, 5600, 25.5));
            CrearAvion(new Avion("Airbus A320", 150, 6100, 24.8));
            CrearAvion(new Avion("Embraer E190", 100, 4500, 19.2));
            CrearAvion(new Avion("Boeing 787", 242, 14100, 45.3));
        }

        public void PrecargarVuelos()
        {
            CrearVuelo("AA101", 1, 1, new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday });
            CrearVuelo("DL202", 4, 2, new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });
            CrearVuelo("UA303", 4, 3, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("AF404", 4, 4, new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Saturday });
            CrearVuelo("LH505", 4, 5, new List<DayOfWeek> { DayOfWeek.Thursday });
            CrearVuelo("BA606", 4, 6, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("EK707", 3, 7, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("QF808", 4, 8, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("KL909", 4, 9, new List<DayOfWeek> { DayOfWeek.Saturday });
            CrearVuelo("AI110", 4, 10, new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Sunday });
            CrearVuelo("TK121", 3, 11, new List<DayOfWeek> { DayOfWeek.Monday });
            CrearVuelo("AC132", 4, 12, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("NZ143", 4, 13, new List<DayOfWeek> { DayOfWeek.Tuesday });         
            CrearVuelo("CX154", 4, 14, new List<DayOfWeek> { DayOfWeek.Saturday });        
            CrearVuelo("ET165", 4, 15, new List<DayOfWeek> { DayOfWeek.Monday });          
            CrearVuelo("IB176", 4, 16, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("AV187", 4, 17, new List<DayOfWeek> { DayOfWeek.Sunday });          
            CrearVuelo("LA198", 4, 18, new List<DayOfWeek> { DayOfWeek.Friday });          
            CrearVuelo("TP209", 4, 19, new List<DayOfWeek> { DayOfWeek.Monday });          
            CrearVuelo("SA210", 4, 20, new List<DayOfWeek> { DayOfWeek.Thursday });
            CrearVuelo("KE221", 1, 21, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("JL232", 2, 22, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("SU243", 4, 23, new List<DayOfWeek> { DayOfWeek.Saturday });        
            CrearVuelo("AZ254", 4, 24, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("SK265", 4, 25, new List<DayOfWeek> { DayOfWeek.Monday });          
            CrearVuelo("OS276", 4, 26, new List<DayOfWeek> { DayOfWeek.Friday });          
            CrearVuelo("LO287", 4, 27, new List<DayOfWeek> { DayOfWeek.Wednesday });       
            CrearVuelo("HU298", 4, 28, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("NH309", 4, 29, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("BR310", 4, 30, new List<DayOfWeek> { DayOfWeek.Thursday });        
        }


        public void PrecargarUsuarios()
        {
            // Administradores
            CrearUsuario(new Administrador("admin1@correo.com", "admin123", "Admin1"));
            CrearUsuario(new Administrador("admin2@correo.com", "admin456", "Admin2"));

            // Clientes Premium
            CrearUsuario(new ClientePremium("premium1@correo.com", "clave123", "12345678", "Ana García", "Uruguaya", 100));
            CrearUsuario(new ClientePremium("premium2@correo.com", "clave456", "23456789", "Luis Pérez", "Argentino", 200));
            CrearUsuario(new ClientePremium("premium3@correo.com", "clave789", "34567890", "Lucía Torres", "Chilena", 150));
            CrearUsuario(new ClientePremium("premium4@correo.com", "clave321", "45678901", "Carlos Ruiz", "Paraguayo", 300));
            CrearUsuario(new ClientePremium("premium5@correo.com", "clave654", "56789012", "Valentina Díaz", "Uruguaya", 250));

            // Clientes Ocasionales
            CrearUsuario(new ClienteOcasional("ocasional1@correo.com", "pass111", "67890123", "Mateo Fernández", "Brasileño"));
            CrearUsuario(new ClienteOcasional("ocasional2@correo.com", "pass222", "78901234", "Martina Gómez", "Uruguaya"));
            CrearUsuario(new ClienteOcasional("ocasional3@correo.com", "pass333", "89012345", "Joaquín López", "Boliviano"));
            CrearUsuario(new ClienteOcasional("ocasional4@correo.com", "pass444", "90123456", "Sofía Herrera", "Argentina"));
            CrearUsuario(new ClienteOcasional("ocasional5@correo.com", "pass555", "01234567", "Emilia Costa", "Uruguaya"));
        }

        public void PrecargarPasajes()
        {
            CrearPasaje("AA101", "12345678", Equipaje.LIGHT, new DateTime(2025, 5, 19));
            CrearPasaje("DL202", "23456789", Equipaje.CABINA, new DateTime(2025, 5, 20));
            CrearPasaje("UA303", "34567890", Equipaje.BODEGA, new DateTime(2025, 5, 21));
            CrearPasaje("AF404", "45678901", Equipaje.LIGHT, new DateTime(2025, 5, 24));
            CrearPasaje("LH505", "56789012", Equipaje.CABINA, new DateTime(2025, 5, 22));
            CrearPasaje("BA606", "67890123", Equipaje.BODEGA, new DateTime(2025, 5, 23));
            CrearPasaje("EK707", "78901234", Equipaje.LIGHT, new DateTime(2025, 5, 18));
            CrearPasaje("QF808", "89012345", Equipaje.CABINA, new DateTime(2025, 5, 27));
            CrearPasaje("KL909", "90123456", Equipaje.BODEGA, new DateTime(2025, 5, 24));
            CrearPasaje("AI110", "01234567", Equipaje.LIGHT, new DateTime(2025, 5, 21));
            CrearPasaje("TK121", "12345678", Equipaje.CABINA, new DateTime(2025, 5, 19));
            CrearPasaje("AC132", "23456789", Equipaje.BODEGA, new DateTime(2025, 5, 23));
            CrearPasaje("NZ143", "34567890", Equipaje.LIGHT, new DateTime(2025, 5, 20));
            CrearPasaje("CX154", "45678901", Equipaje.CABINA, new DateTime(2025, 5, 24));
            CrearPasaje("ET165", "56789012", Equipaje.BODEGA, new DateTime(2025, 5, 19));
            CrearPasaje("IB176", "67890123", Equipaje.LIGHT, new DateTime(2025, 5, 21));
            CrearPasaje("AV187", "78901234", Equipaje.CABINA, new DateTime(2025, 5, 18));
            CrearPasaje("LA198", "89012345", Equipaje.BODEGA, new DateTime(2025, 5, 23));
            CrearPasaje("TP209", "90123456", Equipaje.LIGHT, new DateTime(2025, 5, 26));
            CrearPasaje("SA210", "01234567", Equipaje.CABINA, new DateTime(2025, 5, 22));
            CrearPasaje("KE221", "12345678", Equipaje.BODEGA, new DateTime(2025, 5, 21));
            CrearPasaje("JL232", "23456789", Equipaje.LIGHT, new DateTime(2025, 5, 20));
            CrearPasaje("SU243", "34567890", Equipaje.CABINA, new DateTime(2025, 5, 24));
            CrearPasaje("AZ254", "45678901", Equipaje.BODEGA, new DateTime(2025, 5, 25));
            CrearPasaje("SK265", "56789012", Equipaje.LIGHT, new DateTime(2025, 5, 26));
        }


        public void CrearAeropuerto(Aeropuerto aeropuerto)
        {
            if (aeropuerto == null) throw new Exception("El aeropuerto no puede estar vacío");
            aeropuerto.Validar();
            if (_aeropuertos.Contains(aeropuerto)) throw new Exception("Ya existe un aeropuerto con ese código IATA");
            _aeropuertos.Add(aeropuerto);
        }

        public void CrearRuta(string codAeropuertoSalida, string codAeropuertoLlegada, int distancia)
        {
            Aeropuerto aeropuertoSalida = ObtenerAeropuertoPorId(codAeropuertoSalida);
            Aeropuerto aeropuertoLlegada = ObtenerAeropuertoPorId(codAeropuertoLlegada);
            Ruta ruta = new Ruta(aeropuertoSalida, aeropuertoLlegada, distancia);
            ruta.Validar();
            if (_rutas.Contains(ruta)) throw new Exception("Ya existe una ruta con ese id");
            _rutas.Add(ruta);
        }

        public void CrearAvion(Avion avion) 
        {
            if (avion == null) throw new Exception("El avión no puede estar vacío");
            avion.Validar();
            if (_aviones.Contains(avion)) throw new Exception("Ya existe un avión con ese id");
            _aviones.Add(avion);
        }

        public void CrearVuelo(string numeroVuelo, int idAvion, int idRuta, List<DayOfWeek> frecuencia)
        {
            Avion avion = ObtenerAvionPorId(idAvion);
            Ruta ruta = ObtenerRutaPorId(idRuta);

            if (avion == null) throw new Exception("Avión no encontrado");
            if (ruta == null) throw new Exception("Ruta no encontrada");

            Vuelo vuelo = new Vuelo(numeroVuelo, avion, ruta, frecuencia);
            vuelo.AlcanceSuficiente();
            vuelo.CalcularCostoPorAsiento();
            vuelo.Validar();

            if (_vuelos.Contains(vuelo)) throw new Exception("Ya existe un vuelo con ese número de vuelo");

            _vuelos.Add(vuelo);
        }


        public void CrearUsuario(Usuario usuario)
        {
            if (usuario == null) throw new Exception("El usuario no puede ser null");
            usuario.Validar();
            if (_usuarios.Contains(usuario)) throw new Exception("Ya existe un usuario con ese email");
            _usuarios.Add(usuario);
        }

        public void CrearPasaje(string codVuelo, string documento, Equipaje equipaje, DateTime fechaVuelo)
        {
            Vuelo vuelo = ObtenerVueloPorId(codVuelo);
            Cliente cliente = ObtenerClientePorDoc(documento);
            if (cliente == null) throw new Exception($"No se encontró un cliente con el documento {documento}");


            if (!vuelo.frecuencia.Contains(fechaVuelo.DayOfWeek)) throw new Exception("La fecha ingresada no coincide con los días disponibles para este vuelo");

            Pasaje pasaje = new Pasaje(vuelo, fechaVuelo, cliente, equipaje, 0);
            if (_pasajes.Contains(pasaje)) throw new Exception("Ya existe un pasaje con ese id");
            _pasajes.Add(pasaje);

        }

        public Aeropuerto ObtenerAeropuertoPorId(string codAeropuerto)
        {
            Aeropuerto aero = null;
            int i = 0;
            while (aero == null && i < _aeropuertos.Count)
            {
                if (_aeropuertos[i].codigo == codAeropuerto)
                {
                    aero = _aeropuertos[i];
                }
                i++;
            }
            return aero;
        }

        public Avion ObtenerAvionPorId(int idAvion)
        {
            Avion avion = null;
            int i = 0;
            while (avion == null && i < _aviones.Count)
            {
                if (_aviones[i].id == idAvion)
                {
                    avion = _aviones[i];
                }
                i++;
            }
            return avion;
        }

        public Ruta ObtenerRutaPorId(int idRuta)
        {
            Ruta ruta = null;
            int i = 0;
            while (ruta == null && i < _rutas.Count)
            {
                if (_rutas[i].id == idRuta)
                {
                    ruta = _rutas[i];
                }
                i++;
            }
            return ruta;
        }

        public Vuelo ObtenerVueloPorId(string codVuelo)
        {
            Vuelo vuelo = null;
            int i = 0;
            while (vuelo == null && i < _vuelos.Count)
            {
                if (_vuelos[i].numVuelo == codVuelo)
                {
                    vuelo = _vuelos[i];
                }
                i++;
            }
            return vuelo;
        }

        public Cliente ObtenerClientePorDoc(string documento)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente c && c.Documento == documento)
                {
                    return c;
                }
            }
            return null;
        }

        public List<Vuelo> ObtenerVuelosPorCodigoAeropuerto(string codigo)
        {
            List<Vuelo> resultado = new List<Vuelo>();
            string codigoMayus = codigo.ToUpper();

            foreach (Vuelo v in _vuelos)
            {
                Ruta r = v.Ruta;
                if (r.aeropuertoSalida.codigo == codigoMayus || r.aeropuertoLlegada.codigo == codigoMayus)
                {
                    resultado.Add(v);
                }
            }

            return resultado;
        }

        public List<Pasaje> ObtenerPasajesEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Pasaje> listadoPasajes = new List<Pasaje>();

            if (fecha1.Date < fecha2.Date)
            {

                foreach (Pasaje p in _pasajes)
                {
                    if (p.FechaVuelo.Date > fecha1.Date && p.FechaVuelo.Date < fecha2.Date)
                    {
                        listadoPasajes.Add(p);
                    }
                }
            }
            else
            {
                foreach (Pasaje p in _pasajes)
                {
                    if (p.FechaVuelo.Date > fecha2.Date && p.FechaVuelo.Date < fecha1.Date)
                    {
                        listadoPasajes.Add(p);
                    }
                }
            }
            return listadoPasajes;
        }

    }
}
