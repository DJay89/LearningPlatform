using LearningPlatform.Models;
using System.Linq;

namespace LearningPlatform.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResearchContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Age=20, Gender=Gender.M },
                new User{Age=27, Gender=Gender.F },
            };
       
            foreach (User user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();

            var data = new AppData[]
            {
                new AppData{UserId=1, IsTextUnderstood=false, WPM=350, WordCount=750, Mode="Test" },
                new AppData{UserId=1, IsTextUnderstood=true, WPM=200, WordCount=300, Mode="Test" },
                new AppData{UserId=2, IsTextUnderstood=true, WPM=250, WordCount=125, Mode="Test" },
            };

            foreach (AppData appData in data)
            {
                context.AppData.Add(appData);
            }
            context.SaveChanges();
        }
    }
}
