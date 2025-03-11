using Week5.Application_Layer.DTOs;
using Week5.Application_Layer.Interfaces;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;

namespace Week5.Application_Layer.Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassRepository _studentClassRepository;

        public StudentClassService(IStudentClassRepository studentClassRepository)
        {
            _studentClassRepository = studentClassRepository;
        }

        public async Task<ApiResponse<IEnumerable<StudentClassDTO>>> GetAllStudentClassesAsync()
        {
            var studentClasses = await _studentClassRepository.GetAllStudentClassAsync();
            var studentClassDTOs = studentClasses.Select(sc => new StudentClassDTO
            {
                StudentID = sc.StudentID,
                ClassID = sc.ClassID
            }).ToList();

            return new ApiResponse<IEnumerable<StudentClassDTO>>(true, ResponseMessages.StudentClassGetSuccess, studentClassDTOs);
        }

        public async Task<ApiResponse<StudentClassDTO>> GetStudentClassByIdAsync(int studentId, int classId)
        {
            var studentClass = await _studentClassRepository.GetStudentClassByIdAsync(studentId, classId);
            if (studentClass == null)
                if (studentClass == null) return default!;

            var studentClassDTO = new StudentClassDTO
            {
                StudentID = studentClass.StudentID,
                ClassID = studentClass.ClassID
            };

            return new ApiResponse<StudentClassDTO>(true, ResponseMessages.StudentClassGetSuccess, studentClassDTO)
            {
                Success = true,
                Message = ResponseMessages.StudentClassGetSuccess,
                Data = studentClassDTO
            };
        }
    }
}
