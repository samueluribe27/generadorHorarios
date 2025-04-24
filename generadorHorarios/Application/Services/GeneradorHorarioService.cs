using GeneradorHorarios.Application.Interfaces;
using GeneradorHorarios.Domain.Entities;
using GeneradorHorarios.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace GeneradorHorarios.Application.Services
{
    public class GeneradorHorarioService : IGeneradorHorarioService
    {
        public void RegistrarDisponibilidad(Profesor profesor)
        {
            // Aquí se validaría y registraría la disponibilidad (por ejemplo, guardarla en un repositorio)
            Console.WriteLine($"Registrando disponibilidad del profesor {profesor.Nombre}");
        }

        public (Horario horario, List<Examen> examenes) GenerarHorarioYExamenes(Profesor profesor)
        {
            // Lógica muy simplificada para ilustrar la generación:
            // Asigna materias, genera un horario y agenda exámenes basándose en la disponibilidad.
            var horario = new Horario
            {
                Id = Guid.NewGuid(),
                ProfesorId = profesor.Id,
                Detalles = "Horario generado automáticamente en base a la disponibilidad."
            };

            var examenes = new List<Examen>
            {
                new Examen
                {
                    Id = Guid.NewGuid(),
                    ProfesorId = profesor.Id,
                    Detalles = "Examen asignado automáticamente.",
                    Fecha = DateTime.Now.AddDays(7)
                }
            };

            return (horario, examenes);
        }
    }
}
