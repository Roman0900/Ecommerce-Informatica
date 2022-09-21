using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personass
    {
        private String Dni;
        private String Nombre;
        private String Apellido;
        private String Password;
        private String Telefono;
        private String Email;
        private Boolean Tipo;
        private Boolean Estado;

        public Personass()
        {

        }
        public String GetDni()
        {
            return Dni;
        }
        public void SetDni(String dni)
        {
            this.Dni = dni;
        }
        public String GetNombre()
        {
            return Nombre;
        }
        public void SetNombre(String nombre)
        {
            this.Nombre = nombre;
        }
        public String GetApellido()
        {
            return Apellido;
        }
        public void SetApellido(String apellido)
        {
            this.Apellido = apellido;
        }
        public String GetPassword()
        {
            return Password;
        }
        public void SetPassword(String password)
        {
            this.Password = password;
        }
        public String GetTelefono()
        {
            return Telefono;
        }
        public void SetTelefono(String telefono)
        {
            this.Telefono = telefono;
        }
        public String GetEmail()
        {
            return Email;
        }
        public void SetEmail(String email)
        {
            this.Email = email;
        }
        public Boolean GetTipo()
        {
            return Tipo;
        }
        public void SetTipo(Boolean tipo)
        {
            this.Tipo = tipo;
        }
        public Boolean GetEstado()
        {
            return Estado;
        }
        public void SetEstado(Boolean estado)
        {
            this.Estado = estado;
        }
    }
}
