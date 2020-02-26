using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TareaSistemaInscripciones.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string PreRequisito { get; set; }
        public int Creditos { get; set; }

        public Asignaturas()
        {
            AsignaturaId = 0;
            Codigo = String.Empty;
            Descripcion = String.Empty;
            PreRequisito = String.Empty;
            Creditos = 0;
        }
    }
}
