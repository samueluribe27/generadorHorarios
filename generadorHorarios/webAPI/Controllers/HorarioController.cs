using GeneradorHorarios.Application.Interfaces;
using GeneradorHorarios.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeneradorHorarios.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioController : ControllerBase
    {
        private readonly IGeneradorHorarioService _generadorHorarioService;

        public HorarioController(IGeneradorHorarioService generadorHorarioService)
        {
            _generadorHorarioService = generadorHorarioService;
        }

        // Endpoint para registrar la disponibilidad de un profesor
        [HttpPost("registrar-disponibilidad")]
        public IActionResult RegistrarDisponibilidad([FromBody] Profesor profesor)
        {
            _generadorHorarioService.RegistrarDisponibilidad(profesor);
            return Ok("Disponibilidad registrada correctamente.");
        }

        // Endpoint para generar horario y agendar exámenes
        [HttpPost("generar-horario")]
        public IActionResult GenerarHorario([FromBody] Profesor profesor)
        {
            var (horario, examenes) = _generadorHorarioService.GenerarHorarioYExamenes(profesor);
            // Aquí podrías guardar el horario y exámenes en un repositorio si lo necesitas.
            return Ok(new { Horario = horario, Examenes = examenes });
        }
    }
}
