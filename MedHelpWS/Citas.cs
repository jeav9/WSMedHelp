using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedHelpWS
{
    public class Citas
    {
        public string id { get; set; }
        public string Fecha { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Final { get; set; }
        public string Descripcion { get; set; }
        public string NumColegiado { get; set; }
        public string NomMedico { get; set; }
        public string Estado_cita { get; set; }
    }
}
