using Api.Microservice.Autor.Aplicacion;
using Api.Microservice.Autor.Modelo;
using Api.Microservice.Autor.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Strategy.Abstractas;

namespace Strategy.Concretas
{
    public class ConsultarAutorConcreta : ConsultarAutorAbstracta
    {
        private readonly ContextoAutor _context;
        private readonly IMapper _mapper;

        public ConsultarAutorConcreta(ContextoAutor context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<AutorDto>> ConsultarAutorAsync()
        {
            var autores = await _context.AutorLibros.ToListAsync();
            var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);
            return autoresDto;
        }
    }
}
