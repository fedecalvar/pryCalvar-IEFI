using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Modelos
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
    }
}
