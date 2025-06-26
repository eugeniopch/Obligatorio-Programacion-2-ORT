using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Pasaje : IValidable, IComparable<Pasaje>
    {
        private int _id;
        private static int s_ultimoId = 1;
        public Vuelo Vuelo { get; set; }
        public DateTime FechaVuelo { get; set; }
        public Cliente Cliente { get; set; }
        public Equipaje Equipaje { get; set; }
        public double Precio { get; set; }

        public int Id {  get { return _id; } }

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

        public void CalculoDePrecio()
        {
            if (Vuelo == null || Cliente == null) throw new Exception("No se puede calcular el precio sin vuelo ni cliente");

            double costoBase = Vuelo.CostoPorAsiento;
            double margenGanancia = 0.25;
            double adicionalEquipaje = 0;

            if (Cliente is ClienteOcasional)
            {
                if (Equipaje == Equipaje.CABINA)
                    adicionalEquipaje = 0.10;
                else if (Equipaje == Equipaje.BODEGA)
                    adicionalEquipaje = 0.20;
            }
            else if (Cliente is ClientePremium)
            {
                if (Equipaje == Equipaje.BODEGA)
                    adicionalEquipaje = 0.05;
            }

            double porcentajeTotal = margenGanancia + adicionalEquipaje;
            double subtotal = costoBase * (1 + porcentajeTotal);
            double tasas = Vuelo.Ruta.AeropuertoSalida.CostoOperacion + Vuelo.Ruta.AeropuertoLlegada.CostoOperacion;

            Precio = Math.Round(subtotal + tasas, 2);
        }


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

        public int CompareTo(Pasaje other)
        {
            if (other == null) return -1;
            return other.Precio.CompareTo(this.Precio);
        }
    }

}
