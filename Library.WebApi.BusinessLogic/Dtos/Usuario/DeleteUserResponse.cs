using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class DeleteUserResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public UsuarioDto Entidad { get; set; }
    }
}
