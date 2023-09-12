using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AserAgenceDbContext _context;

    public DepartmentRepository(AserAgenceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Department.ToListAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Department.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task CreateAsync(Department department)
    {
        _context.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var department = await GetByIdAsync(id);
        if (department != null)
        {
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Department.AnyAsync(d => d.Id == id);
    }
}
