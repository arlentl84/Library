using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class LibroPorAutorDto
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string NombreAutor { get; set; }
        public string Editorial { get; set; }
        public float Calificacion { get; set; }
    }
}
