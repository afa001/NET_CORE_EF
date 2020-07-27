using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_EF.Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
