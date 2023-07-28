using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Dtos
{
    public class PregledDto
    {
        [Required]
        public int BrojZuba { get; set; }
        [Required]
        public int GronjaVilicaBr { get; set; }
        [Required]
        public int DonjaVilicaBr { get; set; }
        [Required]
        public string GronjaVilicaStanje { get; set; }
        [Required]
        public string DonjaVilicaStanje { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        [ForeignKey("TerminId")]
        public int TerminId { get; set; }
    }
}
