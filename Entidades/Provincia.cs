using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private String IdProvincia;
        private String Nombre;
        private Boolean Estado;

        public Provincia()
        {

        }

        public String GetIdProvincia()
        {
            return IdProvincia;

        }
        public void SetIdProvincia(String id)
        {
            this.IdProvincia = id;
        }
        public String GetNombre()
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
