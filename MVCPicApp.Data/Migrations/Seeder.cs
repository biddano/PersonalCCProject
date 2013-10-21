using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using MVCPicApp.Data.Model;

namespace MVCPicApp.Data.Migrations
{
    public class Seeder
    {
        public static void Seed(AppContext context, bool seedUsers = true, bool seedSubmissions = true, bool seedComments = true, bool seedPhotos = true)
        {
            if (seedUsers) SeedUsers(context);
            if (seedSubmissions) SeedSubmissions(context);
            if (seedComments) SeedComments(context);
            if (seedPhotos) SeedPhotos(context);
        }

        

        private static void SeedUsers(AppContext context)
        {
            context.Users.AddOrUpdate(u => u.UserId,
                new User() { UserName = "mista_frizzle", Email = "dmony24@yahoo.com", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new User() { UserName = "bobbyhill", Email = "bobbyhill@gmail.com", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new User() { UserName = "cooldude", Email = "coolio@aol.com", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new User() { UserName = "yomama", Email = "urmom@me.com", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
            context.SaveChanges();

        }

        private static void SeedSubmissions(AppContext context)
        {
            context.Submissions.AddOrUpdate(s => s.SubmissionId,
                new Submission() { UserId = 1, Title = "What is this?", Description = "I saw this when walking outside my house today...", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Submission() { UserId = 1, Title = "WTF?", Description = "Weirdest thing ever", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Submission() { UserId = 1, Title = "Has anyone seen this before?", Description = "What is this? Plz reply", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Submission() { UserId = 1, Title = "WOW?", Description = "Can this be identified?", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Submission() { UserId = 1, Title = "Is this normal?", Description = "My neighbors are really weird", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Submission() { UserId = 1, Title = "Where is this from?", Description = "I found this pic and am really curious about what it is.", Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
            context.SaveChanges();

        }

        private static void SeedPhotos(AppContext context)
        {
            context.Photos.AddOrUpdate(p=>p.PhotoId,
                new Photo(){PhotoUrl = "http://4.bp.blogspot.com/-AJyiqTWez68/UB8dpiyZPHI/AAAAAAAACpw/Rj9Q06xXkbQ/s1600/WeirdHouseBalconi.jpg", SubmissionId = 1},
                new Photo(){PhotoUrl = "http://3.bp.blogspot.com/-iZrrTBXVkcM/UB8dp3Z-anI/AAAAAAAACp4/OsJJRIy8YZI/s1600/WeirdHouseBoneless.jpg", SubmissionId = 2},
                new Photo(){PhotoUrl = "http://4.bp.blogspot.com/-pyIE_LCSubo/UB8dqdfYsBI/AAAAAAAACqA/1_QndzHglhs/s1600/WeirdHouseChina.jpg", SubmissionId = 3},
                new Photo(){PhotoUrl = "http://4.bp.blogspot.com/-Eq5uDAJ1Cxc/UB8drC3gtvI/AAAAAAAACqI/VdfbhADrc44/s1600/WeirdHouseHolding.jpg", SubmissionId = 4},
                new Photo(){PhotoUrl = "http://1.bp.blogspot.com/-fhHYp4aZDII/UB8dr5O5uBI/AAAAAAAACqQ/tebnU_Nhl6k/s1600/WeirdHouseIceberg.jpg", SubmissionId = 5 },
                new Photo(){PhotoUrl = "http://2.bp.blogspot.com/-WKKFOn7KLAg/UB8dupOeaJI/AAAAAAAACqw/J8yoxYT4CnU/s1600/WeirdHouseStrawberry.jpg", SubmissionId = 6 });
            context.SaveChanges();
        }



        private static void SeedComments(AppContext context)
        {
            context.Comments.AddOrUpdate(c => c.CommentId,
                new Comment() { UserId = 1, SubmissionId = 3, Content = "Wow that is really really weird...", IsCorrect = false, Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new Comment() { UserId = 1, SubmissionId = 4, Content = "Ya thats normal in certain parts of the world", IsCorrect = true, Score = 0, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
            context.SaveChanges();

        }




    }
}
