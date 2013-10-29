using MVCPicApp.Adapters.Data;
using MVCPicApp.Data;
using MVCPicApp.Data.Model;
using MVCPicApp.Framework;
using MVCPicApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCPicApp.Controllers
{
    public class HomeController : Controller
    {
        private SubmissionAdapter _adapter;
        //private AppContext context = new AppContext();

        public HomeController()
        {
            _adapter = new SubmissionAdapter();
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return RedirectToAction("Gallery", "Submissions");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Submit()
        {
            var model = new SubmissionViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Submit(SubmissionViewModel model, WebImage photo)
        {
            model.Submission.Photo = new Photo();
            

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var imagePath = "Content\\images\\" + newFileName;
                photo.Save("~\\" + imagePath);
                model.Submission.Photo.PhotoUrl = imagePath;
                //model.Submission.Photo.SubmissionId = model.Submission.SubmissionId;
            }

            int userId = UserData.Current.UserId;

            SubmissionViewModel submission = _adapter.SaveSubmission(model, userId);
            _adapter.SavePhotoToSubmission(submission);
            
            //want to redirect to a 'Preview' view, but will wait until main functionality is complete
            

            return RedirectToAction("PreviewSubmit", new { id = submission.Submission.SubmissionId });
            //return View(submission);
        }

        public ActionResult PreviewSubmit(int id)
        {
            var submission = _adapter.GetSubmissionViewModel(id);
            
            return View(submission);
        }

        public ActionResult Publish(int id)
        {
            SubmissionViewModel model = _adapter.GetSubmissionViewModel(id);
            
            var submission = model.Submission;
            
            return View(model);



            //Submission temp = model.Submission;
            //var id = model.Submission.SubmissionId;
            //var submission = _adapter.GetSubmissionViewModel(temp.SubmissionId);
            //submission.Comments = new List<Comment>();
            //return View(submission);
        }

        public ActionResult Edit(int id)
        {
            //model.Submission = new Submission();
            //var id = model.Submission.SubmissionId;
            
            SubmissionViewModel model = _adapter.GetSubmissionViewModel(id);

            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SubmissionViewModel model)
        {
            AppContext context = new AppContext();
            model.Submission.DateUpdated = DateTime.UtcNow;
            model.Submission.DateCreated = _adapter.GetSubmissionViewModel(model.Submission.SubmissionId).Submission.DateCreated;
            
            
            context.Entry(model.Submission).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            
            //var submission = _adapter.SaveSubmission(model);

            //var submission = _adapter.GetSubmissionViewModel(model.Submission.SubmissionId);

            //model = _adapter.EditSubmission(model);

            
            
            return RedirectToAction("PreviewSubmit", new { id = model.Submission.SubmissionId });
        }


    }
}
