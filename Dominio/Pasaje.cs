using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Pasaje : IValidable
    {
        private int _id;
        private static int s_ultimoId = 1;
        public Vuelo Vuelo { get; set; }
        public DateTime FechaVuelo { get; set; }
        public Cliente Cliente { get; set; }
        public Equipaje Equipaje { get; set; }
        public double Precio { get; set; }

        public Pasaje() 
        {
            _id = s_ultimoId++;
        }

        public Pasaje(Vuelo vuelo, DateTime fechaDelVuelo, Cliente cliente, Equipaje equipaje, double precio)
        {
            _id = s_ultimoId++;
            Vuelo = vuelo;
            FechaVuelo = fechaDelVuelo;
            Cliente = cliente;
            Equipaje = equipaje;
            Precio = precio;
        }

        //Método para calcular el precio del pasaje
        public void CalculoDePrecio() {}

        public void Validar()
        {
            if (Vuelo == null) throw new Exception("El vuelo no puede ser nulo");
            if (Cliente == null) throw new Exception("El cliente no puede ser nulo");
            if (FechaVuelo == new DateTime()) throw new Exception("La fecha del vuelo no es válida");
            if (Precio < 0) throw new Exception("El precio no puede ser un valor menor a 0");
        }

        public override string ToString()
        {
            if (Cliente == null)
            {
                return $"ID: {_id} - Cliente no encontrado - Fecha: {FechaVuelo.ToShortDateString()} - Número de vuelo: {Vuelo.NumVuelo} ";
            }
            return $"ID: {_id} - Nombre del cliente: {Cliente.Nombre} - Fecha: {FechaVuelo.ToShortDateString()} - Número de vuelo: {Vuelo.NumVuelo} ";
        }

        public override bool Equals(object obj)
        {
            Pasaje p = obj as Pasaje;
            return p != null && p._id == this._id;
        }
    }

}
