using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Horario
    {
        public Guid Id { get; set; }
        public Guid ProfesorId { get; set; }
        public string Detalles { get; set; }
        // Puedes ampliar con propiedad para día, hora inicio, aula, etc.
    }
}
