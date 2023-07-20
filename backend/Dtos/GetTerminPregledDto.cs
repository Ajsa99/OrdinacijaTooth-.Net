using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Dtos
{
    public class GetTerminPregledDto
    {
        [ForeignKey("PacijentId")]
        public int PacijentId { get; set; }
        public string Datum { get; set; }
        public string Vreme { get; set; }

        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }
        public int BrojZuba { get; set; }
        public int GronjaVilicaBr { get; set; }
        public int DonjaVilicaBr { get; set; }
        public string GronjaVilicaStanje { get; set; }
        public string DonjaVilicaStanje { get; set; }
        public string Opis { get; set; }
        [ForeignKey("TerminId")]
        public int TerminId { get; set; }
    }
}
