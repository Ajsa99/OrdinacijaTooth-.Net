using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Pregled
    {
        public int Id { get; set; }
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
        public int TerminId { get; set; }
    }
}
