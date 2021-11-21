using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cresta.Entidades
{
    public class Alumno
    {
        private string _ApellidoNombre;
        private string _Email;
        private string _dni;
        private DateTime _FechaNacimiento;
        private decimal _NotaPromedio;

        public string ApellidoNombre
        {
            get { return _ApellidoNombre; }
            set { _ApellidoNombre = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public decimal NotaPromedio
        {
            get { return _NotaPromedio; }
            set { _NotaPromedio = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }

        public int Edad { get => (DateTime.Today).Year - this.FechaNacimiento.Year; }

        public Alumno()
        {

        }

        public Alumno (string apellidoNombre, string email, string dni, int notaPromedio, DateTime fechaNacimiento)
        {
            this.ApellidoNombre = apellidoNombre;
            this.Email = email;
            this.dni = dni;
            this.NotaPromedio = notaPromedio;
            this.FechaNacimiento = fechaNacimiento;
        }
    }
}
