using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedores
    {
        private String IdProveedor;
        private String RazonSocial;
        private String Direccion;
        private String Provincia;
        private String Ciudad;
        private String Telefono;
        private String Web;
        private String Email;
        private Boolean Estado;

        public Proveedores()
        {

        }

        public String GetIdProveedor()
        {
            return IdProveedor;

        }
        public void SetIdProveedor(String ID)
        {
            this.IdProveedor = ID;

        }
        public String GetRazonSocial()
        {
            return RazonSocial;

        }
        public void SetRazonSocial(String razonsocial)
        {
            this.RazonSocial = razonsocial;

        }
        public String GetDireccion()
        {
            return Direccion;

        }
        public void SetDireccion(String dire)
        {
            this.Direccion = dire;

        }
        public String GetProvincia()
        {
            return Provincia;

        }
        public void SetProvincia(String provincia)
        {
            this.Provincia = provincia;

        }
        public String GetCiudad()
        {
            return Ciudad;

        }
        public void SetCiudad(String ciudad)
        {
            this.Ciudad = ciudad;

        }
        public String GetTelefono()
        {
            return Telefono;

        }
        public void SetTelefono(String telefono)
        {
            this.Telefono = telefono;

        }
        public String GetWeb()
        {
            return Web;

        }
        public void SetWeb(String web)
        {
            this.Web = web;

        }
        public String GetEmail()
        {
            return Email;

        }
        public void SetEmail(String email)
        {
            this.Email = email;

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
