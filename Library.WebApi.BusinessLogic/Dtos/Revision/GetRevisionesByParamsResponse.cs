using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class GetRevisionesByParamsResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public List<RevisionView> Entidad { get; set; }
    }
}
