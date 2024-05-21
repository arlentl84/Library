using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class AddAuthorSuscripcionRequest
    {
        public Guid UserId { get; set; }
        public int AuthorId { get; set; }
    }
}
