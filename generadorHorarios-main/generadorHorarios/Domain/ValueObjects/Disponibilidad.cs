using System.Collections.Generic;

namespace GeneradorHorarios.Domain.ValueObjects
{
    public class Disponibilidad
    {
        public List<HorarioDisponible> Horarios { get; set; } = new();
    }
}
