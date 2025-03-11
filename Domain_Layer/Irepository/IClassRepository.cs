using Week5.Domain_Layer.Entity;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class?> GetClassByIdAsync(int classId);
    }

}
