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

        public bool EsElegible { get; set; }

        public ClienteOcasional(string email, string password,
                                string documento, string nombreCompleto,
                                string nacionalidad)
            : base(email, password, documento, nombreCompleto, nacionalidad)
        {
            DeterminarElegibilidad();
        }

        public void DeterminarElegibilidad()
        {
            Random random = new Random();
            EsElegible = (random.Next(2) == 0);
        }

        public void CambiarEstadoElegible()
        {
            EsElegible = !EsElegible;
        }

        public override string ToString()
        {
            return $"id {_id} Nombre: {_nombreCompleto} - Email: {_email} " +
                   $"- Nacionalidad: {_nacionalidad} - Es elegible: {EsElegible} " +
                   "- CLIENTE OCASIONAL";
        }

        public override bool Equals(object obj)
        {
            ClienteOcasional c = obj as ClienteOcasional;
            return c != null && c._email == this._email;
        }
    }

}
