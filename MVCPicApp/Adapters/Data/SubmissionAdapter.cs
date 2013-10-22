using MVCPicApp.Data;
using MVCPicApp.Data.Model;
using MVCPicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPicApp.Adapters.Data
{
    public class SubmissionAdapter
    {
        public SubmissionViewModel SaveSubmission(SubmissionViewModel model, int userId)
        {
            var context = new AppContext();
            Submission submission = model.Submission;

            submission.DateCreated = DateTime.UtcNow;
            submission.DateUpdated = DateTime.UtcNow;
            submission.Score = 0;
            
            //this will be where we take the user session data and make the userId the same as the user's id; make it nullable?
            submission.UserId = userId;
            submission.Comments = new List<Comment>();

            submission = context.Submissions.Add(submission);

            context.SaveChanges();
            return model;
        }

        public SubmissionViewModel GetSubmissionViewModel(int SubmissionId)
        {
            AppContext context = new AppContext();
            SubmissionViewModel model = new SubmissionViewModel();

            //var query = context.Submissions.ToList();
            model.Submission = context.Submissions.Find(SubmissionId);
            //model.Submission = query.FirstOrDefault(m => m.SubmissionId == id);

            return model;
        }

        public SubmissionViewModel EditSubmission(SubmissionViewModel model)
        {
            var context = new AppContext();
            var tempsub = new Submission();

            tempsub = context.Submissions.Find(model.Submission.SubmissionId);
            tempsub = model.Submission;

            context.SaveChanges();
            return model;
        }

        public User GetUserById(int userId)
        {
            var user = new User();
            AppContext context = new AppContext();

            user = context.Users.Find(userId);
            return user; 
        }

        public GalleryViewModel GetAllPublicSubmissions()
        {
            AppContext context = new AppContext();
            GalleryViewModel model = new GalleryViewModel();
            //shows all submissions with newest ones first
            model.Submissions = context.Submissions.OrderByDescending(m=>m.DateCreated).ToList();

            return model;
        }
    }
}