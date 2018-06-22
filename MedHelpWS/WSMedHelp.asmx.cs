using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Windows;
using System.IO;

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
        [WebMethod]
        public DataSet BuscarPaciente(string condi,string id)
        { 
            DataSet ds = new DataSet();
            con.Conectar();
            ds= con.seleccionar("select * from Paciente where "+condi+" like '%"+id+"%';");
            con.Desconectar();
            return ds;
        }
        [WebMethod]
        public void AgregarDiag(Diagnostico diag)
        {
            con.Conectar();
            con.insomod(@"insert into Diagnostico 
                          values ('"+diag.id+ "','"+diag.nombres+ "','"+diag.apellidos+ "','"+diag.genero+ "','"+diag.Nseguro+"'," +
                          "'"+diag.sintomasP+ "','"+diag.observaciones+"');");
            con.Desconectar();
        }
        [WebMethod]
        public void EliminarMedicamentos(Medicamentos Med)
        {
            con.Conectar();
            con.insomod(@"Delete from DetellesMed where Codigo=" + Med.Codigo + "");
            con.insomod(@"Delete from Medicamentos where Codigo=" + Med.Codigo + "");
            con.Desconectar();
        }
        [WebMethod]
        public void AgregarPersonal(Personal Per)
        {
                con.Conectar();
                con.insomod(@"insert into Personal(ID,Nombre,Apellido,NIdentidad,Genero,Edad,FechaIng,FechaNac,Email,EstadoCiv,Direccion,NCasa,Telefono,Descripcion,TipoAcc,Especialidad,Funcion,HorasLab,Estado) values (" + Per.ID + ",'" + Per.Nombre + "','" + Per.Apellido + "','" + Per.Identidad + "'," +
                    "'" + Per.Genero + "'," + Per.Edad + ",'" + Per.FechadeIngreso + "','" + Per.FechadeNac + "','" + Per.Email + "','" + Per.EstadoCivil + "','" + Per.Direccion + "'," +
                    "'" + Per.NumCasa + "','" + Per.Telefono + "','" + Per.Descripcion + "','" + Per.TipoAcceso + "','" + Per.Especialidad + "','" + Per.Funcion + "','" + Per.Horaslaborales + "','" + Per.Estado + "')");
                con.Desconectar();
        }
        //Proba ahora elias
        [WebMethod]
        public DataSet BuscarDoc(string nombre)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds=con.seleccionar("select Nombre, Apellido, ID from Personal where Nombre like '%"+nombre+"%' ");
            con.Desconectar();
            return ds;
        }

        [WebMethod]
        public DataSet BuscarPersonal(int id)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar("select NIdentidad,Nombre,Apellido,Edad,Genero,Estado,Foto from Personal where ID like '%" + id + "%' ");
            con.Desconectar();
            return ds;
        }
        [WebMethod]
        public DataSet BuscarPer_codigo(string codigo)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar("select NIdentidad,Nombre,Apellido,Edad,Genero,Estado,Foto from Personal where ID='" + codigo + "'").Tables[0].DataSet;
            con.Desconectar();
            return ds;
        }
        //hola
        [WebMethod]
        public DataSet BuscarPer_nombre(string nombre)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar("select NIdentidad,Nombre,Apellido,Edad,Genero,Estado,Foto from Personal where Nombre='" + nombre + "' ").Tables[0].DataSet;
            con.Desconectar();
            return ds;
        }
        [WebMethod]
        public void AddCitas(Citas c)
        {
            con.Conectar();
            con.insomod(@"INSERT INTO Citas(id, Fecha, Hora_Inicio,Hora_Final,  Descripcion, NumColegiado, NomMedico,Estado_cita)
                        values('" + c.id + "', '" + c.Fecha + "', '" + c.Hora_Inicio + "','" + c.Hora_Final + "','" + c.Descripcion + "', '" + c.NumColegiado + "', '" + c.NomMedico + "','"+c.Estado_cita+"')");
            con.Desconectar();
        }
        [WebMethod]
        public DataSet Buscar_Cita(string where, string id)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds=con.seleccionar(@"select Citas.Fecha,Citas.Hora_Inicio,Citas.Hora_Final,Paciente.nombres +' '+ Paciente.apellidos as Paciente,Paciente.id,Citas.Descripcion,Citas.NomMedico as Medico,Citas.Estado_cita from Citas
                             inner join Paciente
                             on Paciente.id = Citas.id
                             where " + where+" like '%"+id+"%' ");
            con.Desconectar();
            return ds;
        }

        [WebMethod]
        public DataSet MedicamentoFac(string codigo)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar(@"select Codigo,Cantidad from Medicacion where id='"+codigo+"'").Tables[0].DataSet;
            con.Desconectar();
            return ds;
        }
        //Agregar Medicacion 
        [WebMethod]
        public void AgregarMedicacion(string id,string codigo,string dosis,double cant)
        {
            con.Conectar();
            con.insomod(@"insert into Medicacion
                          values ('"+id+ "','" + codigo + "','" + dosis + "'," + cant + ")");
            con.Desconectar();
        }

        //Agregar 
        [WebMethod]
        public DataSet BuscarMedicamento(string where,string cod)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds = con.seleccionar(@"select Medicamentos.Codigo,Medicamentos.Nombre,DetellesMed.Cantidad,
                                 DetellesMed.TipoMed, DetellesMed.CostoUni from Medicamentos
                                 inner join DetellesMed
                                 on DetellesMed.Codigo = Medicamentos.Codigo
                                 where Medicamentos."+where+" like '%"+cod+"%' ").Tables[0].DataSet;
            con.Desconectar();
            return ds;
        }
        //Actualizar Cita
        [WebMethod]
        public void UpdateCita(string id,string estado)
        {
            con.Conectar();
            con.insomod(@"update Citas
                        set Estado_Cita= '"+estado+"' where id='"+id+"' ");
            con.Desconectar();
        }

        [WebMethod]
        public void AgregarFac(string RTN, string NombrePac, string IDPac, string Fecha)
        {
            con.Conectar();
            con.insomod(@"insert into Factura1(RTN,NombrePer,NumeroID,Fecha) values('" + RTN + "','" + NombrePac + "','" + IDPac + "','" + Fecha + "')");
            con.Desconectar();
        }

        [WebMethod]
        public void AgregarDetallesFac(int NumFac, string Codigo, string Medic, int Cant, double PrecioUni, double Total)
        {
            con.Conectar();
            con.insomod(@"insert into DetallesFac
                          values (" + NumFac + ",'" + Codigo + "','" + Medic + "'," + Cant + "," + PrecioUni + "," + Total + ")");
            con.Desconectar();
        }

        [WebMethod]
        public DataSet BuscarMedCod(string codigo)
        {
            DataSet ds = new DataSet();
            con.Conectar();
            ds=con.seleccionar(@"select Codigo, Cantidad from Medicacion where id='"+codigo+"'").Tables[0].DataSet;
            con.Desconectar();
            return ds;
        }
    }
}
