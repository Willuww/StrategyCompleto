using Api.Microservice.Autor.Modelo;
using Api.Microservice.Autor.Persistencia;
using FluentValidation;
using MediatR;
using Strategy.Aplicacion;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Microservice.Autor.Aplicacion
{
    // Esta clase se encarga del transporte de los datos del controlador hacia la lógica de mapeo
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Nombre).NotEmpty();
                RuleFor(p => p.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoAutor _context;
            private readonly ValidacionesEjecuta _validaciones;

            public Manejador(ContextoAutor context, ValidacionesEjecuta validaciones)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _validaciones = validaciones ?? throw new ArgumentNullException(nameof(validaciones));
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                await _validaciones.ValidarAsync(request);

                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

                _context.AutorLibros.Add(autorLibro);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el libro");
            }
        }
    }
}
