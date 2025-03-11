using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;

namespace Week5.Application_Layer.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ApiResponse<IEnumerable<ClassDTO>>> GetAllClassesAsync()
        {
            var classes = await _classRepository.GetAllClassesAsync();
            var classDTOs = classes.Select(c => new ClassDTO
            {
                ClassID = c.ClassID,
                ClassName = c.ClassName
            }).ToList();

            return new ApiResponse<IEnumerable<ClassDTO>>(true, "Class retrieved successfully", classDTOs);
        }

        public async Task<ApiResponse<ClassDTO>> GetClassByIdAsync(int classId)
        {
            var classEntity = await _classRepository.GetClassByIdAsync(classId);
            if (classEntity == null)
                return new ApiResponse<ClassDTO>(false, "Class not found", default!);

            var classDTO = new ClassDTO
            {
                ClassID = classEntity.ClassID,
                ClassName = classEntity.ClassName
            };

            return new ApiResponse<ClassDTO>(true, "Class retrieved successfully", classDTO);
        }
    }

}
