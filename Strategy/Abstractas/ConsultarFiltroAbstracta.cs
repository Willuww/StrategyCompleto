using Api.Microservice.Autor.Aplicacion;
using Strategy.Interfaces;
using System.Threading.Tasks;

namespace Strategy.Abstractas
{
    public abstract class ConsultarFiltroAbstracta : IConsultarF
    {
        public abstract Task<AutorDto> ConsultarFiltroAsync(string autorGuid);
    }
}
