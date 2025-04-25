using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Examen
    {
        public Guid Id { get; set; }
        public Guid ProfesorId { get; set; }
        public string Detalles { get; set; }
        public DateTime Fecha { get; set; }
        // Otras propiedades como duración, aula, etc.
    }
}
