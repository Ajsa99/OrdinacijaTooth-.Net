using backend.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Interface
{
    public interface IPacijentInterface
    {
        Task<IEnumerable<Pacijent>> GetPacijentiAsync();
        Task<Pacijent> GetPacijentAsync(int id);
        Task<Pacijent> FindPacijent(int id);
        void AddPacijent(Pacijent pacijent);
        void DeletePacijent(int id);
        void UpdatePacijent(Pacijent pacijent);
        Task<IEnumerable<Pacijent>> Page(int page, int pageSize, int id);
    }
}
