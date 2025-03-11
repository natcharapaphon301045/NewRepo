using Week5.Domain_Layer.Entity;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IMajorRepository
    {
        Task<List<Major>> GetAllMajorsAsync();
        Task<Major> GetMajorByIdAsync(int MajorID);
    }
}
