using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Ruta : IValidable
    {
        private int _id;
        private static int s_ultimoId = 1;
        private Aeropuerto _aeropuertoSalida;
        private Aeropuerto _aeropuertoLlegada;
        private int _distancia;

        public int distancia 
        {
            get { return _distancia; }
        }

        public int id
        {
            get { return _id; }
        }

        public Aeropuerto aeropuertoSalida
        {
            get { return _aeropuertoSalida; }
        }

        public Aeropuerto aeropuertoLlegada
        {
            get { return _aeropuertoLlegada; }
        }

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, int distancia)
        {
            _id = s_ultimoId++;
            _aeropuertoSalida = aeropuertoSalida;
            _aeropuertoLlegada = aeropuertoLlegada;
            _distancia = distancia;
        }

        public void Validar()
        {
            if (_aeropuertoSalida == null) throw new Exception("El aeropuerto de salida no puede ser nulo"); 
            if (_aeropuertoLlegada == null) throw new Exception("El aeropuerto de llegada no puede ser nulo");
            if (_distancia < 0) throw new Exception("La distancia no puede ser menor a 0");
        }

        public override bool Equals(object obj)
        {
            Ruta r = obj as Ruta;
            return r != null && r._id == this._id;
        }
    }
}
