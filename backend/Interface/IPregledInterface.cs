using backend.Dtos;
using backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interface
{
    public interface IPregledInterface
    {
        Task<IEnumerable<Pregled>> GetPreglediAsync();
        Task<Pregled> GetPregledAsync(int id);
        Task<Pregled> FindPregled(int id);
        void AddPregled(Pregled pregled);
    }
}
