using backend.Interface;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repo
{
    public class TerminRepository : ITerminInterface
    {
        private DataContext dc;

        public TerminRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Termin>> GetTerminiAsync()
        {
            if (dc.Termin is null)
            {
                throw new InvalidOperationException("The 'Termin' property is null.");
            }

            return await dc.Termin.ToListAsync();
        }

        public async Task<Termin> GetTerminAsync(int id)
        {
            var pacijenti = await GetTerminiAsync();

            var pacijent = pacijenti.FirstOrDefault(p => p.Id == id);

            return pacijent;
        }

        public async Task<Termin> FindTermin(int id)
        {
            if (dc.Termin is null)
            {
                throw new InvalidOperationException("The 'Termin' property is null.");
            }
            var termin = await dc.Termin.FindAsync(id);
            if (termin == null)
            {
                throw new Exception("Termin not found");
            }
            return termin;
        }

        public void AddTermin(Termin termin)
        {
            if (dc.Termin is null)
            {
                throw new InvalidOperationException("The 'Termin' property is null.");
            }

            dc.Termin.AddAsync(termin);
        }

    }
}
