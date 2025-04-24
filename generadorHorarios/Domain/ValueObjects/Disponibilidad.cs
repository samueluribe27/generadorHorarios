using System;
using System.Collections.Generic;

namespace GeneradorHorarios.Domain.ValueObjects
{
    public class Disponibilidad
    {
        // Por ejemplo, podr�a ser una lista de d�as y franjas horarias disponibles.
        public List<(DayOfWeek Dia, TimeSpan HoraInicio, TimeSpan HoraFin)> Horarios { get; set; } = new List<(DayOfWeek, TimeSpan, TimeSpan)>();

        // M�todos de validaci�n o chequeos adicionales.
    }
}
