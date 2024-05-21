using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.BusinessLogic.Interfaces;
using Library.WebApi.BusinessLogic.Util;
using Library.WebApi.DataAccess.Context;
using Library.WebApi.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly EmailMessageSetting _messageSettings;

        public LibroServicio(ApplicationDbContext context, IMapper mapper, IConfiguration configuration, IEmailSender emailSender, IOptions<EmailMessageSetting> messageSettings)
        {
            _context = context;            
            _mapper = mapper;
            _configuration = configuration;
            _emailSender = emailSender;
            _messageSettings = messageSettings.Value;
        }

        public async Task<GetLibrosByParamResponse> BuscarLibros(GetLibrosByParam request)
        {
           // var query = _context.Libros.Include(p => p.Autor).Where(p => (request.AutorId.HasValue ? p.AutorId == request.AutorId.Value : true)).ProjectTo<LibroPorAutorDto>(_mapper.ConfigurationProvider);
            var query = _context.Libros.Include(p => p.Autor).Where(p => (request.AutorId.HasValue ? p.AutorId == request.AutorId.Value : true) && (string.IsNullOrEmpty(request.Editorial) ? true : p.Editorial == request.Editorial) && (request.Before.HasValue ? p.FechaPublicacion.Date.CompareTo(request.Before.Value.Date) < 0 : true) && (request.After.HasValue ? p.FechaPublicacion.Date.CompareTo(request.After.Value.Date) > 0 : true)).ProjectTo<LibroPorAutorDto>(_mapper.ConfigurationProvider);
            query = query.Skip(request.Offset).Take(request.Limit);
            
            if (request.Sort.HasValue)
            {
                if (request.Sort.Value == true)
                    query = query.OrderBy(p => p.Calificacion);
                else query = query.OrderByDescending(p => p.Calificacion);
            }

            var result = await query.ToListAsync();

            return new GetLibrosByParamResponse()
            {
                Entidad = result,
                Estado = 200,
                Mensaje = "Success"
            };
        }        

        public async Task<AddLibroResponse> AdicionarLibro(AddLibro request)
        {
            AddLibroResponse response = null;
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(p => p.Id == request.AutorId);
                if (autor != null)
                {
                    var libro = await _context.Libros.FirstOrDefaultAsync(p => p.ISBN == request.ISBN);
                    if (libro == null)
                    {
                        var entity = _mapper.Map<Libro>(request);
                        var result = await _context.AddAsync(entity);
                        await _context.SaveChangesAsync();

                        var userEmails = await _context.Suscripciones.Include(p => p.Usuario).Where(p => p.AutorId == request.AutorId).Select(p => p.Usuario.Email).ToListAsync();
                        //implementacion convencional, esto deberia llevar un background service
                                              
                        userEmails.ForEach(email =>
                        {
                            _emailSender.SendEmailAsync(_messageSettings.Remitente, email, _messageSettings.Asunto, "Aasasas");
                        });

                        response = new AddLibroResponse()
                        {
                            Entidad = _mapper.Map<LibroDto>(result.Entity),
                            Estado = 200,
                            Mensaje = "Libro registrado satisfactoriamente."
                        };
                    }
                    else
                    {
                        response = new AddLibroResponse()
                        {
                            Entidad = null,
                            Estado = 200,
                            Mensaje = "Error. Existe un libro con igual ISBN."
                        };
                    }
                }
                else
                {
                    response = new AddLibroResponse()
                    {
                        Entidad = null,
                        Estado = 400,
                        Mensaje = "Error. No se pudo obtener el autor del libro."
                    };
                }
            }
            catch(Exception exc)
            {
                response = new AddLibroResponse()
                {
                    Entidad = null,
                    Estado = 500,
                    Mensaje = "Error 500."
                };
            }
            
            return response;
        }



    }
}
