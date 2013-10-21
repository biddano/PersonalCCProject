using MVCPicApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPicApp.Models
{
    public class SubmissionViewModel
    {
        public Submission Submission { get; set; }
        public List<Comment> Comments { get; set; }
        public Photo Photo { get; set; }
    }
}