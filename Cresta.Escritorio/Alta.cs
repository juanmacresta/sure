using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cresta.Entidades;
using Cresta.Negocio;
using Cresta.Datos;

namespace Cresta.Escritorio
{
    public partial class Alta : Form
    {
        private Cresta.Entidades.Alumno _AlumnoActual;
        public Cresta.Entidades.Alumno AlumnoActual { get => this._AlumnoActual; set => this._AlumnoActual = value; }
        public Alta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Alumno alu = new Alumno();
            AlumnoActual = alu;
            this.AlumnoActual.ApellidoNombre = this.txtApNom.Text;
            this.AlumnoActual.dni = this.txtDni.Text;
            this.AlumnoActual.Email = this.txtEmail.Text;
            this.AlumnoActual.NotaPromedio = decimal.Parse(this.txtNota.Text);
            this.AlumnoActual.FechaNacimiento = this.dateFecha.Value;
            if (this.Validar(this.txtEmail.Text))
            {

                Cresta.Negocio.AlumnoNegocio.Agregar(AlumnoActual);
                this.Notificar("Alumno agregado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            this.Close();
        }

        public bool Validar(string em)
        {
            
            bool resp = false;
            string rta;
            if (!("".Equals(txtApNom.Text)))
            {
                if (!("".Equals(decimal.Parse(txtNota.Text))))
                {
                    if (!("".Equals(txtDni.Text)))
                    {
                        if (Cresta.Negocio.Validaciones.EsMailValido(em))
                        {
                            resp = true;

                        }
                        else { { rta = "El Email no es valido"; } this.Notificar(rta, MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                    }
                    else { { rta = "DNI no puede ser vacio"; } this.Notificar(rta, MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                }
                else { { rta = "Nota Promedio no puede estar vacio"; } this.Notificar(rta, MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            }
            else { { rta = "Nombre no puede estar vacio"; } this.Notificar(rta, MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            return resp;
        }
        public void Notificar(String titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
