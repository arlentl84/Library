using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Suscripcion;
using Library.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Autor
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string AuthorUrl { get; set; }
        public List<LibroDto> Libros { get; set; } = new List<LibroDto>();
        public List<SuscripcionDto> Suscritos { get; set; } = new List<SuscripcionDto>();
    }    
}
