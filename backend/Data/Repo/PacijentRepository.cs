using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repo
{
    public class PacijentRepository : IPacijentInterface
    {
        private readonly DataContext dc;
        public PacijentRepository(DataContext dc)
        {
            this.dc = dc;

        }

        public async Task<IEnumerable<Pacijent>> GetPacijentiAsync()
        {
            if (dc.Pacijent is null)
            {
                throw new InvalidOperationException("The 'Pacijent' property is null.");
            }

            return await dc.Pacijent.ToListAsync();
        }

        public async Task<Pacijent> GetPacijentAsync(int id)
        {
            var pacijenti = await GetPacijentiAsync();

            var pacijent = pacijenti.FirstOrDefault(p => p.Id == id);

            return pacijent;
        }
        public async Task<Pacijent> FindPacijent(int id)
        {
            if (dc.Pacijent is null)
            {
                throw new InvalidOperationException("The 'Pacijent' property is null.");
            }
            var pacijent = await dc.Pacijent.FindAsync(id);
            if (pacijent == null)
            {
                throw new Exception("Pacijent not found");
            }
            return pacijent;
        }

        public void AddPacijent(Pacijent pacijent)
        {
            if (dc.Pacijent is null)
            {
                throw new InvalidOperationException("The 'Pacijent' property is null.");
            }

            dc.Pacijent.AddAsync(pacijent);
        }

        public void DeletePacijent(int id)
        {
            var pacijent = dc.Pacijent.Find(id);

            if(pacijent == null)
            {
                throw new InvalidOperationException("The 'Pacijent' property is null.");
            }

             dc.Pacijent.Remove(pacijent);
            dc.SaveChanges();
        }

        public void UpdatePacijent(Pacijent pacijent)
        {
            if (dc.Pacijent is null)
            {
                throw new InvalidOperationException("The 'Pacijent' property is null.");
            }

            dc.Pacijent.Update(pacijent);
        }
    }
}

