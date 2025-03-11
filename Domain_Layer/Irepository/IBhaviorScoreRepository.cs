using Week5.Domain_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Week5.Domain_Layer.IRepositories
{
    public interface IBehaviorScoreRepository
    {
        Task<List<BehaviorScore>> GetAllBehaviorScoreAsync();
        Task<BehaviorScore?> GetBehaviorScoreByIdAsync(int scoreId);
    }
}
