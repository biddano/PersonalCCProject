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
    public class SubmissionsController : Controller
    {
        private SubmissionAdapter _adapter;
        public SubmissionsController()
        {
            _adapter = new SubmissionAdapter();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            GalleryViewModel model = new GalleryViewModel();

            model = _adapter.GetAllPublicSubmissions();
            List<Submission> submissions = model.Submissions;
            return View(model);
        }

        public ActionResult Details(int submissionId)
        {
            var model = _adapter.GetSubmissionViewModel(submissionId);
            model.User = new Data.Model.User();
            var viewerUserId = UserData.Current.UserId;
            model.User.UserId = viewerUserId;

            
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(SubmissionViewModel model, string userComment)
        {
            //model = _adapter.GetSubmissionViewModel(model.Submission.SubmissionId);
            //model = _adapter.SaveSubmissionComments(model, userComment);

            var temp = _adapter.SaveSubmissionComments(model, userComment);
            
            return View(model);
        }
    }
}
