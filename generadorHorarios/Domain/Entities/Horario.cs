using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Horario
    {
        public Guid Id { get; set; }
        public Guid ProfesorId { get; set; }
        public string Detalles { get; set; }
        // Puedes ampliar con propiedad para d�a, hora inicio, aula, etc.
    }
}
