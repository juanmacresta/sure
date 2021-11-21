using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cresta.Entidades;
using Cresta.Negocio;
using Cresta.Datos;

namespace Cresta.UI.Web
{
    public partial class RecuperarUno : System.Web.UI.Page
    {
        public Cresta.Entidades.Alumno Entity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                Cresta.Negocio.AlumnoNegocio alu = new Negocio.AlumnoNegocio();
                if (!txtDni.Text.Equals(""))
                {
                    if (Negocio.AlumnoNegocio.RecuperarUno(txtDni.Text) != null)
                    {
                        this.Entity = Negocio.AlumnoNegocio.RecuperarUno(txtDni.Text);
                        lblNyA.Text = "Nombre y Apellido: " + this.Entity.ApellidoNombre;
                        lblEmail.Text = "Email: " + this.Entity.Email;
                        lblFN.Text = "Fecha de Nacimiento: " + this.Entity.FechaNacimiento.ToString("dd/MM/yyyy");
                        lblNP.Text = "Nota Promedio: " + this.Entity.NotaPromedio.ToString();
                        lblEdad.Text = "Edad: " + this.Entity.Edad.ToString();
                    }
                    else { lblNotificar.Text = "No existe el alumno con ese dni"; }

                }
                else { lblNotificar.Text = "No se puede ingresar un dni vacio"; }
            }
            catch (NullReferenceException Ex)
            {
                NullReferenceException exceptionManejada = new NullReferenceException("Error al crear un alumnos", Ex);
                throw exceptionManejada;
            }
        }
    }
}