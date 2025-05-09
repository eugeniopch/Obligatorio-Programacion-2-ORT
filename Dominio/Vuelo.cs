using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Vuelo : IValidable
    {
        private string _numeroDeVuelo;
        private Avion _avion;
        private Ruta _ruta;
        private List<DayOfWeek> _frecuencia;
        private double _costoPorAsiento;

        public Vuelo(string numeroDeVuelo, Avion avion, Ruta ruta, List<DayOfWeek> frecuencia)
        {
            _numeroDeVuelo = numeroDeVuelo;
            _avion = avion;
            _ruta = ruta;
            _frecuencia = frecuencia;
            _costoPorAsiento = CostoPorAsiento();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_numeroDeVuelo)) throw new Exception("El número de vuelo no puede estar vacío");
            if (_avion == null) throw new Exception("El avión no puede ser nulo");
            if (_ruta == null) throw new Exception("El avión no puede ser nulo");
            if (_costoPorAsiento < 0) throw new Exception("El costo del asiento no puede ser menor a 0");
            if (_frecuencia == null || !_frecuencia.Any()) throw new Exception("Debe existir al menos un día para este vuelo");
        }

        //Método para determinar si el alcance es suficiente
        public void AlcanceSuficiente()
        {
            if (_avion.alcance < _ruta.distancia) throw new Exception("El avión no tiene el suficiente alcance para cubrir la distancia de la ruta");
        }

        //Método para calcular el costo por asiento
        public double CostoPorAsiento() 
        {
            return (_avion.costoKm * _ruta.distancia + _ruta.aeropuertoSalida.costoOperacion + _ruta.aeropuertoLllegada.costoOperacion) / _avion.cantidadAsientos;
        }
    }
}
