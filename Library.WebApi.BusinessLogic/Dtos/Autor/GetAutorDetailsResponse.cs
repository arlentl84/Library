using Library.WebApi.BusinessLogic.Dtos.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Autor
{
    public class GetAutorDetailsResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public AutorView Entidad { get; set; }
    }
}
