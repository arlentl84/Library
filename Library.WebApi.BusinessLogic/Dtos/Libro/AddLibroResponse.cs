using Library.WebApi.BusinessLogic.Dtos.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class AddLibroResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public LibroDto Entidad { get; set; }
    }
}
