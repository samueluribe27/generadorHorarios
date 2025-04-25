using GeneradorHorarios.Application.Interfaces;
using GeneradorHorarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorHorarios.Application.Services
{
    public class GeneradorHorarioService : IGeneradorHorarioService
    {
        private readonly List<Profesor> _profesores = new();
        private readonly List<Examen> _examenes = new();
        private readonly List<Materia> _materias = new();

        public GeneradorHorarioService()
        {
            _materias = new List<Materia>
            {
                new Materia { Nombre = "Matemáticas" },
                new Materia { Nombre = "Inglés" },
                new Materia { Nombre = "Programación" },
                new Materia { Nombre = "Ciencias" },
                new Materia { Nombre = "Historia" }
            };
        }

        public void RegistrarDisponibilidad(Profesor profesor)
        {
            _profesores.Add(profesor);
        }

        public List<Profesor> ObtenerProfesores() => _profesores;

        public List<Materia> ObtenerMateriasDisponibles()
        {
            return _materias.Where(m => m.ProfesorId == null).ToList();
        }

        public bool AsignarMateria(Guid profesorId, string materia)
        {
            var prof = _profesores.FirstOrDefault(p => p.Id == profesorId);
            if (prof == null) return false;

            var mat = _materias.FirstOrDefault(m => m.Nombre == materia);
            if (mat == null || mat.ProfesorId != null) return false;

            mat.ProfesorId = profesorId;
            return true;
        }

        public string GenerarHorarioGlobal()
        {
            var clasesAgendadas = new List<(DayOfWeek, TimeSpan, TimeSpan)>();

            foreach (var materia in _materias.Where(m => m.ProfesorId != null))
            {
                var profesor = _profesores.FirstOrDefault(p => p.Id == materia.ProfesorId);
                if (profesor == null) continue;

                var bloqueClase = profesor.Disponibilidad.Horarios.FirstOrDefault(b =>
                    !profesor.Asignaciones.Any(a =>
                        a.Dia == b.Dia &&
                        ((b.HoraInicio >= a.HoraInicio && b.HoraInicio < a.HoraFin) ||
                         (b.HoraFin > a.HoraInicio && b.HoraFin <= a.HoraFin))) &&
                    !clasesAgendadas.Any(c =>
                        c.Item1 == b.Dia &&
                        ((b.HoraInicio >= c.Item2 && b.HoraInicio < c.Item3) ||
                         (b.HoraFin > c.Item2 && b.HoraFin <= c.Item3)))
                );

                if (bloqueClase != default)
                {
                    profesor.Asignaciones.Add(new AsignacionMateria
                    {
                        Materia = materia.Nombre,
                        Dia = bloqueClase.Dia,
                        HoraInicio = bloqueClase.HoraInicio,
                        HoraFin = bloqueClase.HoraFin
                    });

                    clasesAgendadas.Add((bloqueClase.Dia, bloqueClase.HoraInicio, bloqueClase.HoraFin));

                    var bloqueExamen = profesor.Disponibilidad.Horarios.FirstOrDefault(b =>
                        (b.Dia > bloqueClase.Dia || (b.Dia == bloqueClase.Dia && b.HoraInicio > bloqueClase.HoraFin)) &&
                        !profesor.Asignaciones.Any(a =>
                            a.Dia == b.Dia &&
                            ((b.HoraInicio >= a.HoraInicio && b.HoraInicio < a.HoraFin) ||
                             (b.HoraFin > a.HoraInicio && b.HoraFin <= a.HoraFin))) &&
                        !clasesAgendadas.Any(c =>
                            c.Item1 == b.Dia &&
                            ((b.HoraInicio >= c.Item2 && b.HoraInicio < c.Item3) ||
                             (b.HoraFin > c.Item2 && b.HoraFin <= c.Item3)))
                    );

                    if (bloqueExamen != default)
                    {
                        _examenes.Add(new Examen
                        {
                            Id = Guid.NewGuid(),
                            ProfesorId = profesor.Id,
                            Detalles = $"Examen de {materia.Nombre} ({profesor.Nombre})",
                            Fecha = DateTime.Today.AddDays((int)bloqueExamen.Dia - (int)DateTime.Today.DayOfWeek + ((int)DateTime.Today.DayOfWeek > (int)bloqueExamen.Dia ? 7 : 0)).Add(bloqueExamen.HoraInicio)
                        });

                        clasesAgendadas.Add((bloqueExamen.Dia, bloqueExamen.HoraInicio, bloqueExamen.HoraFin));
                    }
                }
            }

            var sb = new StringBuilder();
            foreach (var dia in Enum.GetValues<DayOfWeek>().Where(d => d >= DayOfWeek.Monday && d <= DayOfWeek.Friday))
            {
                sb.AppendLine($"{TraducirDia(dia)}:");
                foreach (var prof in _profesores)
                {
                    var clases = prof.Asignaciones.Where(a => a.Dia == dia).OrderBy(a => a.HoraInicio);
                    foreach (var c in clases)
                    {
                        sb.AppendLine($"{c.HoraInicio:hh\\:mm} - {c.HoraFin:hh\\:mm} {c.Materia} ({prof.Nombre})");
                    }

                    var examenes = _examenes.Where(e => e.ProfesorId == prof.Id && e.Fecha.DayOfWeek == dia);
                    foreach (var e in examenes)
                    {
                        sb.AppendLine($"{e.Fecha:HH:mm} {e.Detalles}");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private string TraducirDia(DayOfWeek dia) => dia switch
        {
            DayOfWeek.Monday => "Lunes",
            DayOfWeek.Tuesday => "Martes",
            DayOfWeek.Wednesday => "Miércoles",
            DayOfWeek.Thursday => "Jueves",
            DayOfWeek.Friday => "Viernes",
            _ => dia.ToString()
        };
    }
}
