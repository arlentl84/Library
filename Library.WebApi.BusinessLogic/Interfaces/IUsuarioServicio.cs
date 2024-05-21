using Library.WebApi.BusinessLogic.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<AddUsuarioResponse> AdicionarUsuario(AddUsuarioRequest request);
        Task<UpdateUsuarioResponse> ActualizarUrlImage(UpdateUsuario request);
        Task<DeleteUserResponse> DeleteUser(DeleteUsuarioRequest request);
        Task<AddAuthorSuscripcionResponse> AddUserSuscripcion(AddAuthorSuscripcionRequest request);
        Task<GetUserListResponse> GetPagedUserList(GetUserListRequest request);
    }
}
