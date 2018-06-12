using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;


namespace MedHelpWS
{
    /// <summary>
    /// Summary description for WSMedHelp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSMedHelp : System.Web.Services.WebService
    {
        ConexionSql.SqlServer con = new ConexionSql.SqlServer();
        DataSet ds = new DataSet();



        [WebMethod]
        public void AgregarPaciente(Paciente pc)
        {
            con.Conectar();
            con.insomod(@" insert into Paciente
                           values ('"+pc.id+"','"+pc.nombre+ "','"+pc.apellido+ "','"+pc.genero+"'," +
                           "'"+pc.fechaNacimiento+"','"+pc.Domicilio+ "',"+pc.Seguro+ ",'"+pc.telefono+"'," +
                           "'"+pc.estatura+ "','"+pc.sangre+ "','"+pc.peso+ "','"+pc.adicciones+"'," +
                           "'"+pc.alergias+ "','"+pc.enfermedadFamilia+ "','"+pc.enfermedadPequeno+"');");
            
            con.Desconectar();
        }

        [WebMethod]
        public void AgregarMedicamentos(Medicamentos Med)
        {
            con.Conectar();
            con.insomod(@" insert into Medicamentos
                           values ('" + Med.Codigo + "','" + Med.Nombre + "','" + Med.Descripcion + "','" + Med.FechadeIngreso + "'," +
                           "'" + Med.FechadeVenc + "','" + Med.HoraIngreso + "');");

            con.Desconectar();
        }

        [WebMethod]
        public void AgregarDetMedicamentos(Medicamentos Med)
        {
            con.Conectar();
            con.insomod(@" insert into DetellesMed
                           values ('" + Med.Codigo + "','" + Med.NumeroRegistro + "','" + Med.CompActivo + "','" + Med.Gramaje + "'," +
                           "'" + Med.Proveedor + "','" + Med.TipoMedicamento + "','" + Med.Cantidad + "','" + Med.CostoUnitario + "');");

            con.Desconectar();
        }
    }
}
