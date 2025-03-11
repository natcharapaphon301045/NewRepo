using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Professor?> GetProfessorByIdAsync(int professorId);
        Task<Major?> GetMajorByIdAsync(int majorId);
        Task CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int studentId, StudentDTO studentDTO);
        Task<bool> DeleteStudentAsync(int studentId);
    }

}
