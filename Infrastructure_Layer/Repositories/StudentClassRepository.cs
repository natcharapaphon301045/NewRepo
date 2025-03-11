using Microsoft.EntityFrameworkCore;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Persistence;

namespace Week5.Infrastructure_Layer.Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private readonly Week5DbContext _context;

        public StudentClassRepository(Week5DbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StudentClass>> GetAllStudentClassAsync()
        {
            return await _context.StudentClass.ToListAsync();
        }
        public async Task<StudentClass?> GetStudentClassByIdAsync(int studentId, int classId)
        {
            return await _context.StudentClass
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId && sc.ClassID == classId);
        }
    }
}
