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

        [WebMethod]
        public DataSet MostrarTabla(string codigo)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar(@"select Medicamentos.Codigo,Medicamentos.Nombre,DetellesMed.Cantidad,Medicamentos.Descripcion,DetellesMed.NRegistro,
                                    DetellesMed.CompActivo, DetellesMed.Gramaje, DetellesMed.TipoMed, DetellesMed.TipoMed, DetellesMed.CostoUni from Medicamentos
                                    inner join DetellesMed
                                    on DetellesMed.Codigo = Medicamentos.Codigo
                                    where Medicamentos.Codigo like '%"+codigo+"%'").Tables[0].DataSet;
            con.Desconectar();
            return ds;
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

        [WebMethod]
        public void ModificarMedicamentos(Medicamentos Med)
        {
            con.Conectar();
            con.insomod(@" update Medicamentos set 
                           Nombre='" + Med.Nombre + "',Descripcion='" + Med.Descripcion + "',FIngreso='" + Med.FechadeIngreso + "',FVenc='" + Med.FechadeVenc + "',HIngreso=" +
                           "'" + Med.HoraIngreso + "' where Codigo='"+ Med.Codigo +"'");

            con.Desconectar();
        }

        [WebMethod]
        public void ModificarDetMedicamentos(Medicamentos Med)
        {
            con.Conectar();
            con.insomod(@" update DetellesMed set NRegistro='" + Med.NumeroRegistro + "',CompActivo='" + Med.CompActivo + "',Gramaje='" + Med.Gramaje + "',Proveedor=" +
                           "'" + Med.Proveedor + "',TipoMed='" + Med.TipoMedicamento + "',Cantidad='" + Med.Cantidad + "',CostoUni='" + Med.CostoUnitario + "' where Codigo='" + Med.Codigo + "'");

            con.Desconectar();
        }

        //Codigo Jorge- Carmen////////////

        [WebMethod]
        public void AgregarPaciente(Paciente pc)
        {
            con.Conectar();
            con.insomod(@" insert into Paciente
                           values ('" + pc.id + "','" + pc.nombre + "','" + pc.apellido + "','" + pc.genero + "'," +
                           "'" + pc.fechaNacimiento + "','" + pc.Domicilio + "'," + pc.Seguro + ",'" + pc.telefono + "'," +
                           "'" + pc.estatura + "','" + pc.sangre + "','" + pc.peso + "','" + pc.adicciones + "'," +
                           "'" + pc.alergias + "','" + pc.enfermedadFamilia + "','" + pc.enfermedadPequeno + "');");

            con.Desconectar();
        }

        public Paciente BuscarPaciente(string id)
        {
            Paciente pc = new Paciente();
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar("select * from Paciente where id like '" + id + "';");
            #region igualar pacientes
            pc.id = ds.Tables[0].Rows[0][0].ToString();
            pc.nombre= ds.Tables[0].Rows[0][1].ToString();
            pc.apellido= ds.Tables[0].Rows[0][2].ToString();
            pc.genero = ds.Tables[0].Rows[0][3].ToString();
            pc.fechaNacimiento = ds.Tables[0].Rows[0][4].ToString();
            pc.Domicilio = ds.Tables[0].Rows[0][5].ToString();
            pc.Seguro = ds.Tables[0].Rows[0][6].ToString();
            pc.telefono = ds.Tables[0].Rows[0][7].ToString();
            pc.estatura = ds.Tables[0].Rows[0][8].ToString();
            pc.sangre = ds.Tables[0].Rows[0][9].ToString();
            pc.peso = ds.Tables[0].Rows[0][10].ToString();
            pc.alergias = ds.Tables[0].Rows[0][11].ToString();
            pc.adicciones = ds.Tables[0].Rows[0][12].ToString();
            pc.enfermedadFamilia = ds.Tables[0].Rows[0][13].ToString();
            pc.enfermedadPequeno = ds.Tables[0].Rows[0][14].ToString();
            #endregion
            con.Desconectar();
            return pc;
        }

    }
}
