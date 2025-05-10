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

        public string numVuelo
        {
            get { return _numeroDeVuelo; }       
        }

        public List<DayOfWeek> frecuencia
        {
            get { return _frecuencia; }
        }

        public Ruta Ruta
        {
            get { return _ruta; }
        }

        public Vuelo(string numeroDeVuelo, Avion avion, Ruta ruta, List<DayOfWeek> frecuencia)
        {
            _numeroDeVuelo = numeroDeVuelo;
            _avion = avion;
            _ruta = ruta;
            _frecuencia = frecuencia;
            _costoPorAsiento = -1; // se inicializa con un valor temporal
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_numeroDeVuelo)) throw new Exception("El número de vuelo no puede estar vacío");
            if (_avion == null) throw new Exception("El avión no puede ser nulo");
            if (_ruta == null) throw new Exception("La ruta no puede ser nula");
            if (_frecuencia == null || !_frecuencia.Any()) throw new Exception("Debe existir al menos un día para este vuelo");
            if (_costoPorAsiento < 0) throw new Exception("El costo del asiento no puede ser menor a 0. ¿Olvidaste llamar a CalcularCostoPorAsiento?");
        }

        public override bool Equals(object obj)
        {
            Vuelo v = obj as Vuelo;
            return v != null && v._numeroDeVuelo == this._numeroDeVuelo;
        }

        public override string ToString()
        {
            string dias = string.Join(", ", _frecuencia);
            return $"Número de vuelo : {_numeroDeVuelo} - Modelo del avión : {_avion.Modelo} - Ruta : {_ruta.aeropuertoSalida.codigo} - {_ruta.aeropuertoLlegada.codigo} - Frecuencia : {dias}";
        }

        //Método para determinar si el alcance es suficiente
        public void AlcanceSuficiente()
        {
            if (_avion.alcance < _ruta.distancia) throw new Exception("El avión no tiene el suficiente alcance para cubrir la distancia de la ruta");
        }

        //Método para calcular el costo por asiento
        public void CalcularCostoPorAsiento()
        {
            if (_avion == null || _ruta == null || _ruta.aeropuertoSalida == null || _ruta.aeropuertoLlegada == null)
                throw new Exception("No se puede calcular el costo por asiento porque falta información");

            _costoPorAsiento = (_avion.costoKm * _ruta.distancia + _ruta.aeropuertoSalida.costoOperacion + _ruta.aeropuertoLlegada.costoOperacion) / _avion.cantidadAsientos;
        }

    }
}
