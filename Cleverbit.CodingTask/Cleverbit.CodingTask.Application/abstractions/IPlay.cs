using Cleverbit.CodingTask.Application.Requests;
using Cleverbit.CodingTask.Application.Responses;
using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.abstractions
{
    public interface IPlay
    {

        Task PlayNow(int userId, Guid matchId);

    }
}
