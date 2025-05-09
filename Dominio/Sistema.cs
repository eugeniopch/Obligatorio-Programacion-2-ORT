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

        public Sistema()
        {
            PrecargarAeropuertos();
            PrecargarRutas();
            PrecargarAviones();
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
            CrearRuta("SCL", "BKK", 17550);
            CrearRuta("CAI", "AKL", 16800);
            CrearRuta("LHR", "CDG", 344);
            CrearRuta("SYD", "DXB", 12038);
            CrearRuta("PEK", "JNB", 11800);
            CrearRuta("DEL", "MEX", 14500);
            CrearRuta("YYZ", "AMS", 6000);
            CrearRuta("ICN", "SCL", 19300);
            CrearRuta("BKK", "CAI", 7380);
            CrearRuta("AKL", "JFK", 14100);
            CrearRuta("GRU", "LAX", 9900);
            CrearRuta("DXB", "NRT", 7930);
            CrearRuta("CDG", "FRA", 480);
            CrearRuta("LHR", "AMS", 370);
            CrearRuta("PEK", "BKK", 3300);
            CrearRuta("MEX", "SCL", 6600);
            CrearRuta("ICN", "SYD", 8300);
            CrearRuta("AKL", "CAI", 16500);
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
            CrearVuelo("DL202", 2, 2, new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });
            CrearVuelo("UA303", 3, 3, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("AF404", 4, 4, new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Saturday });
            CrearVuelo("LH505", 1, 5, new List<DayOfWeek> { DayOfWeek.Thursday });
            CrearVuelo("BA606", 2, 6, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("EK707", 3, 7, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("QF808", 4, 8, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("KL909", 1, 9, new List<DayOfWeek> { DayOfWeek.Saturday });
            CrearVuelo("AI110", 2, 10, new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Sunday });
            CrearVuelo("TK121", 3, 11, new List<DayOfWeek> { DayOfWeek.Monday });
            CrearVuelo("AC132", 4, 12, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("NZ143", 1, 13, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("CX154", 2, 14, new List<DayOfWeek> { DayOfWeek.Saturday });
            CrearVuelo("ET165", 3, 15, new List<DayOfWeek> { DayOfWeek.Monday });
            CrearVuelo("IB176", 4, 16, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("AV187", 1, 17, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("LA198", 2, 18, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("TP209", 3, 19, new List<DayOfWeek> { DayOfWeek.Monday });
            CrearVuelo("SA210", 4, 20, new List<DayOfWeek> { DayOfWeek.Thursday });
            CrearVuelo("KE221", 1, 21, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("JL232", 2, 22, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("SU243", 3, 23, new List<DayOfWeek> { DayOfWeek.Saturday });
            CrearVuelo("AZ254", 4, 24, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("SK265", 1, 25, new List<DayOfWeek> { DayOfWeek.Monday });
            CrearVuelo("OS276", 2, 26, new List<DayOfWeek> { DayOfWeek.Friday });
            CrearVuelo("LO287", 3, 27, new List<DayOfWeek> { DayOfWeek.Wednesday });
            CrearVuelo("HU298", 4, 28, new List<DayOfWeek> { DayOfWeek.Sunday });
            CrearVuelo("NH309", 1, 29, new List<DayOfWeek> { DayOfWeek.Tuesday });
            CrearVuelo("BR310", 2, 30, new List<DayOfWeek> { DayOfWeek.Thursday });
        }


        public void CrearAeropuerto(Aeropuerto aeropuerto)
        {
            if (aeropuerto == null) throw new Exception("El aeropuerto no puede estar vacío");
            aeropuerto.Validar();
            _aeropuertos.Add(aeropuerto);
        }

        public void CrearRuta(string codAeropuertoSalida, string codAeropuertoLlegada, int distancia)
        {
            Aeropuerto aeropuertoSalida = ObtenerAeropuertoPorId(codAeropuertoSalida);
            Aeropuerto aeropuertoLlegada = ObtenerAeropuertoPorId(codAeropuertoLlegada);
            Ruta ruta = new Ruta(aeropuertoSalida, aeropuertoLlegada, distancia);
            ruta.Validar();
            _rutas.Add(ruta);
        }

        public void CrearAvion(Avion avion) 
        {
            if (avion == null) throw new Exception("El avión no puede estar vacío");
            avion.Validar();
            _aviones.Add(avion);
        }

        public void CrearVuelo(string numeroVuelo, int idAvion, int idRuta, List<DayOfWeek> frecuencia)
        {
            Avion avion = ObtenerAvionPorId(idAvion);
            Ruta ruta = ObtenerRutaPorId(idRuta);
            Vuelo vuelo = new Vuelo(numeroVuelo, avion, ruta, frecuencia);
            vuelo.AlcanceSuficiente();
            vuelo.Validar();
            _vuelos.Add(vuelo);
        }

        public void CrearPasaje()
        {

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
            while (ruta == null && i < _aviones.Count)
            {
                if (_rutas[i].id == idRuta)
                {
                    ruta = _rutas[i];
                }
                i++;
            }
            return ruta;
        }


        //Método para mostrar los aeropuertos
        public void MostrarAeropuertos()
        {
            foreach (var aeropuerto in _aeropuertos)
            {
                Console.WriteLine(aeropuerto); // Llama automáticamente a ToString()
            }
        }



    }
}
