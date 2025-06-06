using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryCalvar_IEFI.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; } 
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
