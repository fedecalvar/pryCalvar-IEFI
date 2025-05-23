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
        public SqlConnection conexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        // "?" por que la funcion puede devolver un numero entero o null. En este caso el id del usuario
        public int? IniciarSesion(string usuario, string contrasena)
        {
            using (SqlConnection conn = conexion())
            {
                string query = "SELECT IdUsuario FROM Usuarios WHERE NombreUsuario = @usuario AND Contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return null;
            }
        }
    }
}
