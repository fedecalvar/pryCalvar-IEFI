using MaterialDesignColors;
using pryCalvar_IEFI.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Datos
{
    internal class UsuarioDatos
    {

        // Al poner "Usuario" me va a permitir recibir el Objeto tipo Usuario 
        // si el nombreUsuario y contrasena estan bien
        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = "SELECT IdUsuario, NombreUsuario, TipoUsuario FROM Usuarios WHERE NombreUsuario " +
                    "= @usuario AND Contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32(0),
                            NombreUsuario = reader.GetString(1),
                            TipoUsuario = reader.GetString(2)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        // recibe un objeto Usuario como parametro y va a devolver el usuario
        // con todos los datos menos el id. El id lo genera SQL y si algo falla devuelve null
        public static Usuario RegistrarUsuario(Usuario nuevoUsuario)
        {
            using (SqlConnection conexion = new clsConexion().ObtenerConexion())
            {
                string consulta = "INSERT INTO Usuarios (NombreUsuario, Contrasena, TipoUsuario, NombreCompleto, Email, Telefono) " +
                                  "OUTPUT INSERTED.IdUsuario " +
                                  "VALUES (@NombreUsuario, @Contrasena, @TipoUsuario, @NombreCompleto, @Email, @Telefono)";
                // Output inserted devuelve el idusuario que genera sqlserver cuando hacemos el insert


                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@NombreUsuario", nuevoUsuario.NombreUsuario);
                comando.Parameters.AddWithValue("@Contrasena", nuevoUsuario.Contrasena);
                comando.Parameters.AddWithValue("@TipoUsuario", "Usuario");
                comando.Parameters.AddWithValue("@NombreCompleto", nuevoUsuario.NombreCompleto);
                comando.Parameters.AddWithValue("@Email", nuevoUsuario.Email);
                comando.Parameters.AddWithValue("@Telefono", nuevoUsuario.Telefono);

                int idInsertado = (int)comando.ExecuteScalar();

                // si el id es valido, se le asigna a nuevoUsuario
                // si hay un error, como mencionamos antes devuelve null
                if (idInsertado > 0)
                {
                    nuevoUsuario.Id = idInsertado;
                    nuevoUsuario.TipoUsuario = "Usuario";
                    return nuevoUsuario;
                }

                return null;
            }
        }

        public static bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = "DELETE FROM Usuarios WHERE IdUsuario = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idUsuario);

                //conn.Open();
                int filas = cmd.ExecuteNonQuery();

                // Si filas > 0, significa que elimino a un usuario.
                // devuelve true y si no encontro nada, no se elimina nada y devuelve false
                return filas > 0;
            }
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = @"UPDATE Usuarios
                         SET NombreCompleto = @NombreCompleto,
                             Email = @Email,
                             Telefono = @Telefono,
                             TipoUsuario = @TipoUsuario
                         WHERE IdUsuario = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public static bool ExisteNombreUsuario(string nombreUsuario)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                // La consulta cuenta cuántos registros hay en la tabla Usuarios
                // donde el campo Email sea igual al valor recibido.
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @nombre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);

                // ExecuteScalar() ejecuta la consulta y devuelve un único valor escalar
                // que en este caso es el resultado del COUNT(*), un número entero.
                int cantidad = (int)cmd.ExecuteScalar();

                // si la cantidad es mayor a 0 significa que ya existe un usuario registrado con el nombre
                return cantidad > 0;
            }
        }

        public static bool ExisteEmail(string email)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                // idem ExisteNombreUsuario
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @correo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", email);

                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }

        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) // mientras haya registros por leer, lee fila por fila
                {
                    // crea un objeto fila por fila
                    Usuario usuario = new Usuario
                    {
                        // reader.GetOrdinal() <-- Obtiene el indice de la columna y despues lee el valor
                        Id = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                        NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario")),
                        Contrasena = reader.GetString(reader.GetOrdinal("Contrasena")),
                        TipoUsuario = reader.GetString(reader.GetOrdinal("TipoUsuario")),
                        NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                    };

                    lista.Add(usuario);
                }
            }
            // devuelve la lista completa
            return lista;
        }
    }
}
