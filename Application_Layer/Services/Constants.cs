using Week5.Application_Layer.DTOs;

namespace Week5.Application_Layer.Services
{
    public static class ResponseMessages
    {
        public const string StudentGetSuccess = "Students retrieved successfully";
        public const string StudentPostSuccess = "Student created successfully";
        public const string StudentGetNotFound = "Student not found";
        public const string StudentPostNotFound = "Student not found";
        public const string ProfessorNotFound = "Professor not found";
        public const string ProfessorGetSuccess = "Professor Get Success";
        public const string MajorNotFound = "Major not found";
        public const string MajorGetSuccess = "Major Get Success";
        public const string ClassNotFound = "Class not found";
        public const string StudentClassGetSuccess = "Student-Class relation retrieved successfully";
        public const string StudentClassNotFound = "Student-Class relation not found";
        public const string StudentUpdateSuccess = "Student Update Success";
    }
}
