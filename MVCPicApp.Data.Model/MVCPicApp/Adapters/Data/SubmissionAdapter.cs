using MVCPicApp.Data;
using MVCPicApp.Data.Model;
using MVCPicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using MVCPicApp.Framework;

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

        public SubmissionViewModel SaveSubmissionComments(SubmissionViewModel model, string userComment)
        {
            AppContext context = new AppContext();
            Comment comment = new Comment();
            //model.Submission = new Submission();


            model.Submission.Comments = context.Comments.Where(c => c.SubmissionId == model.Submission.SubmissionId).ToList();
            //List<Comment> comments = model.Submission.Comments;
            
            //model.User = new User();
            
            
            //User user = comment.User;
            comment.User = context.Users.Find(UserData.Current.UserId);


            //model.Submission.Photo = new Photo();
            model.Submission.Photo = context.Photos.First(p => p.SubmissionId == model.Submission.SubmissionId);
            
                
                
                //model.Submission.User = new User();
            model.Submission.User = context.Users.Find(model.User.UserId);
            
            //Submission submission = model.Submission;
            //model.Submission.Comments = context.Comments.ToList();
            comment.User.UserId = UserData.Current.UserId;
            comment.UserId = UserData.Current.UserId;
            comment.Content = userComment;
            comment.DateCreated = DateTime.UtcNow;
            comment.DateUpdated = DateTime.UtcNow;
            comment.Score = 0;
            comment.SubmissionId = model.Submission.SubmissionId;

            var temp = context.Comments.Add(comment);
            model.Submission.Comments.Add(comment);
            //context.Submissions.AddOrUpdate(model.Submission);
            context.Entry(model.Submission).State = System.Data.EntityState.Modified;
            //context.Entry(model.Submission.User).State = System.Data.EntityState.Modified;


            //model.Submission.Comments = context.Comments.ToList();
            context.SaveChanges();

            
            return model;
        }

        public void SavePhotoToSubmission(SubmissionViewModel model)
        {
            AppContext context = new AppContext();
            model.Submission.Photo.SubmissionId = model.Submission.SubmissionId;
            context.Entry(model.Submission.Photo).State = System.Data.EntityState.Modified;

            context.SaveChanges();
        }

        public int IncrementScore(SubmissionViewModel model)
        {
            AppContext context = new AppContext();
            model.Submission = context.Submissions.Find(model.Submission.SubmissionId);

            model.Submission.Score++;

            context.Entry(model.Submission).State = System.Data.EntityState.Modified;
            context.SaveChanges();

            return model.Submission.Score;
        }
    }
}