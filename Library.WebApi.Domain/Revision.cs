using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Domain
{    
    public class Revision
    {
        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Opinion { get; set; }
        public int Calificacion { get; set; }
        public Libro Libro { get; set; }
        public int LibroId { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
