using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedHelpWS
{
    public class Paciente
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string genero { get; set; }
        public string fechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string fechaIngreso { get; set; }
        public string Seguro { get; set; }
        public string telefono { get; set; }
        public string estatura { get; set; }
        public string sangre { get; set; }
        public string peso { get; set; }
        public string adicciones { get; set; }
        public string alergias { get; set; }
        public string enfermedadFamilia { get; set; }
        public string enfermedadPequeno { get; set; }

    }
}