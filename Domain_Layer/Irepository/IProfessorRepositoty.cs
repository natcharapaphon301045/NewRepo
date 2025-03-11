using Week5.Domain_Layer.Entity;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IProfessorRepository
    {
        Task<List<Professor>> GetAllProfessorAsync();
        Task<Professor?> GetProfessorByIdAsync(int professorId);
    }
}
