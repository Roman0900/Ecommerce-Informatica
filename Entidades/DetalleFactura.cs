using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
     private String  IdFactura;
     private String  IdArticulo;
     private int     Cantidad;
     private decimal  PrecioUnitario;
     private Boolean Estado;
   
        public DetalleFactura()
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
        public String GetIdArticulo()
        {
            return IdArticulo;
        }
        public void SetIdArticulo (String id)
        {
            this.IdArticulo = id;
        }
        public int GetCantidad()
        {
            return Cantidad;
        }
        public void SetCantidad (int cant)
        {
            this.Cantidad = cant;
        }
        public decimal GetPrecioUnitario()
        {
            return PrecioUnitario;
        }
        public void SetPrecioUnitario (decimal precio)
        {
            this.PrecioUnitario = precio;
        }
        public Boolean GetEstado()
        {
            return Estado;
        }
        public void SetEstado (Boolean estado)
        {
            this.Estado = estado;
        }













    }

}

