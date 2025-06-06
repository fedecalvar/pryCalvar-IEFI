using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Modelos
{
    internal class Auditoria
    {
        public int IdAuditoria { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public TimeSpan TiempoUso { get; set; }
    }
}
