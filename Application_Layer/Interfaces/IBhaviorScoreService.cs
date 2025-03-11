using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Week5.Application_Layer.Interfaces
{
    public interface IBehaviorScoreService
    {
        Task<ApiResponse<List<BehaviorScore>>> GetAllBehaviorScoresAsync();
        Task<ApiResponse<BehaviorScore>> GetBehaviorScoreByIdAsync(int scoreId);
    }
}
