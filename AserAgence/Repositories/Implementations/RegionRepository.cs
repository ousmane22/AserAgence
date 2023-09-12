using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AserAgence.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AserAgenceDbContext _context;

        public RegionRepository(AserAgenceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Region.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Region.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateAsync(Region region)
        {
            _context.Add(region);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            _context.Update(region);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var region = await GetByIdAsync(id);
            if (region != null)
            {
                _context.Region.Remove(region);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Region.AnyAsync(r => r.Id == id);
        }
    }
}
