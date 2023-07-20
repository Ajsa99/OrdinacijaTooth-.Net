using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Korisnik>? Korisnik { get; set; }
        public DbSet<Pacijent>? Pacijent { get; set; }
        public DbSet<Termin>? Termin { get; set; }
        public DbSet<Pregled>? Pregled { get; set; }


    }
}
