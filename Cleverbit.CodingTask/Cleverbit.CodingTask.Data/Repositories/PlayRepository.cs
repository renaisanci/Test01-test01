using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces.Repository;
using Cleverbit.CodingTask.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class PlayRepository : Repository<Play>, IPlayRepository
    {
        public PlayRepository(CodingTaskContext dbContext) : base(dbContext)
        {

        }

        public async Task PlayNow(int userId, Guid matchId)
        {

            var play = new Play
            {
                Score = new Random().Next(100),
                DateTimestamp = (int)(DateTime.Now.ToUniversalTime().AddSeconds(10 * DateTime.Now.Millisecond) - new DateTime(1970, 1, 1)).TotalSeconds,
                Id = Guid.NewGuid(),
                MatchId = matchId,
                UserId = userId
            };

            await _dbContext.AddAsync(play);

        }

        public async Task<bool> NoPlayAgain(int userId, Guid matchId)
        {

            return await _dbContext.Plays.AnyAsync(a => a.UserId == userId && a.MatchId == matchId);

        }

    }
}
