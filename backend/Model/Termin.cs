using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Termin
    {
        public int Id { get; set; }
        [ForeignKey("PacijentId")]
        public int PacijentId { get; set; }
        public string Datum { get; set; }
        public string Vreme { get; set; }
        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }

    }
}
