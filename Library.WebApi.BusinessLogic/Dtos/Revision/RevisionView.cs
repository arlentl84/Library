using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class RevisionView
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public Guid UsuarioId { get; set; }
        public int LibroId { get; set; }
        public string TituloLibro { get; set; }        
        public DateTime FechaCreacion { get; set; }
        public string? Opinion { get; set; }
        public int Calificacion { get; set; }      
        
    }
}
