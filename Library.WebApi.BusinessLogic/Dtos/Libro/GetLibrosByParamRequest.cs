using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class GetLibrosByParamRequest
    {        
        public string? EditorialName { get; set; }
        public string? Before { get; set; }
        public string? After { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 50;
        public bool? Sort { get; set; }
    }
    public class GetLibrosByParam
    {
        public int? AutorId { get; set; }
        public string? Editorial { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 50;
        public bool? Sort { get; set; }
    }
}
