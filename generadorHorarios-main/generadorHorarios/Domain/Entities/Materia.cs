using System;

namespace GeneradorHorarios.Domain.Entities
{
    public class Materia
    {
        public string Nombre { get; set; }
        public Guid? ProfesorId { get; set; } // Solo puede tener un profesor asignado
    }
}
