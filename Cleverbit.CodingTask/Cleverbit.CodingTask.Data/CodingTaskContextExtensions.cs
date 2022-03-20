using Cleverbit.CodingTask.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data
{
    public static class CodingTaskContextExtensions
    {
        public static async Task Initialize(this CodingTaskContext context, IHashService hashService)
        {
            await context.Database.EnsureCreatedAsync();

            var currentUsers = await context.Users.ToListAsync();

            bool anyNewUser = false;

            if (!currentUsers.Any(u => u.UserName == "User1"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User1",
                    Password = await hashService.HashText("Password1")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User2"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User2",
                    Password = await hashService.HashText("Password2")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User3"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User3",
                    Password = await hashService.HashText("Password3")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User4"))
            {
                context.Users.Add(new Models.User
                {
                    UserName = "User4",
                    Password = await hashService.HashText("Password4")
                });

                anyNewUser = true;
            }

            if (anyNewUser)
            {
                await context.SaveChangesAsync(); 
            }
        }

        public static async Task PredefineMatches(this CodingTaskContext context)
        {
            await context.Database.EnsureCreatedAsync();

            var predefinedMatches = await context.Matches.ToListAsync();

            bool anyNewMatch = false;

            if (!predefinedMatches.Any(u => u.MatchName == "Match1"))
            {
                context.Matches.Add(new Models.Match
                {
                    MatchName = "Match1",
                    PlayerOneId = 1,
                    PlayerTwoId = 2,
                    ExpireTimeStamp = DateTime.Now.AddMinutes(1)
                });

                anyNewMatch = true;
            }

            if (!predefinedMatches.Any(u => u.MatchName == "Match2"))
            {
                context.Matches.Add(new Models.Match
                {
                    MatchName = "Match2",
                    PlayerOneId = 3,
                    PlayerTwoId = 4,
                    ExpireTimeStamp = DateTime.Now.AddMinutes(1)
                });

                anyNewMatch = true;
            }


            if (anyNewMatch)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
