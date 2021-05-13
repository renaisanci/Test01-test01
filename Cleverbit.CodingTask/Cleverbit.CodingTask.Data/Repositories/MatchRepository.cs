using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces.Repository;
using Cleverbit.CodingTask.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {


        public MatchRepository(CodingTaskContext dbContext) : base(dbContext)
        {

        }

        public  async Task<Match> GetCurrentMatch(int userId)
        {
             var dtNow = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var res = await _dbContext.Matches
                .AsNoTracking()
                .Where(x => x.ExpTimestamp > dtNow)
                .GroupJoin(_dbContext.Plays, match => match.Id, play => play.MatchId, (match, plays) => new { match,plays })
                .SelectMany(s => s.plays.DefaultIfEmpty(), (s, play) => new { s.match, play })
                .Where(s => s.play.UserId != userId)
                .Select(s => s.match)
                .FirstOrDefaultAsync();

            if (res == null)
            {
                throw new Exception( "No Match!");
            }

            return res;

        }


     
    }
}
