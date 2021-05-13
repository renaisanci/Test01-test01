using Cleverbit.CodingTask.Application.Requests;
using Cleverbit.CodingTask.Application.Responses;
using Cleverbit.CodingTask.Core.Entities;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.abstractions
{
    public interface IMatch
    {

        Task<Match> GetCurrentMatch(int userId);

    }
}
