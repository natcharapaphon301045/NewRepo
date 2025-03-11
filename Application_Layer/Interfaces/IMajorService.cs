using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;

namespace Week5.Application_Layer.Interfaces
{
    public interface IMajorService
    {
        Task<ApiResponse<List<Major>>> GetAllMajorsAsync();
        Task<ApiResponse<Major>> GetMajorByIdAsync(int majorId);
    }

}
