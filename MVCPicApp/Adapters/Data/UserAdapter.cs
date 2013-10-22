using MVCPicApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPicApp.Adapters;
using System.Data.Entity;
using MVCPicApp.Framework;
using MVCPicApp.Models;
using MVCPicApp.Data.Model;
using System.Data;


namespace MVCPicApp.Adapters.Data
{
    public class UserAdapter 
    {
        public Framework.UserData GetUserDataFromUserId(int userId)
        {
            AppContext db = new AppContext();

            var user = db.Users
                .First(u => u.UserId == userId);

            UserData result = new UserData();
            result.Email = user.Email;
            //result.FirstName = user.FirstName;
            //result.LastName = user.LastName;
            result.UserId = user.UserId;
            result.Username = user.UserName;

            result.Roles = db.UserRoles
                .Where(userRole => userRole.UserId == userId)
                .Select(userRole => userRole.Role.Name)
                .ToArray();

            return result;
        }

        public void SaveUserRegisterModel(RegisterModel model)
        {
            AppContext context = new AppContext();
            User user = new User();
            
            user = context.Users
                .First(m => m.UserName == model.UserName);
  
            user.Email = model.EmailAddress;
            user.DateCreated = DateTime.UtcNow;
            user.DateUpdated = DateTime.UtcNow;

            //user = context.Users.Add(user);

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            
            
        }

        //public User GetUserById(int id)
        //{
        //    AppContext context = new AppContext();
        //    var usertable = context.Users.Find(id);

        //    User user = new User();


        //}

        //maybe this could just return a user instead of an entire userprofileviewmodel?
        //public UserProfileViewModel GetUserProfileViewModel(int UserId)
        //{
        //    AppContext context = new AppContext();
        //    UserProfileViewModel model = new UserProfileViewModel();
        //    model.User = context.Users.Find(UserId);
        //    model.User.Submissions = context.Submissions.Where(s => s.UserId == UserId).ToList();
        //    model.User.Comments = context.Comments.Where(c => c.UserId == UserId).ToList();
            
        //    return model;
        //}

        public User GetUserProfileViewModel(int UserId)
        {
            AppContext context = new AppContext();
            User model = new User();
            model = context.Users.Find(UserId);
            model.Submissions = context.Submissions.Where(s => s.UserId == UserId).ToList();
            model.Comments = context.Comments.Where(c => c.UserId == UserId).ToList();

            return model;
        }
    }
}