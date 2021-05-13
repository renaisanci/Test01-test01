using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces.Repository.Base;
using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Core.Interfaces.Repository
{
    public interface IPlayRepository : IRepository<Play>
    {
        Task PlayNow(int user, Guid match);

        Task<bool> NoPlayAgain(int userId, Guid matchId);

    }
}
