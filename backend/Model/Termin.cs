using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Termin
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PacijentId")]
        public int PacijentId { get; set; }
        [Required]
        public string Datum { get; set; }
        [Required]
        public string Vreme { get; set; }
        [Required]
        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }

    }
}
