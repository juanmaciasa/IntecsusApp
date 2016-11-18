using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecsusApplication.Logica
{
    public class Persona
    {
        private string nombre, apellido, numIdentificacion, email;

        public Persona(string Nombre, string Apellido, string NumIdentificacion, string Email)
        {
            nombre = Nombre;
            apellido = Apellido;
            numIdentificacion = NumIdentificacion;
            email = Email;
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string NumIdentificacion
        {
            get
            {
                return numIdentificacion;
            }

            set
            {
                numIdentificacion = value;
            }
        }
    }
}
