using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UsuarioServicio(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AddUsuarioResponse> AdicionarUsuario(AddUsuarioRequest request)
        {
            AddUsuarioResponse addUsuarioResponse = null;
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(p => p.Email == request.Email);
                if (user == null)
                {
                    var entity = _mapper.Map<Usuario>(request);
                    entity.FechaRegistro = DateTime.UtcNow;
                    var result = await _context.AddAsync(entity);
                    await _context.SaveChangesAsync();

                    addUsuarioResponse = new AddUsuarioResponse()
                    {
                        Entidad = _mapper.Map<UsuarioDto>(result.Entity),
                        Estado = 200,
                        Mensaje = "Usuario registrado satisfactoriamente."
                    };
                }
                else
                {
                    addUsuarioResponse = new AddUsuarioResponse()
                    {
                        Entidad = null,
                        Estado = 400,
                        Mensaje = "Existe un usuario con el mismo correo."
                    };
                }
            }
            catch(Exception ex)
            {
                addUsuarioResponse = new AddUsuarioResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "Ha ocurrido un error inesperado"
                };
            }            
            return addUsuarioResponse;
        }

        public async Task<UpdateUsuarioResponse> ActualizarUrlImage(UpdateUsuario request)
        {
            UpdateUsuarioResponse updateUsuarioResponse = null;
            var user = await _context.Usuarios.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (user != null)
            {
                user.UrlPerfil = request.Url;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                updateUsuarioResponse = new UpdateUsuarioResponse()
                {
                    Entidad = null,
                    Estado = 200,
                    Mensaje = "Usuario actualizado satisfactoriamente."
                };
            }
            else
            {
                updateUsuarioResponse = new UpdateUsuarioResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "No existe un usuario registrado con ese id."
                };
            }
            return updateUsuarioResponse;            
        }

        public async Task<DeleteUserResponse> DeleteUser(DeleteUsuarioRequest request)
        {
            DeleteUserResponse updateUsuarioResponse = null;
            var user = await _context.Usuarios.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (user != null)
            {                 
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
                updateUsuarioResponse = new DeleteUserResponse()
                {
                    Entidad = null,
                    Estado = 200,
                    Mensaje = "Usuario eliminado satisfactoriamente."
                };
            }
            else
            {
                updateUsuarioResponse = new DeleteUserResponse()
                {
                    Entidad = null,
                    Estado = 400,
                    Mensaje = "No existe un usuario registrado con ese id."
                };
            }
            return updateUsuarioResponse;
        }

        public async Task<AddAuthorSuscripcionResponse> AddUserSuscripcion(AddAuthorSuscripcionRequest request)
        {
            AddAuthorSuscripcionResponse response = null;
            try
            {
                var exists = await _context.Suscripciones.AnyAsync(p => p.UsuarioId == request.UserId && p.AutorId == request.AuthorId);
                if (!exists)
                {
                    await _context.AddAsync(new Suscripcion() { AutorId = request.AuthorId, UsuarioId = request.UserId });
                    await _context.SaveChangesAsync();
                    response = new AddAuthorSuscripcionResponse()
                    {
                        Entidad = new Dtos.Suscripcion.SuscripcionDto()
                        {
                            AutorId = request.AuthorId,
                            UsuarioId = request.UserId
                        },
                        Estado = 200,
                        Mensaje = "Success"
                    };
                }
                else
                {
                    response = new AddAuthorSuscripcionResponse()
                    {
                        Entidad = null,
                        Estado = 400,
                        Mensaje = "El usuario ya esta suscrito al autor."
                    };
                }
            }
            catch(Exception ex)
            {
                response = new AddAuthorSuscripcionResponse()
                {
                    Entidad = null,
                    Estado = 500,
                    Mensaje = "Error indeterminado"
                };
            }           
            

            return response;
        }

        public async Task EliminarUserSuscripcion(DeleteUserSuscripcionRequest request)
        {
            var suscripcion = await _context.Suscripciones.FirstOrDefaultAsync(p => p.AutorId == request.AuthorId && p.UsuarioId.Equals(request.UserId));
            if (suscripcion != null)
            {
                _context.Suscripciones.Remove(suscripcion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<GetUserListResponse> GetPagedUserList(GetUserListRequest request)
        {
            var usuarios = _context.Usuarios.Include(p => p.Suscripciones).ProjectTo<UserView>(_mapper.ConfigurationProvider);
            var count = usuarios.Count();
            var items = usuarios.Skip(request.Offset).Take(request.Limit).ToList();
            return await Task.FromResult(
                new GetUserListResponse() {
                    Entidad = new PagedUserViewList()
                    {
                        TotalUsuarios = count,
                        Usuarios = items,
                        Pagina = request.Offset,
                        TotalPaginas = (int)Math.Ceiling(count / (double)request.Limit)
                    },
                    Estado = 200,
                    Mensaje = "Success"
            });
        }
        

    }
}
