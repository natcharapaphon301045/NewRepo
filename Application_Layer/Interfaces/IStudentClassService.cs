using Week5.Application_Layer.DTOs;

namespace Week5.Application_Layer.Interfaces
{
    public interface IStudentClassService
    {
        Task<ApiResponse<IEnumerable<StudentClassDTO>>> GetAllStudentClassesAsync();
        Task<ApiResponse<StudentClassDTO>> GetStudentClassByIdAsync(int studentId, int classId);
    }
}
