using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {

      
            private String IdArticulo;
            private String IdProveedor;
            private String IdMarca;
            private String IdCategoria;
            private String NombreArticulo;
            private int Stock;
            private decimal PrecioUnitario;
            private Boolean Estado;

            public Productos()
            {

            }

            public String GetIdArticulo()
            {
                return IdArticulo;
            }
            public void SetIdArticulo(String ID)
            {
                this.IdArticulo = ID;
            }
            public String GetIdProveedor()
            {
                return IdProveedor;
            }
            public void SetIdProveedor(String ID)
            {
                this.IdProveedor = ID;
            }
            public String GetIdMarca()
            {
                return IdMarca;
            }
            public void SetIdMarca(String ID)
            {
                this.IdMarca = ID;
            }
            public String GetIdCategoria()
            {
                return IdCategoria;
            }
            public void SetIdCategoria(String ID)
            {
                this.IdCategoria = ID;
            }
            public String GetNombreArticulo()
            {
                return NombreArticulo;
            }
            public void SetNombreArticulo(String nombre)
            {
                this.NombreArticulo = nombre;
            }
            public int GetStock()
            {
                return Stock;
            }
            public void SetStock(int number)
            {
                this.Stock = number;
            }
            public decimal GetPrecioUnitario()
            {
                return PrecioUnitario;
            }
            public void SetPrecioUnitario(decimal precio)
            {
                this.PrecioUnitario = precio;
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

