using Cleverbit.CodingTask.Application.abstractions;
using Cleverbit.CodingTask.Application.Mapping;
using Cleverbit.CodingTask.Application.Requests;
using Cleverbit.CodingTask.Application.Responses;
using Cleverbit.CodingTask.Core.Interfaces.Repository;
using Cleverbit.CodingTask.Utilities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.Implementaions
{
    public class Match : IMatch
    {
        public Task<Core.Entities.Match> GetCurrentMatch(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
