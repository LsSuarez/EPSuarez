using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_.Models
{
    [Table("t_asignamiento")]
    public class Asignamiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Equipos? Equipo { get; set; }
        public Jugadores? Jugador { get; set; } 

        
    }
}