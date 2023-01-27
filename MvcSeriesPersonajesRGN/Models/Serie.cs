using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSeriesPersonajesRGN.Models
{
    [Table("SERIES")]
    public class Serie
    {
        [Key]
        [Column("IDSERIE")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public string nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("ANYO")]
        public int Anyo { get; set; }
    }
}
