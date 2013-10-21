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
            SubmissionAdapter adapter = new SubmissionAdapter();
            
        }

        //public User GetUserById(int id)
        //{
        //    AppContext context = new AppContext();
        //    var usertable = context.Users.Find(id);

        //    User user = new User();


        //}
    }
}