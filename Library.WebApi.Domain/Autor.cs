using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Domain
{
    public class Autor
    {
        [Key] 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }        
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Suscripcion> Suscritos { get; set; } = new List<Suscripcion>();
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
