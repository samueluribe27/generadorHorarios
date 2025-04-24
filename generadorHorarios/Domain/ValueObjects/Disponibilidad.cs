using System;
using System.Collections.Generic;

namespace GeneradorHorarios.Domain.ValueObjects
{
    public class Disponibilidad
    {
        // Por ejemplo, podría ser una lista de días y franjas horarias disponibles.
        public List<(DayOfWeek Dia, TimeSpan HoraInicio, TimeSpan HoraFin)> Horarios { get; set; } = new List<(DayOfWeek, TimeSpan, TimeSpan)>();

        // Métodos de validación o chequeos adicionales.
    }
}
