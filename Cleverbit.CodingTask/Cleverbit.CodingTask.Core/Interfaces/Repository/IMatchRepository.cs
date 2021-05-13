using Cleverbit.CodingTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Core.Interfaces.Repository
{
    public interface IMatchRepository
    {

        Task<Match> GetCurrentMatch(int userId);

    }
}
