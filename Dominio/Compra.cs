using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra : IValidable
    {
        private static int s_UltId = 1;
        public int Id { get; }
        public Cliente Cliente { get; }
        public Pasaje Pasaje { get; }

        public Compra(int id, Cliente cliente, Pasaje pasaje)
        {
            Id = s_UltId++;
            Cliente = cliente;
            Pasaje = pasaje;
        }

        public void Validar()
        {
            if (Cliente == null) throw new Exception("El cliente no puede ser nulo");
            if (Pasaje == null) throw new Exception("El pasaje no puede ser nulo");
        }
    }
}
