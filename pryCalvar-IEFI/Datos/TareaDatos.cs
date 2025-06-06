using pryCalvar_IEFI.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Datos
{
    public class TareaDatos
    {
        // static por que no se necesita crear ningun objeto para llamarlo.
        // de tarea solamente tomamos los datos, es decir el molde.
        public static void AgregarTarea(Tarea tarea)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = @"INSERT INTO Tareas 
                (Titulo, Descripcion, FechaVencimiento, Prioridad, Estado, IdUsuario)
                VALUES (@titulo, @desc, @fecha, @prio, @estado, @idUsuario)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@titulo", tarea.Titulo);
                cmd.Parameters.AddWithValue("@desc", tarea.Descripcion);
                cmd.Parameters.AddWithValue("@fecha", tarea.FechaVencimiento);
                cmd.Parameters.AddWithValue("@prio", tarea.Prioridad);
                cmd.Parameters.AddWithValue("@estado", tarea.Estado);
                cmd.Parameters.AddWithValue("@idUsuario", tarea.IdUsuario);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Tarea> ObtenerTareasUsuario(int idUsuario)
        {
            List<Tarea> tareas = new List<Tarea>();

            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = "SELECT * FROM Tareas WHERE IdUsuario = @idUsuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea
                        {
                            IdTarea = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            FechaVencimiento = reader.GetDateTime(3),
                            Prioridad = reader.GetString(4),
                            Estado = reader.GetString(5),
                            IdUsuario = reader.GetInt32(6)
                        };
                        tareas.Add(tarea);
                    }
                }
            }

            return tareas;
        }

        public static void EliminarTarea(int idTarea)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = "DELETE FROM Tareas WHERE IdTarea = @idTarea";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTarea", idTarea);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ModificarTarea(Tarea tarea)
        {
            using (SqlConnection conn = new clsConexion().ObtenerConexion())
            {
                string query = @"UPDATE Tareas 
                         SET Titulo = @titulo, Descripcion = @descripcion, 
                             FechaVencimiento = @fecha, Prioridad = @prioridad, 
                             Estado = @estado 
                         WHERE IdTarea = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@titulo", tarea.Titulo);
                cmd.Parameters.AddWithValue("@descripcion", tarea.Descripcion);
                cmd.Parameters.AddWithValue("@fecha", tarea.FechaVencimiento);
                cmd.Parameters.AddWithValue("@prioridad", tarea.Prioridad);
                cmd.Parameters.AddWithValue("@estado", tarea.Estado);
                cmd.Parameters.AddWithValue("@id", tarea.IdTarea);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
