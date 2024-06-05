using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Microservice.Autor.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Strategy.Interfaces;

namespace Strategy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAgregarAutor _agregarAutor;
        private readonly IConsultarAutor _consultarAutor;
        private readonly IConsultarF _consultarFiltro;

        public AutorController(IAgregarAutor agregarAutor, IConsultarAutor consultarAutor, IConsultarF consultarFiltro)
        {
            _agregarAutor = agregarAutor ?? throw new ArgumentNullException(nameof(agregarAutor));
            _consultarAutor = consultarAutor ?? throw new ArgumentNullException(nameof(consultarAutor));
            _consultarFiltro = consultarFiltro ?? throw new ArgumentNullException(nameof(consultarFiltro));
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> Get()
        {
            return await _consultarAutor.ConsultarAutorAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetById(string id)
        {
            try
            {
                var autor = await _consultarFiltro.ConsultarFiltroAsync(id);
                return autor;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(AgregarAutorRequest request)
        {
            try
            {
                // Verificar si el objeto request es nulo
                if (request == null)
                {
                    return BadRequest("El objeto request no puede ser nulo.");
                }

                // Llamar al método AgregarAutorAsync utilizando la interfaz IAgregarAutor
                await _agregarAutor.AgregarAutorAsync(request);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
