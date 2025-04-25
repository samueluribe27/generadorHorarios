using System;

namespace GeneradorHorarios.Domain.ValueObjects
{
    public class HorarioDisponible
    {
        public DayOfWeek Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
