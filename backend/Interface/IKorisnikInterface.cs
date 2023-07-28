using backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interface
{
    public interface IKorisnikInterface
    {
        Task<IEnumerable<Korisnik>> GetKorisniciAsync();
        Task<Korisnik> GetKorisnikAsync(int id);
        Task<Korisnik> FindKorisnik(int id);
        Task<Korisnik> Authenticate(string Email, string passwordText);
        void Register(string Ime, string Prezime, string Pol, DateTime DatumRodjenja, int Telefon, string Drzava,
               string Grad, string Adresa, string Email, string Password, string Tip, int Odobrenje);
        void DeleteKorisnik(int id);
        Task<bool> KorisnikAlreadyExists(string Ime);

    }
}
