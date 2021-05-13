using Cleverbit.CodingTask.Application.Requests;
using Cleverbit.CodingTask.Application.Responses;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Application.abstractions
{
    public interface IAuth
    {

        Task <bool> ValidateUser(UserAuthRequest userAuth);

        Task<UserResponse> GetUser(string userName);

    }
}
