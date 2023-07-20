using backend.Model;

namespace backend.Interface
{
    public interface ITerminInterface
    {
        Task<IEnumerable<Termin>> GetTerminiAsync();
        Task<Termin> GetTerminAsync(int id);
        Task<Termin> FindTermin(int id);
        void AddTermin(Termin termin);
    }
}
