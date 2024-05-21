using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class UpdateUsuarioRequest
    {        
        public string Url { get; set; }
    }

    public class UpdateUsuario
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}
