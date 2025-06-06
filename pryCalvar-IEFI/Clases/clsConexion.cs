using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI
{
    internal class clsConexion
    {
        private string cadenaConexion = "Server=localhost;Database=BDDCalvar_IEFI;Trusted_Connection=True;";

        // SqlConnection establece la conexion con la bdd
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            conn.Open();
            return conn;
        }

    }
}
