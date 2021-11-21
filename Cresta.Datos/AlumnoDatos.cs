using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cresta.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Cresta.Datos
{
    public class AlumnoDatos : Base
    {
        public List<Cresta.Entidades.Alumno> RecuperarTodos()
        {
            List<Cresta.Entidades.Alumno> alumnos = new List<Cresta.Entidades.Alumno>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("select * from Alumnos", XxxConnection);
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();
                while (drAlumnos.Read())
                {
                    Alumno alu = new Alumno();
                    alu.ApellidoNombre = (string)drAlumnos["ApellidoNombre"];
                    alu.Email = (string)drAlumnos["Email"];
                    alu.dni = (string)drAlumnos["Dni"];
                    alu.FechaNacimiento = (DateTime)drAlumnos["FechaNacimiento"];
                    alu.NotaPromedio = (decimal)drAlumnos["NotaPromedio"];
                    alumnos.Add(alu);
                }
                drAlumnos.Close();
                return alumnos;
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Agregar(Alumno alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Alumnos(ApellidoNombre, Dni, Email, FechaNacimiento, NotaPromedio) " +
                    "VALUES(@ApellidoNombre,@Dni,@Email,@FechaNacimiento,@NotaPromedio) ", XxxConnection);

                cmdSave.Parameters.Add("ApellidoNombre", SqlDbType.VarChar, 50).Value = alumno.ApellidoNombre;
                cmdSave.Parameters.Add("Email", SqlDbType.VarChar, 50).Value = alumno.Email;
                cmdSave.Parameters.Add("Dni", SqlDbType.VarChar, 20).Value = alumno.dni;
                cmdSave.Parameters.Add("FechaNacimiento", SqlDbType.DateTime, 8).Value = alumno.FechaNacimiento;
                cmdSave.Parameters.Add("NotaPromedio", SqlDbType.Decimal, 5).Value = alumno.NotaPromedio;
                cmdSave.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar un alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }




        }

        public Alumno RecuperarUno(string dni)
        {
            try
            {
                this.OpenConnection();
                List<Alumno> alumnos = this.RecuperarTodos();
                var miAlumno = (from Alumno u in alumnos where u.dni == dni select u).First();
                return miAlumno;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", ex);
                throw ExcepcionManejada;
            }
        }


    }
}
