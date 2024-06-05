using System.Threading.Tasks;
using Api.Microservice.Autor.Aplicacion;

namespace Strategy.Interfaces
{
    public interface IAgregarAutor
    {
        Task AgregarAutorAsync(AgregarAutorRequest autor);
    }
}
