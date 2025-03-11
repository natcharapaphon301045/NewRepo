using Week5.Domain_Layer.Entity;
using Week5.Domain_Layer.IRepositories;
using Week5.Infrastructure_Layer.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Week5.Infrastructure_Layer.Repositories
{
    public class BehaviorScoreRepository : IBehaviorScoreRepository
    {
        private readonly Week5DbContext _context;

        public BehaviorScoreRepository(Week5DbContext context)
        {
            _context = context;
        }

        public async Task<List<BehaviorScore>> GetAllBehaviorScoreAsync()
        {
            return await _context.BehaviorScore.ToListAsync();
        }

        public async Task<BehaviorScore?> GetBehaviorScoreByIdAsync(int scoreId)
        {
            return await _context.BehaviorScore.FindAsync(scoreId);
        }
    }
}
