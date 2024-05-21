using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Revision;
using Library.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorDto Autor { get; set; }
        public int AutorId { get; set; }
        public string Editorial { get; set; }
        public int CantidadPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string UrlDescarga { get; set; }
        public string ISBN { get; set; }
        public float Calificacion { get; set; }
        public List<RevisionDto> Revisiones { get; set; } = new List<RevisionDto>();
    }
}
