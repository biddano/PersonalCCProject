using MVCPicApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPicApp.Models
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}