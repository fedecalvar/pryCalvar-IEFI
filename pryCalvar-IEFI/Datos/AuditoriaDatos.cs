using pryCalvar_IEFI.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Datos
{
    internal class AuditoriaDatos
    {
        // hay que recordar que al ser un metodo "estatico" se puede llamar sin crear la clase.
        public static List<Auditoria> ObtenerAuditoria()
        {
            List<Auditoria> lista = new List<Auditoria>();

            clsConexion conexionBD = new clsConexion();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string consulta = @"SELECT A.IdAuditoria, U.NombreUsuario, A.FechaRegistro, A.TiempoUso
                                FROM Auditoria A
                                INNER JOIN Usuarios U ON A.IdUsuario = U.IdUsuario";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Auditoria auditoria = new Auditoria
                    {
                        IdAuditoria = lector.GetInt32(0),
                        NombreUsuario = lector.GetString(1),
                        FechaRegistro = lector.GetDateTime(2),
                        TiempoUso = lector.GetTimeSpan(3)
                    };

                    lista.Add(auditoria);
                }

                lector.Close();
            }

            return lista;
        }

        public static void RegistrarAuditoria(int idUsuario, DateTime fechaIngreso, TimeSpan tiempoUso)
        {
            clsConexion conexionBD = new clsConexion();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string consulta = @"INSERT INTO Auditoria (IdUsuario, FechaRegistro, TiempoUso)
                            VALUES (@IdUsuario, @FechaRegistro, @TiempoUso)";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                comando.Parameters.AddWithValue("@FechaRegistro", fechaIngreso);
                comando.Parameters.AddWithValue("@TiempoUso", tiempoUso);

                comando.ExecuteNonQuery();
            }
        }

    }
}
