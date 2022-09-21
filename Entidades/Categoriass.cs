using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoriass
    {
        private String IdCategoria;
        private String NombreCategoria;
        private Boolean Estado;

        public Categoriass()
        {

        }

        public String GetIdCategoria()
        {
            return IdCategoria;
        }

        public void SetIdCategoria(String ID)
        {
            this.IdCategoria = ID;
        }
        public String GetNombreCategoria()
        {
            return NombreCategoria;
        }

        public void SetNombreCategoria(String nombre)
        {
            this.NombreCategoria = nombre;
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
