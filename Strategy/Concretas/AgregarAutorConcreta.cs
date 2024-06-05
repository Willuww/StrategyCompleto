using System;
using System.Threading.Tasks;
using Api.Microservice.Autor.Aplicacion;
using Api.Microservice.Autor.Modelo;
using Api.Microservice.Autor.Persistencia;
using Strategy.Interfaces;

namespace Strategy.Concretas
{
    public class AgregarAutorConcreta : IAgregarAutor
    {
        private readonly ContextoAutor _context;

        public AgregarAutorConcreta(ContextoAutor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AgregarAutorAsync(AgregarAutorRequest autor)
        {
            // Validar el autor aquí si es necesario

            var autorLibro = new AutorLibro
            {
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                AutorLibroGuid = Guid.NewGuid().ToString()
            };

            _context.AutorLibros.Add(autorLibro);
            var respuesta = await _context.SaveChangesAsync();
            if (respuesta <= 0)
            {
                throw new Exception("No se pudo insertar el autor.");
            }
        }
    }
}
