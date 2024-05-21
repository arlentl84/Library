using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Revision
{
    public class GetRevisionesByParamsRequest
    {        
        public int? ReviewType { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 50;
        public bool? Sort { get; set; }
    }

    public class GetRevisionesByParams
    {
        public int BookId { get; set; }
        public int? ReviewType { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 50;
        public bool? Sort { get; set; }
    }
}
