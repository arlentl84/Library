using AutoMapper;
using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.BusinessLogic.Interfaces;
using Library.WebApi.DataAccess.Context;
using Library.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AutorServicio(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AddAutorResponse> AdicionarAutor(AddAutorRequest request)
        {
            AddAutorResponse response = null;

            var autor = await _context.Autores.FirstOrDefaultAsync(p => p.Nombre == request.Nombre);
            if (autor == null)
            {
                var entity = _mapper.Map<Autor>(request);
                var result = await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                response = new AddAutorResponse()
                {
                    Entidad = _mapper.Map<AutorDto>(result.Entity),
                    Estado = 200,
                    Mensaje = "Autor registrado satisfactoriamente."
                };
            }
            else
            {
                response = new AddAutorResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "Existe un autor con el mismo nombre."
                };
            }
            return response;
        }

        public async Task<GetAutorDetailsResponse> GetAutorDetails(GetAutorDetailsRequest request)
        {
            GetAutorDetailsResponse response = null;
            var query = await _context.Autores.Include(p => p.Suscritos).Include(p => p.Libros).FirstOrDefaultAsync(p => p.Id == request.AutorId);
            if (query == null)
            {
                response = new GetAutorDetailsResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "No existe un autor con ese id"
                };
            }
            else
            {
                response = new GetAutorDetailsResponse()
                {
                    Entidad = _mapper.Map<AutorView>(query),
                    Estado = 200,
                    Mensaje = "Success"
                };
            }
            return response;
        }

    }
}
