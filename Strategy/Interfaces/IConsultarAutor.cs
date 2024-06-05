using Api.Microservice.Autor.Aplicacion;

namespace Strategy.Interfaces
{
    public interface IConsultarAutor
    {
        Task<List<AutorDto>> ConsultarAutorAsync();
    }
}
