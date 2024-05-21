using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure;
using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Revision;
using Library.WebApi.BusinessLogic.Interfaces;
using Library.WebApi.DataAccess.Context;
using Library.WebApi.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Servicios
{
    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RevisionServicio(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AddRevisionResponse> AddRevisionLibro(AddRevision request)
        {
            AddRevisionResponse response = null;
            try
            {                
                var existLibro = _context.Libros.Any(p => p.Id == request.LibroId);
                if (existLibro)
                {
                    var existUsuario = _context.Usuarios.Any(p => p.Id == request.UsuarioId);
                    if (existUsuario)
                    {
                        var nuevaRevision = new Revision()
                        {
                            Calificacion = request.Calificacion,
                            FechaCreacion = DateTime.Now,
                            LibroId = request.LibroId,
                            UsuarioId = request.UsuarioId,
                        };
                        var result = await _context.AddAsync(nuevaRevision);
                        await _context.SaveChangesAsync();

                        var libro = _context.Libros.FirstOrDefault(p => p.Id == request.LibroId);
                        if (libro != null)
                        {
                            var revisionesQuery = _context.Revisiones.Where(p => p.LibroId == request.LibroId);
                            var sumRevisiones = revisionesQuery.Sum(p => p.Calificacion) + request.Calificacion;
                            var cantRevisiones = revisionesQuery.Count() + 1;
                            float promedioCalificacion = sumRevisiones / cantRevisiones;

                            libro.Calificacion = promedioCalificacion;
                            
                            bool saved = false;
                            while (!saved)
                            {
                                try
                                {
                                    _context.Update(libro);
                                    await _context.SaveChangesAsync();
                                    saved = true;
                                }
                                catch (DbUpdateException ex)
                                {
                                    if (ex is DbUpdateConcurrencyException)
                                        await ManageConcurrency(libro, nuevaRevision.Calificacion, ex.Entries.Select(e => e).FirstOrDefault());
                                    else
                                    {
                                        var number = (ex.GetBaseException() as SqlException)?.Number;
                                        //enviar numero de excepcion a los logs
                                        response = new AddRevisionResponse()
                                        {
                                            Entidad = null,
                                            Estado = 400,
                                            Mensaje = "Error al actualizar el libro."
                                        };                                       
                                    }
                                }
                            }

                            response = new AddRevisionResponse()
                            {
                                Entidad = _mapper.Map<RevisionDto>(result.Entity),
                                Estado = 200,
                                Mensaje = "Success"
                            };
                        }
                        else
                        {
                            response = new AddRevisionResponse()
                            {
                                Entidad = null,
                                Estado = 400,
                                Mensaje = "Error al obtener el libro."
                            };
                        }
                    }
                    else
                    {
                        response = new AddRevisionResponse()
                        {
                            Entidad = null,
                            Estado = 400,
                            Mensaje = "Error al obtener el usuario."
                        };
                    }

                }
                else
                {
                    response = new AddRevisionResponse()
                    {
                        Entidad = null,
                        Estado = 400,
                        Mensaje = "Error al obtener el libro."
                    };
                }
            }
            catch(Exception exc)
            {
                response = new AddRevisionResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "Error al obtener el libro."
                };
            }        


            return response;
        }

        public async Task<GetRevisionesByParamsResponse> GetRevisionesLibros(GetRevisionesByParams request)
        {
            GetRevisionesByParamsResponse response = null;
            try
            {
                var query = _context.Revisiones.Include(p => p.Libro).Include(p => p.Usuario).Where(p => p.LibroId == request.BookId && (request.ReviewType.HasValue ? p.Calificacion == request.ReviewType.Value : true)).ProjectTo<RevisionView>(_mapper.ConfigurationProvider);
                query = query.Skip(request.Offset).Take(request.Limit);

                if (request.Sort.HasValue)
                {
                    if (request.Sort.Value == true)
                        query = query.OrderBy(p => p.FechaCreacion);
                    else query = query.OrderByDescending(p => p.FechaCreacion);
                }

                var result = await query.ToListAsync();

                response = new GetRevisionesByParamsResponse()
                {
                    Entidad = result,
                    Estado = 200,
                    Mensaje = "Success"
                };
            }            
            catch(Exception exc)
            {
                response = new GetRevisionesByParamsResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "Error no identificado"
                };
            }
            return response;
        }
              

        private async Task ManageConcurrency(Libro libro, int calificacion, object entry)
        {
            var entity = (EntityEntry)entry;
            var databaseLibro = await _context.Libros.Include(p => p.Revisiones).Where(b => b.Id == libro.Id).FirstOrDefaultAsync();
            if(databaseLibro != null)
            {
                var total = databaseLibro.Revisiones.Count() + 1;
                var sumaRevisiones = databaseLibro.Revisiones.Sum(p => p.Calificacion) + calificacion;
                float promedioCalificacion = sumaRevisiones / total;
                entity.OriginalValues.SetValues(databaseLibro);
            }            
        }


    }
}
