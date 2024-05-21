using Library.WebApi.BusinessLogic.Dtos.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Interfaces
{
    public interface ILibroServicio
    {
        Task<AddLibroResponse> AdicionarLibro(AddLibro request);
        Task<GetLibrosByParamResponse> BuscarLibros(GetLibrosByParam request);
    }
}
