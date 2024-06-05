using System;
using System.Threading.Tasks;
using Api.Microservice.Autor.Aplicacion;
using Api.Microservice.Autor.Modelo;
using Api.Microservice.Autor.Persistencia;
using Strategy.Interfaces;

namespace Strategy.Aplicacion
{
    public class ValidacionesEjecuta : IValidaciones
    {
        private readonly ContextoAutor _context;

        public ValidacionesEjecuta(ContextoAutor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task ValidarAsync(object request)
        {
            if (request is AgregarAutorRequest agregarAutorRequest)
            {
                // Validar la solicitud aquí
                if (string.IsNullOrEmpty(agregarAutorRequest.Nombre))
                {
                    throw new ArgumentException("El nombre del autor no puede estar vacío.");
                }
                if (string.IsNullOrEmpty(agregarAutorRequest.Apellido))
                {
                    throw new ArgumentException("El apellido del autor no puede estar vacío.");
                }

                // Si pasa la validación, se procede a insertar el autor en la base de datos
                var autorLibro = new AutorLibro
                {
                    Nombre = agregarAutorRequest.Nombre,
                    Apellido = agregarAutorRequest.Apellido,
                    FechaNacimiento = agregarAutorRequest.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _context.AutorLibros.Add(autorLibro);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta <= 0)
                {
                    throw new Exception("No se pudo insertar el autor.");
                }
            }
            else
            {
                throw new ArgumentException("El objeto request no es del tipo esperado.");
            }
        }
    }
}
