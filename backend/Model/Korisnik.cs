using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Korisnik
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Pol { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public int Telefon { get; set; }
        [Required]
        public string Drzava { get; set; }
        [Required]
        public string? Grad { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }
        [Required]
        public string Tip { get; set; }
        [Required]
        public int Odobrenje { get; set; }

    }
}
