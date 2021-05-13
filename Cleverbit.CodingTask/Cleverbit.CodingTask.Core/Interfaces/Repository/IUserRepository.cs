using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {

        Task<User> GetByUserName(string userName);

    }
}
