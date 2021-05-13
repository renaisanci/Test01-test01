using System;
using System.Threading.Tasks;
namespace Cleverbit.CodingTask.Core.Interfaces
{
   public  interface IUnitOfWork : IDisposable
    {

        Task<bool> Commit();
        Task Rollback();
    }
}
