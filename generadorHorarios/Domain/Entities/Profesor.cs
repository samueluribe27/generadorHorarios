using GeneradorHorarios.Domain.ValueObjects;
using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Profesor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Disponibilidad Disponibilidad { get; set; }
        // Podrías incluir una lista de materias asignadas, cursos, etc.
    }
}
