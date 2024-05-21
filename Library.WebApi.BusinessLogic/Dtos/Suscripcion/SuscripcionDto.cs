using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Suscripcion
{
    public class SuscripcionDto
    {
        public int Id { get; set; }
        public AutorDto Autor { get; set; }
        public int AutorId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
