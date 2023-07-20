namespace backend.Dtos
{
    public class GetPacijentPregledTermin
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Datum { get; set; }
        public string Vreme { get; set; }
        public int PacijentId { get; set; }
        public int KorisnikId { get; set; }
        public int PregledId { get; set; }
        public int BrojZuba { get; set; }
        public int GronjaVilicaBr { get; set; }
        public int DonjaVilicaBr { get; set; }
        public string GronjaVilicaStanje { get; set; }
        public string DonjaVilicaStanje { get; set; }
        public string Opis { get; set; }
        public int TerminId { get; set; }
    }
}
