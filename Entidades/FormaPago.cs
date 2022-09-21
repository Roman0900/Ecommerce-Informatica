using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormaPago
    {
        private String IdFormaPago;
        private String Nombre;
        private Boolean Estado;

        public FormaPago()
        {

        }

        public string GetIdFormaPago()
        {
            return IdFormaPago;
        }
        public void SetIdFormaPago(String id)
        {
            this.IdFormaPago = id;
        }
        public string GetNombre()
        {
            return Nombre;
        }
        public void SetNombre(String nombre)
        {
            this.Nombre = nombre;

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