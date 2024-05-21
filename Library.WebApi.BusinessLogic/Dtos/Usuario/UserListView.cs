using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Usuario
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string UrlPerfil { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CantidadAutoresSuscrito { get; set; }
    }

    public class PagedUserViewList
    {
        public List<UserView> Usuarios { get; set; }
        public int TotalUsuarios { get; set; }
        public int TotalPaginas { get; set; }
        public int Pagina { get; set; }

    }
}
