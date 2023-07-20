using backend.Dtos;
using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repo
{
    public class PregledRepository : IPregledInterface
    {
        private DataContext dc;

        public PregledRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Pregled>> GetPreglediAsync()
        {
            if (dc.Pregled is null)
            {
                throw new InvalidOperationException("The 'Pregled' property is null.");
            }

            return await dc.Pregled.ToListAsync();
        }


        public async Task<Pregled> GetPregledAsync(int id)
        {
            var pregledi = await GetPreglediAsync();

            var pregled = pregledi.FirstOrDefault(p => p.Id == id);

            return pregled;
        }

        public async Task<Pregled> FindPregled(int id)
        {
            if (dc.Pregled is null)
            {
                throw new InvalidOperationException("The 'Pregled' property is null.");
            }
            var pregled = await dc.Pregled.FindAsync(id);
            if (pregled == null)
            {
                throw new Exception("Pregled not found");
            }
            return pregled;
        }

        public void AddPregled(Pregled pregled)
        {
            if (dc.Pregled is null)
            {
                throw new InvalidOperationException("The 'Pregled' property is null.");
            }

            dc.Pregled.AddAsync(pregled);
        }

    }
}
