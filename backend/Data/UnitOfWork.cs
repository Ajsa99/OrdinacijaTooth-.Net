using backend.Data.Repo;
using backend.Interface;

namespace backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IKorisnikInterface KorisnikRepository =>
            new KorisnikRepository(dc);

        public IPacijentInterface PacijentRepository =>
            new PacijentRepository(dc);

        public ITerminInterface TerminRepository =>
            new TerminRepository(dc);
        public IPregledInterface PregledRepository =>
            new PregledRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }

    }
}
