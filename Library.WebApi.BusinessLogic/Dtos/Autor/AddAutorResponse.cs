using Library.WebApi.BusinessLogic.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Autor
{
    public class AddAutorResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public AutorDto Entidad { get; set; }
    }
}
