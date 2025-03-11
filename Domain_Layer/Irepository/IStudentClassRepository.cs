using Week5.Domain_Layer.Entity;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IStudentClassRepository
    {
        Task<IEnumerable<StudentClass>> GetAllStudentClassAsync();
        Task<StudentClass?> GetStudentClassByIdAsync(int studentId, int classId);
    }
}
