using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marcas
    {
        private String IdMarca;
        private String NombreMarca;
        private Boolean Estado;

        public Marcas()
        {
        }

        public String GetIdmarca()
        {
            return IdMarca;
        }
        public void SetIdMarca(String ID)
        {
            this.IdMarca = ID;
        }
        public String GetNombreMarca()
        {
            return NombreMarca;
        }
        public void SetNombreMarca(String nombre)
        {
            this.NombreMarca = nombre;
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
