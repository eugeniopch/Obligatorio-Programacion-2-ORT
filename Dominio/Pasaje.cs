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
        private Vuelo _vuelo;
        private DateTime _fechaDelVuelo;
        private Cliente _cliente;
        private Equipaje _equipaje;
        private double _precio;

        public Pasaje(Vuelo vuelo, DateTime fechaDelVuelo, Cliente cliente, Equipaje equipaje, double precio)
        {
            _id = s_ultimoId++;
            _vuelo = vuelo;
            _fechaDelVuelo = fechaDelVuelo;
            _cliente = cliente;
            _equipaje = equipaje;
            _precio = precio;
        }

        public void Validar()
        {
            if (_vuelo == null) throw new Exception("El vuelo no puede ser nulo");
            if (_cliente == null) throw new Exception("El cliente no puede ser nulo");
            if (_fechaDelVuelo == new DateTime()) throw new Exception("La fecha del vuelo no es válida");
            if (_precio < 0) throw new Exception("El precio no puede ser un valor menor a 0");
        }

        //Método para calcular el precio del pasaje
        public void CalculoDePrecio() {}
    }
}
