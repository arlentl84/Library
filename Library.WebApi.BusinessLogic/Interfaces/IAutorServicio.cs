using Library.WebApi.BusinessLogic.Dtos.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Interfaces
{
    public interface IAutorServicio
    {
        Task<AddAutorResponse> AdicionarAutor(AddAutorRequest request);
        Task<GetAutorDetailsResponse> GetAutorDetails(GetAutorDetailsRequest request);
    }
}
