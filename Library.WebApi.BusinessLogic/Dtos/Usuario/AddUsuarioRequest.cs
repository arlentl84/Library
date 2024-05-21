using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class AddUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string UrlPerfil { get; set; }
    }
}
