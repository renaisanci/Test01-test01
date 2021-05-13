using Cleverbit.CodingTask.Core.Entities;
using Cleverbit.CodingTask.Core.Interfaces;
using Cleverbit.CodingTask.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data
{
    public static class CodingTaskContextExtensions
    {


        public static async Task Initialize(this CodingTaskContext context, IHashService hashService, IUnitOfWork uow)
        {
            await context.Database.EnsureCreatedAsync();

            var currentUsers = await context.Users.ToListAsync();

            bool anyNewUser = false;

            if (!currentUsers.Any(u => u.UserName == "User1"))
            {
                context.Users.Add(new User
                {
                    UserName = "User1",
                    Password = await hashService.HashText("Password1")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User2"))
            {
                context.Users.Add(new User
                {
                    UserName = "User2",
                    Password = await hashService.HashText("Password2")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User3"))
            {
                context.Users.Add(new User
                {
                    UserName = "User3",
                    Password = await hashService.HashText("Password3")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User4"))
            {
                context.Users.Add(new User
                {
                    UserName = "User4",
                    Password = await hashService.HashText("Password4")
                });

                anyNewUser = true;
            }

            if (await context.Matches.AnyAsync())
            {
                return;
            }


            for (var i = 0; i < 200; i++)
            {
                await context.Matches.AddRangeAsync(new Match
                {
                    Id = Guid.NewGuid(),
                    ExpTimestamp = (int)(DateTime.Now.ToUniversalTime().AddSeconds(i * DateTime.Now.Millisecond) - new DateTime(1970, 1, 1)).TotalSeconds
                });
            }


            if (anyNewUser)
            {
                await uow.Commit();
            }
        }
    }
}
