using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;

namespace AserAgence.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly AserAgenceDbContext _context;

        public SurveyRepository(AserAgenceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Survey.ToListAsync();
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            return await _context.Survey.FindAsync(id);
        }

        public async Task CreateAsync(Survey survey)
        {
            if (survey == null)
            {
                throw new ArgumentNullException(nameof(survey));
            }

            _context.Survey.Add(survey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Survey survey)
        {
            if (survey == null)
            {
                throw new ArgumentNullException(nameof(survey));
            }

            _context.Entry(survey).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var survey = await _context.Survey.FindAsync(id);
            if (survey != null)
            {
                _context.Survey.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Survey.AnyAsync(s => s.Id == id);
        }
    }
}
