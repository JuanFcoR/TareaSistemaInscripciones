using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSistemaInscripciones.Models
{
    public class InscripcionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public decimal SubTotal { get; set; }

        public InscripcionesDetalle()
        {
            Id = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            Nombre = string.Empty;
            Creditos = 0;
        }
    }
}

