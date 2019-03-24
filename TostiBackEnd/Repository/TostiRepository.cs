using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TostiBackEnd.Context;
using TostiBackEnd.Entity;
using TostiBusinessEntities;

namespace TostiBackEnd.Repository
{
    public class TostiRepository : ITostiRepository
    {

        private TostiDBContext _context;

        public TostiRepository(TostiDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tosti>> GetAllTostis()
        {
            return await Task.Run(() => _context.Tostis.Select(t => t.ToDto()).ToList());
        }

        public async Task<Tosti> GetTostiByName(string naam)
        {
            return await Task<Tosti>.Run(() => 
                 (from tosti in _context.Tostis
                 where tosti.Naam == naam
                 select tosti.ToDto()).FirstOrDefault()
            );
        }

        public async Task<Tosti> GetTostiById(int id)
        {
            return await Task<Tosti>.Run(() =>
                 (from tosti in _context.Tostis
                  where tosti.Id == id
                  select tosti.ToDto()).FirstOrDefault()
            );
        }

        public async Task UpsertTosti(Tosti tosti)
        {
            var entity = new TostiEntity(tosti);

            if(TostiExists(tosti))
            {
                var t = _context.Tostis.Update(entity);
            }
            else
            {
                await _context.AddAsync(entity);
            }

            await _context.SaveChangesAsync();
        }

        private bool TostiExists(Tosti tosti)
        {
            return _context.Tostis.Any(t => t.Id == tosti.Id);
        }

        public async Task AddRange(IEnumerable<Tosti> tostis)
        {
            var entities = from tosti in tostis
                           select new TostiEntity(tosti);

            await _context.AddAsync(entities);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTosti(Tosti tosti)
        {
            var entity = new TostiEntity(tosti);

            _context.Tostis.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
