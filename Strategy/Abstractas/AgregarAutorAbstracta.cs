using Api.Microservice.Autor.Aplicacion;
using System.Threading.Tasks;
using Strategy.Interfaces;

namespace Strategy.Abstractas
{
    public abstract class AgregarAutorAbstracta : IAgregarAutor
    {
        // Implementa correctamente el método AgregarAutorAsync
        public virtual Task AgregarAutorAsync(AgregarAutorRequest autor)
        {
            throw new NotImplementedException();
        }
    }
}
