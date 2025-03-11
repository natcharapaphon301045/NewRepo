using Week5.Application_Layer.Interfaces;
using Week5.Application_Layer.DTOs;
using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;

namespace Week5.Application_Layer.Services
{
    public class BehaviorScoreService : IBehaviorScoreService
    {
        private readonly IBehaviorScoreRepository _behaviorScoreRepository;

        public BehaviorScoreService(IBehaviorScoreRepository behaviorScoreRepository)
        {
            _behaviorScoreRepository = behaviorScoreRepository;
        }

        public async Task<ApiResponse<List<BehaviorScore>>> GetAllBehaviorScoresAsync()
        {
            var scores = await _behaviorScoreRepository.GetAllBehaviorScoreAsync();
            if (scores == null || scores.Count == 0)
                return new ApiResponse<List<BehaviorScore>>("No behavior scores found.");

            return new ApiResponse<List<BehaviorScore>>(scores);
        }

        public async Task<ApiResponse<BehaviorScore>> GetBehaviorScoreByIdAsync(int scoreId)
        {
            var score = await _behaviorScoreRepository.GetBehaviorScoreByIdAsync(scoreId);
            if (score == null)
                return new ApiResponse<BehaviorScore>("Behavior score not found.");

            return new ApiResponse<BehaviorScore>(score);
        }
    }
}
