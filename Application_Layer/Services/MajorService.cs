using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;

namespace Week5.Application_Layer.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorRepository;

        public MajorService(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }

        // Get Major by ID
        public async Task<ApiResponse<Major>> GetMajorByIdAsync(int majorId)
        {
            var major = await _majorRepository.GetMajorByIdAsync(majorId);
            if (major == null) return new ApiResponse<Major>("Major not found.");
            return new ApiResponse<Major>(major);
        }

        // Get all Majors
        public async Task<ApiResponse<List<Major>>> GetAllMajorsAsync()
        {
            var majors = await _majorRepository.GetAllMajorsAsync();
            if (majors == null || !majors.Any())
                return new ApiResponse<List<Major>>("No majors found.");
            return new ApiResponse<List<Major>>(majors);
        }
    }
}
