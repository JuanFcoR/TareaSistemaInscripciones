using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaSistemaInscripciones.Models;

namespace TareaSistemaInscripciones.Data
{
    public class Contexto:DbContext
    {
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Data.db");
        }
    }
}
