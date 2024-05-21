using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.BusinessLogic.Interfaces;
using Library.WebApi.BusinessLogic.Servicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebApi.Api.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IAutorServicio _autorServicio;

        public AuthorsController(IAutorServicio autorServicio)
        {
            _autorServicio = autorServicio;
        }
        
        // GET api/<AutorController>/5        
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(typeof(GetAutorDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAutorDetails(int authorId)
        {
            var result = await _autorServicio.GetAutorDetails(new GetAutorDetailsRequest()
            {
                AutorId = authorId
            });
            return Ok(result);
        }

        // POST api/<AutorController>      
        
        [HttpPost("authors")]
        [ProducesResponseType(typeof(AddAutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarAutor([FromBody] AddAutorRequest request)
        {
            var result = await _autorServicio.AdicionarAutor(request);
            return Ok(result);
        }       
    }
}
