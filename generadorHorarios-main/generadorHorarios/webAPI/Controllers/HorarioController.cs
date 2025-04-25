using GeneradorHorarios.Application.Interfaces;
using GeneradorHorarios.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace GeneradorHorarios.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioController : ControllerBase
    {
        private readonly IGeneradorHorarioService _servicio;

        public HorarioController(IGeneradorHorarioService servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("registrar-disponibilidad")]
        public IActionResult RegistrarDisponibilidad([FromBody] Profesor profesor)
        {
            _servicio.RegistrarDisponibilidad(profesor);
            return Ok("Disponibilidad registrada correctamente.");
        }

        [HttpPost("asignar-materia")]
        public IActionResult AsignarMateria(Guid profesorId, string materia)
        {
            var ok = _servicio.AsignarMateria(profesorId, materia);
            if (!ok)
                return BadRequest("La materia ya está asignada o no existe.");
            return Ok("Materia asignada al profesor.");
        }

        [HttpPost("generar-horario")]
        public IActionResult GenerarHorario()
        {
            var texto = _servicio.GenerarHorarioGlobal();
            return File(Encoding.UTF8.GetBytes(texto), "text/plain", "horario.txt");
        }

        [HttpGet("profesores")]
        public IActionResult ObtenerProfesores()
        {
            return Ok(_servicio.ObtenerProfesores());
        }

        [HttpGet("materias-disponibles")]
        public IActionResult ObtenerMateriasDisponibles()
        {
            return Ok(_servicio.ObtenerMateriasDisponibles());
        }
    }
}
