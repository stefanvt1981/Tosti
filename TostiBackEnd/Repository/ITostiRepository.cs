using System.Collections.Generic;
using System.Threading.Tasks;
using TostiBusinessEntities;

namespace TostiBackEnd.Repository
{
    public interface ITostiRepository
    {
        Task AddRange(IEnumerable<Tosti> tostis);
        Task<IEnumerable<Tosti>> GetAllTostis();
        Task<Tosti> GetTostiById(int id);
        Task<Tosti> GetTostiByName(string naam);
        Task UpsertTosti(Tosti tosti);
        Task DeleteTosti(Tosti tosti);
    }
}