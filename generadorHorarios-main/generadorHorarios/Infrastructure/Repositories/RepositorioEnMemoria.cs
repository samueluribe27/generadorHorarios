using GeneradorHorarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneradorHorarios.Infrastructure.Repositories
{
    // Repositorio de ejemplo que simula una base de datos en memoria.
    public class RepositorioEnMemoria
    {
        private readonly List<Profesor> profesores = new();
        private readonly List<Horario> horarios = new();
        private readonly List<Examen> examenes = new();

        public void AgregarProfesor(Profesor profesor)
        {
            profesores.Add(profesor);
        }

        public Profesor? ObtenerProfesor(Guid id)
        {
            return profesores.FirstOrDefault(p => p.Id == id);
        }

        public void AgregarHorario(Horario horario)
        {
            horarios.Add(horario);
        }

        public void AgregarExamen(Examen examen)
        {
            examenes.Add(examen);
        }

        // Otros métodos de consulta según sea necesario.
    }
}
