using Api.Microservice.Autor.Aplicacion;
using Api.Microservice.Autor.Modelo;
using Api.Microservice.Autor.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Strategy.Abstractas;

namespace Strategy.Concretas
{
    public class ConsultarFiltroConcreta : ConsultarFiltroAbstracta
    {
        private readonly ContextoAutor _context;
        private readonly IMapper _mapper;

        public ConsultarFiltroConcreta(ContextoAutor context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<AutorDto> ConsultarFiltroAsync(string autorGuid)
        {
            var autor = await _context.AutorLibros.FirstOrDefaultAsync(p => p.AutorLibroGuid == autorGuid);
            if (autor == null)
            {
                throw new Exception("No se encontró el autor");
            }

            var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);
            return autorDto;
        }
    }
}
