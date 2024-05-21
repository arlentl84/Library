using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Domain
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string UrlPerfil { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Suscripcion> Suscripciones { get; set; } = new List<Suscripcion>();
        public List<Revision> Revisiones { get; set; } = new List<Revision>();
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
