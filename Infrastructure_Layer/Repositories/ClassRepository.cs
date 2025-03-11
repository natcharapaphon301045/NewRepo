using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Week5.Infrastructure_Layer.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly Week5DbContext _context;

        public ClassRepository(Week5DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Class.ToListAsync();
        }

        public async Task<Class?> GetClassByIdAsync(int classId)
        {
            return await _context.Class.FindAsync(classId);
        }
    }

}
