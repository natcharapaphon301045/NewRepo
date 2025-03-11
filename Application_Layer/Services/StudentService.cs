using Week5.Application_Layer.DTOs;
using Week5.Application_Layer.Interfaces;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Application_Layer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMajorRepository _majorRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IBehaviorScoreRepository _behaviorScoreRepository;
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly IClassRepository _classRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IMajorRepository majorRepository,
            IProfessorRepository professorRepository,
            IBehaviorScoreRepository behaviorScoreRepository,
            IStudentClassRepository studentClassRepository,
            IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _majorRepository = majorRepository;
            _professorRepository = professorRepository;
            _behaviorScoreRepository = behaviorScoreRepository;
            _studentClassRepository = studentClassRepository;
            _classRepository = classRepository;
        }

        public async Task<ApiResponse<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            var studentDTOs = students.Select(s => new StudentDTO
            {
                StudentID = s.StudentID,
                StudentName = s.StudentName,
                StudentSurname = s.StudentSurname,
                ProfessorID = s.ProfessorID,
                MajorID = s.MajorID,
                /*StudentClass*/
                /*BehaviorScore*/
            }).ToList();

            return new ApiResponse<IEnumerable<StudentDTO>>(true, ResponseMessages.StudentGetSuccess, studentDTOs);
        }

        public async Task<ApiResponse<StudentDTO>> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
                return new ApiResponse<StudentDTO>(ResponseMessages.StudentGetNotFound);

            var studentDTO = new StudentDTO
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                StudentSurname = student.StudentSurname,
                ProfessorID = student.ProfessorID,
                MajorID = student.MajorID,
            };
            return new ApiResponse<StudentDTO>(studentDTO);
        }

        public async Task<ApiResponse<StudentDTO>> CreateStudentAsync(StudentDTO studentDTO)
        {
            var professor = await _professorRepository.GetProfessorByIdAsync(studentDTO.ProfessorID);
            var major = await _majorRepository.GetMajorByIdAsync(studentDTO.MajorID);

            if (professor == null)
            {
                var emptyStudent = new StudentDTO
                {
                    StudentName = string.Empty,  // หรือใช้ค่าอื่นที่เหมาะสม
                    StudentSurname = string.Empty // หรือใช้ค่าอื่นที่เหมาะสม
                };
                return new ApiResponse<StudentDTO>(false, ResponseMessages.ProfessorNotFound, emptyStudent);
            }

            if (major == null)
            {
                var emptyStudent = new StudentDTO
                {
                    StudentName = string.Empty,  // หรือใช้ค่าอื่นที่เหมาะสม
                    StudentSurname = string.Empty // หรือใช้ค่าอื่นที่เหมาะสม
                };
                return new ApiResponse<StudentDTO>(false, ResponseMessages.MajorNotFound, emptyStudent);
            }

            var student = new Student
            {
                StudentName = studentDTO.StudentName,
                StudentSurname = studentDTO.StudentSurname,
                Professor = professor,
                Major = major,
                StudentClass = new List<StudentClass>(),
                BehaviorScore = new List<BehaviorScore>()
            };

            if (studentDTO.StudentClass?.Any() == true)
            {
                var studentClasses = await Task.WhenAll(studentDTO.StudentClass.Select(async sc =>
                {
                    var classEntity = await _classRepository.GetClassByIdAsync(sc.ClassID);
                    return classEntity == null ? null : new StudentClass
                    {
                        ClassID = sc.ClassID,
                        Class = classEntity,
                        Student = student
                    };
                }));

                student.StudentClass = studentClasses.Where(sc => sc != null).ToList()!;
            }

            if (studentDTO.BehaviorScore?.Any() == true)
            {
                student.BehaviorScore = studentDTO.BehaviorScore.Select(bs => new BehaviorScore
                {
                    Score = bs.Score,
                    Student = student
                }).ToList();
            }
            else
            {
                student.BehaviorScore.Add(new BehaviorScore { Score = 100, Student = student });
            }

            await _studentRepository.CreateStudentAsync(student);
            return new ApiResponse<StudentDTO>(true, ResponseMessages.StudentPostSuccess, studentDTO);
        }

        public async Task<ApiResponse<Student>> UpdateStudentAsync(int studentId, StudentDTO studentDTO)
        {
            if (studentId != studentDTO.StudentID)
            {
                return new ApiResponse<Student>("Student ID mismatch");
            }

            var updateResult = await _studentRepository.UpdateStudentAsync(studentId, studentDTO);
            if (!updateResult)
            {
                return new ApiResponse<Student>("Student not found");
            }

            var updatedStudent = await _studentRepository.GetStudentByIdAsync(studentId);
            return new ApiResponse<Student>(true, ResponseMessages.StudentUpdateSuccess, updatedStudent);
        }



        public async Task<ApiResponse<bool>> DeleteStudentAsync(int studentId)
        {
            var result = await _studentRepository.DeleteStudentAsync(studentId);
            if (!result)
            {
                return new ApiResponse<bool>("Student not found or already deleted");
            }

            return new ApiResponse<bool>(true);
        }

    }
}
