using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class AsignacionMateria
    {
        public string Materia { get; set; }
        public DayOfWeek Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
