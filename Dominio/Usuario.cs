﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        protected int _id;
        private static int s_ultimoId = 1;
        protected string _email;
        protected string _password;

        public int Id
        {
            get { return _id; } 
        }

        public string Email
        {
            get { return _email; }
        }

        public Usuario(string email, string password)
        {
            _id = s_ultimoId++;
            _email = email;
            _password = password;
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_email)) throw new Exception("El mail no puede estar vacío");
            if (string.IsNullOrEmpty(_password)) throw new Exception("La contraseña no puede estar vacía");
        }

        public override bool Equals(object obj)
        {
            Usuario u = obj as Usuario;
            return u != null && u._email == this._email;
        }
    }

}
