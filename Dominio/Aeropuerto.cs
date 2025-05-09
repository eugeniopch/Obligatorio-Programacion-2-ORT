using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Aeropuerto : IValidable
    {
        private string _codigoIATA;
        private string _ciudad;
        private double _costoDeOperacion;
        private double _costoTasas;

        public string codigo
        {
            get { return _codigoIATA; }
        }

        public double costoOperacion
        {
            get { return _costoDeOperacion; }
        }

        public Aeropuerto(string codigoIATA, string ciudad, double costoDeOperacion, double costoTasas)
        {
            _codigoIATA = codigoIATA;
            _ciudad = ciudad;
            _costoDeOperacion = costoDeOperacion;
            _costoTasas = costoTasas;
        }

        public void Validar()
        {
            if ((string.IsNullOrEmpty(_codigoIATA)) || _codigoIATA.Length != 3) throw new Exception("El código IATA no puede estar vacío y debe contener 3 letras");
            if (string.IsNullOrEmpty(_ciudad)) throw new Exception("El campo CIUDAD no puede estar vacío");
            if (_costoDeOperacion < 0) throw new Exception("El costo de operación no puede ser menor a 0");
            if (_costoTasas < 0) throw new Exception("El costo de las tasas no puede ser menor a 0");
        }

        public override string ToString()
        {
            return $"Código IATA : {_codigoIATA} - Ciudad : {_ciudad} - Costo de operación : {_costoDeOperacion} - Costo de tasas : {_costoTasas}";
        }
    }
}
