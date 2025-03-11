using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Week5.Infrastructure_Layer.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly Week5DbContext _context;

        public MajorRepository(Week5DbContext context)
        {
            _context = context;
        }

        public async Task<Major> GetMajorByIdAsync(int MajorID)
        {
            var major = await _context.Major.FindAsync(MajorID);
            if (major == null)
                throw new KeyNotFoundException($"Major with ID {MajorID} not found.");

            return major;
        }
        public async Task<List<Major>> GetAllMajorsAsync()
        {
            return await _context.Major.ToListAsync();
        }
    }
}
