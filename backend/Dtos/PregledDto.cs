using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Dtos
{
    public class PregledDto
    {
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
