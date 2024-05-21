using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Revision;
using Library.WebApi.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Library.WebApi.Api.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        readonly ILibroServicio _libroServicio;
        readonly IRevisionServicio _revisionServicio;

        public LibroController(ILibroServicio libroServicio, IRevisionServicio revisionServicio)        
        {
            this._libroServicio = libroServicio;
            this._revisionServicio = revisionServicio;
        }
        
        [HttpPost("authors/{authorId}/books")]
        [ProducesResponseType(typeof(AddLibroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarLibro([FromBody] AddLibroRequest request, int authorId)
        {
            var result = await _libroServicio.AdicionarLibro(new AddLibro()
            {
                AutorId = authorId,
                CantidadPaginas = request.CantidadPaginas,
                Editorial = request.Editorial,
                FechaPublicacion = request.FechaPublicacion,
                ISBN = request.ISBN,
                Titulo = request.Titulo,
                UrlDescarga = request.UrlDescarga
            });
            return Ok(result);
        }

        [HttpPost("books/{bookId}/reviews/from/users/{userId}")]
        [ProducesResponseType(typeof(AddRevisionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarRevision([FromBody] AddRevisionRequest request, Guid userId, int bookId)
        {
            var result = await _revisionServicio.AddRevisionLibro(new AddRevision()
            {
                Calificacion = request.Calificacion,
                LibroId = bookId,
                Opinion = request.Opinion,
                UsuarioId = userId
            });
            return Ok(result);
        }

        [HttpGet("books")]
        [ProducesResponseType(typeof(AddLibroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLibrosByParams([FromQuery] GetLibrosByParamRequest request, int authorId)
        {
            var result = await _libroServicio.BuscarLibros(new GetLibrosByParam()
            {
                After = string.IsNullOrEmpty(request.After) ? null : DateTime.Parse(request.After),
                AutorId = authorId,
                Before = string.IsNullOrEmpty(request.Before) ? null : DateTime.Parse(request.Before),                
                Editorial = request.EditorialName,
                Limit = request.Limit,
                Offset = request.Offset,
                Sort = request.Sort
            });
            return Ok(result);
        }

        [HttpGet("books/{bookId}/reviews")]
        [ProducesResponseType(typeof(GetRevisionesByParamsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRevisionesByParams([FromQuery] GetRevisionesByParamsRequest request, int bookId)
        {
            var result = await _revisionServicio.GetRevisionesLibros(new GetRevisionesByParams()
            {
                BookId = bookId,
                ReviewType = request.ReviewType,
                Limit = request.Limit,
                Offset = request.Offset,
                Sort = request.Sort
            });
            return Ok(result);
        }
    }
}
