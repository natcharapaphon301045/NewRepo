using Week5.Application_Layer.DTOs;

namespace Week5.Application_Layer.Interfaces
{
    public interface IClassService
    {
        Task<ApiResponse<IEnumerable<ClassDTO>>> GetAllClassesAsync();
        Task<ApiResponse<ClassDTO>> GetClassByIdAsync(int classId);
    }

}
