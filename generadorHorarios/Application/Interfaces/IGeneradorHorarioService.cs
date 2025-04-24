using GeneradorHorarios.Domain.Entities;
using System.Collections.Generic;

namespace GeneradorHorarios.Application.Interfaces
{
    public interface IGeneradorHorarioService
    {
        // Registra la disponibilidad del profesor y asigna materias.
        void RegistrarDisponibilidad(Profesor profesor);

        // Genera el horario y agenda exámenes según disponibilidad.
        (Horario horario, List<Examen> examenes) GenerarHorarioYExamenes(Profesor profesor);
    }
}
