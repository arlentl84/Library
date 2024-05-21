using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class RevisionDto
    {
        public int Id { get; set; }
        public UsuarioDto Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Opinion { get; set; }
        public int Calificacion { get; set; }
        public LibroDto Libro { get; set; }
        public int LibroId { get; set; }
    }
}
