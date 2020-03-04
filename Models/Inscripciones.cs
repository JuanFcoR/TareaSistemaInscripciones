using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSistemaInscripciones.Models
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public string Semestre { get; set; }
        public int Limite { get; set; }
        public int Tomados { get; set; }
        public int Disponibles { get; set; }
        public decimal Balance { get; set; }
        [ForeignKey("InscripcionId")]
        public virtual List<InscripcionesDetalle> Detalle { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            Semestre = string.Empty;
            Limite = 0;
            Tomados = 0;
            Disponibles = 0;

            Detalle = new List<InscripcionesDetalle>();
        }
    }
}
