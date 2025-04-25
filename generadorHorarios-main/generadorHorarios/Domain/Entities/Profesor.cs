using GeneradorHorarios.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace GeneradorHorarios.Domain.Entities
{
    public class Profesor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Disponibilidad Disponibilidad { get; set; }
        public List<AsignacionMateria> Asignaciones { get; set; } = new();
    }
}
