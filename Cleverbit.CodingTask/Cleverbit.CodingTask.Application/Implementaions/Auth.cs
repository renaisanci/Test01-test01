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
    public class Auth : IAuth
    {

 
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        private readonly ILogger<Auth> _logger;

        public Auth(IUserRepository userRepository, IHashService hashService, ILogger<Auth> logger)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _logger= logger;
        }

        public async Task<UserResponse> GetUser( string userName)
        {
            var user = await _userRepository.GetByUserName(userName);  
            UserResponse userResponse = user.MapToUserResponse();

            return userResponse;
        }

        public async Task<bool> ValidateUser(UserAuthRequest userAuth)
        {
            var user = await _userRepository.GetByUserName(userAuth.UserName);

            if (user == null)
            {
                return false;
            }
            // check password
            var hashedPassword = await _hashService.HashText(userAuth.Password);
            if (hashedPassword.Equals(user.Password) == false)
            {
                return false;
            }
            return true;
        }
 
    }
}
