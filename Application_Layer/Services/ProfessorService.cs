using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Week5.Application_Layer.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ApiResponse<List<Professor>>> GetAllProfessorAsync()
        {
            var professors = await _professorRepository.GetAllProfessorAsync();
            if (professors == null || professors.Count == 0)
                return new ApiResponse<List<Professor>>("No professors found.");

            return new ApiResponse<List<Professor>>(professors);
        }

        public async Task<ApiResponse<Professor>> GetProfessorByIdAsync(int professorId)
        {
            var professor = await _professorRepository.GetProfessorByIdAsync(professorId);
            if (professor == null)
                return new ApiResponse<Professor>("Professor not found.");

            return new ApiResponse<Professor>(professor);
        }
    }
}
