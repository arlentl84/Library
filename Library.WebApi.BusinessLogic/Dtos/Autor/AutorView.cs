using Library.WebApi.BusinessLogic.Dtos.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Autor
{
    public class AutorView
    {
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int CantidadUsuarios { get; set; }
        public List<LibroView> Libros { get; set; }
    }
}
