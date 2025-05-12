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

        public ClienteOcasional(string email, string password, string documento, string nombreCompleto, string nacionalidad) : base(email, password, documento, nombreCompleto, nacionalidad)
        {
            DeterminarElegibilidad();
        }

        //Método para determinar elegibilidad del cliente
        public void DeterminarElegibilidad()
        {
            Random random = new Random();
            _esElegible = random.Next(2) == 0;
        }

        //Método para cambiar el estado de elegible
        public void CambiarEstadoElegible()
        {
            _esElegible = !_esElegible;
        }

        public override string ToString()
        {
            return $"id {_id} Nombre: {_nombreCompleto} - Email: {_email} - Nacionalidad: {_nacionalidad} - Es elegible: {_esElegible} - CLIENTE OCASIONAL";
        }

        public override bool Equals(object obj)
        {
            ClienteOcasional c = obj as ClienteOcasional;
            return c != null && c._email == this._email;
        }
    }

}
