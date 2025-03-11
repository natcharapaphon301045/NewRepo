using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Week5.Infrastructure_Layer.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly Week5DbContext _context;

        public ProfessorRepository(Week5DbContext context)
        {
            _context = context;
        }
        public async Task<List<Professor>> GetAllProfessorAsync()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor?> GetProfessorByIdAsync(int professorId)
        {
            var professor = await _context.Professor.FindAsync(professorId);
            if (professor == null)
                throw new KeyNotFoundException($"Professor with ID {professorId} not found.");

            return professor;
        }
    }
}
