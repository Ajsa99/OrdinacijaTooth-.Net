using backend.Interface;
using backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Repo
{
    internal class KorisnikRepository : IKorisnikInterface
    {
        private readonly DataContext dc;
        public KorisnikRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public async Task<IEnumerable<Korisnik>> GetKorisniciAsync()
        {
            if (dc.Korisnik is null)
            {
                throw new InvalidOperationException("The 'Korisnik' property is null.");
            }

            return await dc.Korisnik.ToListAsync();
        }

        public async Task<Korisnik> GetKorisnikAsync(int id)
        {
            var korisnici = await GetKorisniciAsync();

            var korisnik = korisnici.FirstOrDefault(u => u.Id == id);

            return korisnik;
        }

        public async Task<Korisnik> FindKorisnik(int id)
        {
            if (dc.Korisnik is null)
            {
                throw new InvalidOperationException("The 'Korisnik' property is null.");
            }
            var korisnik = await dc.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                throw new Exception("Korisnik not found");
            }
            return korisnik;
        }

        public async Task<Korisnik> Authenticate(string Email, string passwordText)
        {
            var korisnik = await dc.Korisnik?.FirstOrDefaultAsync(x => x.Email == Email);

            if (korisnik == null || korisnik.PasswordKey == null)
                return null;

            if (!MatchPasswordHash(passwordText, korisnik.Password, korisnik.PasswordKey))
                return null;

            return korisnik;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }

     
     
        public void Register(string Ime, string Prezime, string Pol, DateTime DatumRodjenja, int Telefon, string Drzava, string Grad, string Adresa, string Email, string Password, string Tip, int Odobrenje)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));

                Korisnik korisnik = new Korisnik();
                korisnik.Ime = Ime;
                korisnik.Prezime = Prezime;
                korisnik.Pol = Pol;
                korisnik.DatumRodjenja = DatumRodjenja;
                korisnik.Telefon = Telefon;
                korisnik.Drzava = Drzava;
                korisnik.Grad = Grad;
                korisnik.Adresa = Adresa;
                korisnik.Email = Email;
                korisnik.Password = passwordHash;
                korisnik.PasswordKey = passwordKey;
                korisnik.Tip = Tip;
                korisnik.Odobrenje = Odobrenje;

                dc.Korisnik.Add(korisnik);
            }
        }


        public void DeleteKorisnik(int id)
        {
            var korisnik = dc.Korisnik.Find(id);

            if (korisnik == null)
            {
                throw new InvalidOperationException("The 'korisnik' property is null.");
            }

            dc.Korisnik.Remove(korisnik);
            dc.SaveChanges();
        }

        public async Task<bool> KorisnikAlreadyExists(string Email)
        {
            return await dc.Korisnik.AnyAsync(x => x.Email == Email);
        }

    }
}