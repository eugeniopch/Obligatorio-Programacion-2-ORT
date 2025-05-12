using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario
    {
        protected string _documento;
        protected string _nombreCompleto;
        protected string _nacionalidad;

        public string Documento
        {
            get { return _documento; }
        }

        public string Nombre
        {
            get { return _nombreCompleto; }
        }

        public Cliente(string email, string password, string documento, string nombreCompleto, string nacionalidad) : base(email, password)
        {
            _documento = documento;
            _nombreCompleto = nombreCompleto;
            _nacionalidad = nacionalidad;
        }

        public override void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_documento)) throw new Exception("El documento no puede estar vacío");
            if (string.IsNullOrEmpty(_nombreCompleto)) throw new Exception("El nombre no puede estar vacío");
            if (string.IsNullOrEmpty(_nacionalidad)) throw new Exception("La nacionalidad no puede estar vacía");
        }
    }

}
