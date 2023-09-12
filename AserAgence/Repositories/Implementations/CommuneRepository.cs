using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AserAgence.Repositories.Implementations
{
    public class CommuneRepository : ICommuneRepository
    {
        private readonly AserAgenceDbContext _context;

        public CommuneRepository(AserAgenceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commune>> GetAllAsync()
        {
            return await _context.Commune.ToListAsync();
        }

        public async Task<Commune> GetByIdAsync(int id)
        {
            return await _context.Commune.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateAsync(Commune commune)
        {
            _context.Add(commune);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commune commune)
        {
            _context.Update(commune);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var commune = await GetByIdAsync(id);
            if (commune != null)
            {
                _context.Commune.Remove(commune);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Commune.AnyAsync(e => e.Id == id);
        }
    }

}
