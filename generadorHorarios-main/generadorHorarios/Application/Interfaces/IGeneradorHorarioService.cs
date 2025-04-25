using GeneradorHorarios.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GeneradorHorarios.Application.Interfaces
{
    public interface IGeneradorHorarioService
    {
        void RegistrarDisponibilidad(Profesor profesor);
        List<Profesor> ObtenerProfesores();
        List<Materia> ObtenerMateriasDisponibles();
        bool AsignarMateria(Guid profesorId, string materia);
        string GenerarHorarioGlobal();
    }
}
