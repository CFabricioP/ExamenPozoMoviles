using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAppMovilesPozoCarlos.Clases
{
    public  class Organizacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Articulo>? Articulos { get; set; }
    }
}
