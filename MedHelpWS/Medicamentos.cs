using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedHelpWS
{
    public class Medicamentos
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechadeIngreso { get; set; }
        public string FechadeVenc { get; set; }
        public string HoraIngreso { get; set; }
        public string NumeroRegistro { get; set; }
        public string CompActivo { get; set; }
        public string Gramaje { get; set; }
        public string Proveedor { get; set; }
        public string TipoMedicamento { get; set; }
        public int Cantidad { get; set; }
        public float CostoUnitario { get; set; }
        
    }
}