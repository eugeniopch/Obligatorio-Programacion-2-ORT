using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteOcasional : Cliente
    {
        private bool _esElegible;

        public ClienteOcasional(string email, string password, string documento, string nombreCompleto, string nacionalidad, bool esElegible) : base(email, password, documento, nombreCompleto, nacionalidad)
        {
            _esElegible = esElegible;
        }

        public override string ToString()
        {
            return $"Nombre: {_nombreCompleto} - Email: {_email} - Nacionalidad: {_nacionalidad} - Es elegible: {_esElegible} - CLIENTE OCASIONAL";
        }

        //Método para determinar elegibilidad del cliente
        public void DeterminarElegibilidad() { }

        //Método para cambiar el estado de elegible
        public void CambiarEstadoElegible() { }
    }
}
