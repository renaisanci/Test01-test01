using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces.Repository;
using Cleverbit.CodingTask.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CodingTaskContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetByUserName(string userName)
        {
   

            User user = await _dbContext.Users
                          .Where(o => o.UserName == userName)
                          .FirstOrDefaultAsync();
            return user;
        }
    }
}
