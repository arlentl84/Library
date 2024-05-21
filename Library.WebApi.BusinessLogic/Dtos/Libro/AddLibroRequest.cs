using Library.WebApi.BusinessLogic.Dtos.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class AddLibroRequest
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Editorial { get; set; }        

        [Required]
        public int CantidadPaginas { get; set; }

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        public string UrlDescarga { get; set; }

        [Required]
        public string ISBN { get; set; }
    }

    public class AddLibro
    {        
        public string Titulo { get; set; }
        
        public string Editorial { get; set; }
        
        public int AutorId { get; set; }

        public int CantidadPaginas { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string UrlDescarga { get; set; }

        public string ISBN { get; set; }
    }
}
