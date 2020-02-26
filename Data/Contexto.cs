using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSistemaInscripciones.Data
{
    public class Contexto:DbContext
    {
        public DbSet<Inscripciones> Inscripciones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Data.db");
        }
    }
}
