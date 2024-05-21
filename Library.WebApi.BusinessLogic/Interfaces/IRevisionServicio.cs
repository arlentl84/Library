using Library.WebApi.BusinessLogic.Dtos.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Interfaces
{
    public interface IRevisionServicio
    {
        Task<AddRevisionResponse> AddRevisionLibro(AddRevision request);
        Task<GetRevisionesByParamsResponse> GetRevisionesLibros(GetRevisionesByParams request);
    }
}
