using Cleverbit.CodingTask.Core.Interfaces;
using System.Threading.Tasks;
 

namespace Cleverbit.CodingTask.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodingTaskContext _context;

        public UnitOfWork(CodingTaskContext context) =>
            _context = context;

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            
            // Possibility to dispatch domain events, etc

            return success;
        }

        public void Dispose() =>
            _context.Dispose();

        public Task Rollback()
        {
            // Rollback anything, if necessary
            return Task.CompletedTask;
        }
    }
}