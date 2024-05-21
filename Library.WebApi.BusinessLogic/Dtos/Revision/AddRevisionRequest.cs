using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class AddRevisionRequest
    {
        public string Opinion { get; set; }
        public int Calificacion { get; set; }        
    }

    public class AddRevision
    {
        public string Opinion { get; set; }
        public int Calificacion { get; set; }
        public Guid UsuarioId { get; set; }
        public int LibroId { get; set; }
    }
}
