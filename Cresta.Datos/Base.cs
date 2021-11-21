using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Cresta.Datos
{
    public class Base
    {
        private SqlConnection _XxxConnection;
        const string NetGenerica = "ConnStringLocal";

        public SqlConnection XxxConnection { get => _XxxConnection; set => _XxxConnection = value; }

        protected void OpenConnection()
        {
            String conn = ConfigurationManager.ConnectionStrings[NetGenerica].ConnectionString;
            //throw new Exception("Metodo no implementado");
            XxxConnection = new SqlConnection(conn);
            XxxConnection.Open();
        }

        protected void CloseConnection()

        {
            XxxConnection.Close();
            XxxConnection = null;
        }
    }
}
