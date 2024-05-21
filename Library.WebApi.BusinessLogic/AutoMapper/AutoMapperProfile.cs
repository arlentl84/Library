using AutoMapper;
using Library.WebApi.BusinessLogic.Dtos.Autor;
using Library.WebApi.BusinessLogic.Dtos.Libro;
using Library.WebApi.BusinessLogic.Dtos.Revision;
using Library.WebApi.BusinessLogic.Dtos.Usuario;
using Library.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioDto>();            
            CreateMap<AddAutorRequest, Autor>();
            CreateMap<Autor, AutorDto>();
            CreateMap<Libro, LibroView>();
            CreateMap<AddLibro, Libro>().ForMember(b => b.Editorial, opt => opt.MapFrom(b => b.Editorial)); 
            CreateMap<Libro, LibroDto>();
            CreateMap<Libro, LibroPorAutorDto>().ForMember(b => b.NombreAutor, opt => opt.MapFrom(b => b.Autor.Nombre));
            
            CreateMap<Autor, AutorView>().ForMember(b => b.CantidadUsuarios, opt => opt.MapFrom(b => b.Suscritos.Count()));
            CreateMap<Usuario, UserView>().ForMember(b => b.CantidadAutoresSuscrito, opt => opt.MapFrom(b => b.Suscripciones.Count));
            CreateMap<Revision, RevisionView>()
                .ForMember(b => b.UsuarioId, opt => opt.MapFrom(b => b.UsuarioId))
                .ForMember(b => b.NombreUsuario, opt => opt.MapFrom(b => b.Usuario.Nombre))
                .ForMember(b => b.TituloLibro, opt => opt.MapFrom(b => b.Libro.Titulo))
                .ForMember(b => b.LibroId, opt => opt.MapFrom(b => b.LibroId));
            CreateMap<Revision, RevisionDto>();

        }
    }
}
