using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class GetUserListRequest
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 50;
    }
}
