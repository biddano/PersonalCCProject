using MVCPicApp.Adapters.Data;
using MVCPicApp.Data.Model;
using MVCPicApp.Framework;
using MVCPicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPicApp.Controllers
{
    public class UserController : Controller
    {
        private UserAdapter _adapter;
        public UserController()
        {
            _adapter = new UserAdapter();
        }

        
        // this is not done bc it only gives the user profile for the current user(whoever is logged in)
        public ActionResult UserProfile(int userId)
        {
            //int userSessionId = UserData.Current.UserId;
            User model = new User();
            //model = new User();
            //model.Submissions = new List<Submission>();
            //model.Comments = new List<Comment>();
            model = _adapter.GetUserProfileViewModel(userId);

            
            return View(model);
        }

        //public ActionResult UserSubmissions(int userId)
        //{

        //}

    }
}
