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
            // Aqu� se validar�a y registrar�a la disponibilidad (por ejemplo, guardarla en un repositorio)
            Console.WriteLine($"Registrando disponibilidad del profesor {profesor.Nombre}");
        }

        public (Horario horario, List<Examen> examenes) GenerarHorarioYExamenes(Profesor profesor)
        {
            // L�gica muy simplificada para ilustrar la generaci�n:
            // Asigna materias, genera un horario y agenda ex�menes bas�ndose en la disponibilidad.
            var horario = new Horario
            {
                Id = Guid.NewGuid(),
                ProfesorId = profesor.Id,
                Detalles = "Horario generado autom�ticamente en base a la disponibilidad."
            };

            var examenes = new List<Examen>
            {
                new Examen
                {
                    Id = Guid.NewGuid(),
                    ProfesorId = profesor.Id,
                    Detalles = "Examen asignado autom�ticamente.",
                    Fecha = DateTime.Now.AddDays(7)
                }
            };

            return (horario, examenes);
        }
    }
}
