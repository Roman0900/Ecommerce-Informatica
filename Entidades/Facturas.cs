using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Facturas
    {
        private String IdFactura;
        private String Dni;
        private String IdFormaPago;
        private String Fecha;
        private float Total;
        private Boolean Estado;

        public Facturas()
        {

        }

        public String GetIdFactura()
        {
            return IdFactura;
        }
        public void SetIdFactura(String id)
        {
            this.IdFactura = id;
        }
        public String GetDni()
        {
            return Dni;
        }
        public void SetDni(String dni)
        {
            this.Dni = dni;
        }
        public String GetIdFormaPago()
        {
            return IdFormaPago;
        }
        public void SetIdFormaPago(String id)
        {
            this.IdFormaPago = id;
        }
        public String GetFecha()
        {
            return Fecha;
        }
        public void SetFecha(String fecha)
        {
            this.Fecha = fecha;
        }
        public float GetTotal()
        {
            return Total;

        }
        public void SetTotal(float total)
        {
            this.Total = total;
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
