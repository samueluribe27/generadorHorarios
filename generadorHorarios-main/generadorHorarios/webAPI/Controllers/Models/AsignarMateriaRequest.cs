using System;

namespace GeneradorHorarios.WebAPI.Models
{
    public class AsignarMateriaRequest
    {
        public Guid ProfesorId { get; set; }
        public string Materia { get; set; }
        public DayOfWeek Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
