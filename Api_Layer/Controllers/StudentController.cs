using Microsoft.AspNetCore.Mvc;
using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Week5.Api_Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { status = "error", message = $"Student with ID {id} not found." });

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "error", message = "Invalid data" });
            }

            var result = await _studentService.CreateStudentAsync(createDto);

            if (result?.Data == null)
            {
                return BadRequest(new { status = "error", message = "Student not created" });
            }

            return CreatedAtAction("GetStudentById", new { id = result.Data.StudentID }, result.Data);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _studentService.UpdateStudentAsync(id, studentDTO);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
