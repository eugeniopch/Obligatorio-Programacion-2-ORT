using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Avion : IValidable
    {
        private int _id;
        private static int s_ultimoId = 1;
        private string _fabricante;
        private int _cantidadAsientos;
        private int _alcance;
        private double _costoDeOperacionPorKm;

        public int alcance
        {
            get { return _alcance; }
        }

        public int id
        {
            get { return _id; }
        }

        public double costoKm
        { 
            get { return _costoDeOperacionPorKm; } 
        }

        public int cantidadAsientos
        {
            get { return _cantidadAsientos; }
        }

        public string Modelo
        {
            get { return _fabricante; }
        }

        public Avion(string fabricante, int cantidadAsientos, int alcance, double costoDeOperacionPorKm)
        {
            _id = s_ultimoId++;
            _fabricante = fabricante;
            _cantidadAsientos = cantidadAsientos;
            _alcance = alcance;
            _costoDeOperacionPorKm = costoDeOperacionPorKm;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_fabricante)) throw new Exception("El fabricante no puede ser nulo");
            if (_cantidadAsientos < 0) throw new Exception("La cantidad de asientos no puede ser menor a 0");
            if (_alcance < 0) throw new Exception("El alcance no puede ser menor a 0");
            if (_costoDeOperacionPorKm < 0) throw new Exception("El costo de operacion por kilómetro no puede ser menor a 0");
        }

        public override bool Equals(object obj)
        {
            Avion a = obj as Avion;
            return a != null && a._id == this._id;
        }
    }
}
