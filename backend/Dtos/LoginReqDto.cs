namespace backend.Dtos
{
    public class LoginReqDto
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Pol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? Telefon { get; set; }
        public string? Drzava { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Tip { get; set; }
        public int Odobrenje { get; set; }
    }
}
