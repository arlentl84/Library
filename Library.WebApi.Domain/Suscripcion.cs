using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Domain
{
    public class Suscripcion
    {
        [Key]
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public int AutorId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
