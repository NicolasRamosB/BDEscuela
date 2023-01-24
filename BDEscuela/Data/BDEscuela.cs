using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDEscuela.Models;
using DBEducacionIT.Models;

namespace BDEscuela.Data
{
    public class BDEscuela : DbContext
    {
        public BDEscuela() : base("KeyDB") { }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Planilla> Planillas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Plan> PLanes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }



    }
}
