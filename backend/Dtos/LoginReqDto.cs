using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class LoginReqDto
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Ime mora imati između 2 i 20 karaktera.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Ime može sadržati samo slova.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Prezime mora imati između 2 i 20 karaktera.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Prezime može sadržati samo slova.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Pol je obavezan.")]
        public string Pol { get; set; }
        [Required(ErrorMessage = "Datum rođenja je obavezan.")]
        public DateTime? DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Telefon je obavezan.")]
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Država je obavezna.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Država mora imati između 2 i 20 karaktera.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Država može sadržati samo slova.")]
        public string Drzava { get; set; }
        [Required(ErrorMessage = "Grad je obavezan.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Grad mora imati između 2 i 20 karaktera.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Grad može sadržati samo slova.")]
        public string Grad { get; set; }
        [Required(ErrorMessage = "Adresa je obavezna.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Adresa mora imati između 2 i 30 karaktera.")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password je obavezan.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tip je obavezan.")]
        public string Tip { get; set; }
        public int Odobrenje { get; set; }
    }
}
