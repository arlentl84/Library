using Azure.Core;
using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebApi.Api.Controllers
{
    [Route("api/library/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsuarioServicio _usuarioServicio;


        public UsersController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }       

        // GET api/<ValuesController>/5
        [HttpGet]        
        [ProducesResponseType(typeof(GetUserListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGetPagedUserList([FromQuery] GetUserListRequest request)
        {
            var result = await _usuarioServicio.GetPagedUserList(request);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost]        
        [ProducesResponseType(typeof(AddUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AddUsuarioRequest request)
        {
            var result = await _usuarioServicio.AdicionarUsuario(request);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{userid}")]
        [ProducesResponseType(typeof(UpdateUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid userid, [FromBody] UpdateUsuarioRequest request)
        {
            var result = await _usuarioServicio.ActualizarUrlImage(new UpdateUsuario()
            {
                Id = userid,
                Url = request.Url
            });
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{userId}")]
        [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _usuarioServicio.DeleteUser(new DeleteUsuarioRequest() { Id = userId});
            return Ok(result);
        }

        [HttpDelete("{userId}/subscribe-to-author/{authorId}")]
        [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSuscripcion(Guid userId, int authorId)
        {
            var result = await _usuarioServicio.DeleteUser(new DeleteUsuarioRequest() { Id = userId });
            return Ok(result);
        }

        [HttpPut("{userId}/subscribe-to-author/{authorId}")]
        [ProducesResponseType(typeof(AddAuthorSuscripcionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUserSuscripcion(Guid userId, int authorId)
        {
            var result = await _usuarioServicio.AddUserSuscripcion(new AddAuthorSuscripcionRequest() { AuthorId = authorId, UserId = userId});
            return Ok(result);
        }
    }
}
