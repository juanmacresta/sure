using Cresta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cresta.Negocio
{
    public class AlumnoNegocio
    {
        private Cresta.Datos.AlumnoDatos _AlumnoDatos;

        public Cresta.Datos.AlumnoDatos AlumnoDatos
        {
            get { return _AlumnoDatos; }
            set { _AlumnoDatos = value; }
        }

        public AlumnoNegocio()
        {

        }

        public AlumnoNegocio(Cresta.Datos.AlumnoDatos x)
        {
            this.AlumnoDatos = x;
        }

        public static List<Cresta.Entidades.Alumno> RecuperarTodos()
        {
            Cresta.Datos.AlumnoDatos alu = new Cresta.Datos.AlumnoDatos();
            return alu.RecuperarTodos();
        }

        public static Cresta.Entidades.Alumno RecuperarUno(string dni)
        {
            Alumno alu = new Alumno();
            try
            {
                Cresta.Datos.AlumnoDatos a = new Cresta.Datos.AlumnoDatos();
                alu = a.RecuperarUno(dni);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No existe el alumno en cuestion");
            }
            return alu;
        }

        public static void Agregar(Cresta.Entidades.Alumno alu)
        {
            Cresta.Datos.AlumnoDatos a = new Cresta.Datos.AlumnoDatos();
            a.Agregar(alu);
        }
    }
}
