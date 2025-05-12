using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        private string _apodo;
        public Administrador(string email, string password, string apodo) : base(email, password)
        {
            _apodo = apodo;
        }

        public override void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_apodo)) throw new Exception("El apodo no puede estar vacío");
        }

        public override string ToString()
        {
            return $"Usuario: {_apodo} - Email: {_email} - ADMINISTRADOR";
        }
    }

}
