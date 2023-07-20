using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Dtos
{
    public class GetTerminiDto
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
