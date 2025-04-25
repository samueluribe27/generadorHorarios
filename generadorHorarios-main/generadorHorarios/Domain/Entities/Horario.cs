using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Horario
    {
        public Guid Id { get; set; }
        public Guid ProfesorId { get; set; }
        public string Detalles { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Materia { get; set; }
    }
}
