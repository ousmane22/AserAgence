using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VillageRepository : IGenericRepository<Village, int>
{
    private readonly AserAgenceDbContext _context;

    public VillageRepository(AserAgenceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Village>> GetAllAsync()
    {
        return await _context.Village.ToListAsync();
    }

    public async Task<Village> GetByIdAsync(int id)
    {
        return await _context.Village.FindAsync(id);
    }

    public async Task CreateAsync(Village entity)
    {
        _context.Village.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Village entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var village = await _context.Village.FindAsync(id);
        if (village != null)
        {
            _context.Village.Remove(village);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Village.AnyAsync(v => v.VillageID == id);
    }

    
}
