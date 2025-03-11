using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;

namespace Week5.Application_Layer.Interfaces
{
    public interface IStudentService
    {
        Task<ApiResponse<IEnumerable<StudentDTO>>> GetAllStudentsAsync();
        Task<ApiResponse<StudentDTO>> GetStudentByIdAsync(int studentId);
        Task<ApiResponse<StudentDTO>> CreateStudentAsync(StudentDTO studentDTO);
        /*Task<ApiResponse<bool>> UpdateStudentAsync(StudentDTO studentDTO);*/
        Task<ApiResponse<Student>> UpdateStudentAsync(int studentId, StudentDTO studentDTO);
        Task<ApiResponse<bool>> DeleteStudentAsync(int studentId);
    }
}
