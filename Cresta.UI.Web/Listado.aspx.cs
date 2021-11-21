using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cresta.Negocio;

namespace Cresta.UI.Web
{
    public partial class Listado : System.Web.UI.Page
    {

        private AlumnoNegocio _AlumnoN;

        public AlumnoNegocio AlumnoN
        {
            get
            {
                if (_AlumnoN == null) { _AlumnoN = new AlumnoNegocio(); }
                return _AlumnoN;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }
        private void LoadGrid()
        {
            this.gridView.DataSource = Cresta.Negocio.AlumnoNegocio.RecuperarTodos();
            this.gridView.DataBind();
        }
    }
}