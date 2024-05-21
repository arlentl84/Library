﻿using Library.WebApi.BusinessLogic.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Dtos.Libro
{
    public class GetLibrosByParamResponse
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public List<LibroPorAutorDto> Entidad { get; set; }
    }
}