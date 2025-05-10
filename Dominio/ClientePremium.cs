using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium : Cliente
    {
        private int _puntos;

        public ClientePremium(string email, string password, string documento, string nombreCompleto, string nacionalidad, int puntos) : base(email, password, documento, nombreCompleto, nacionalidad)
        {
            _puntos = puntos;
        }

        public override void Validar()
        {
            base.Validar();
            if (_puntos < 0) throw new Exception("Los puntos no pueden ser menores a 0");
        }

        public override string ToString() 
        {
            return $"id {_id} Nombre: {_nombreCompleto} - Email: {_email} - Nacionalidad: {_nacionalidad} - Puntos: {_puntos} - CLIENTE PREMIUM";
        }

        //Método para modificar los puntos del cliente premium

        public void ModificarPuntos() { }
    }
}
