using Library.WebApi.BusinessLogic.Dtos.Revision;
using Library.WebApi.BusinessLogic.Dtos.Suscripcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string UrlPerfil { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<SuscripcionDto> Suscripciones { get; set; } = new List<SuscripcionDto>();
        public List<RevisionDto> Revisiones { get; set; } = new List<RevisionDto>();
    }
}
