using Library.WebApi.BusinessLogic.Dtos.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class AddRevisionResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public RevisionDto Entidad { get; set; }
    }
}
