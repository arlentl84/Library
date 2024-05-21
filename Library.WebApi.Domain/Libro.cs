using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.WebApi.Domain
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public int AutorId { get; set; }
        public string Editorial { get; set; }
        public int CantidadPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string UrlDescarga { get; set; }
        public string ISBN { get; set; }
        public float Calificacion { get; set; } = 0;
        public List<Revision> Revisiones { get; set; } = new List<Revision>();
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
