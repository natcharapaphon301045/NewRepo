using Microsoft.AspNetCore.Mvc.RazorPages;
using Week5.Application_Layer.DTOs;
using Week5.Application_Layer.Interfaces;

namespace WebApplication1.Pages
{
    public class StudentListModel : PageModel
    {
        private readonly IStudentService _studentService;

        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<StudentDTO> Students { get; set; } = new();

        public async Task OnGetAsync()
        {
            var response = await _studentService.GetAllStudentsAsync();
            if (response.Success)
            {
                Students = response.Data?.ToList() ?? new List<StudentDTO>();
            }
            else
            {
                // Handle the error case as needed
                Students = new List<StudentDTO>();
            }
        }

    }
}
