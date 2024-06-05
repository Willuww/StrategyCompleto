using Api.Microservice.Autor.Aplicacion;
using Strategy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Strategy.Abstractas
{
    public abstract class ConsultarAutorAbstracta : IConsultarAutor
    {
        public abstract Task<List<AutorDto>> ConsultarAutorAsync();
    }
}
