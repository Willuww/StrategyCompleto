using Api.Microservice.Autor.Aplicacion;

namespace Strategy.Interfaces
{
    public interface IConsultarF
    {
        Task<AutorDto> ConsultarFiltroAsync(string autorGuid);
    }
}
