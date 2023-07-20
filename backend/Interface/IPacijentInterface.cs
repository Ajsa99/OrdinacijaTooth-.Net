using backend.Model;

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
    }
}
