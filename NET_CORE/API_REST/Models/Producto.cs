using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public string Tipo { get; set; }
        public long Precio { get; set; }
    }
}
