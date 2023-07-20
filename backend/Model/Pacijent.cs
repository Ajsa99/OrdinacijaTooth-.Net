using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Pacijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string DatumRodjenja { get; set; }
        public int Telefon { get; set; }
        public string Drzava { get; set; }
        public string? Grad { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }

        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }
    }
}
