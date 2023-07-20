using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Dtos
{
    public class GetTerminPacijentDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Datum { get; set; }
        public string Vreme { get; set; }
        public int PacijentId { get; set; }
        public int KorisnikId { get; set; }
    }
}
