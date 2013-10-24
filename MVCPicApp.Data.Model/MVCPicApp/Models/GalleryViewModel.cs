using MVCPicApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPicApp.Models
{
    public class GalleryViewModel
    {
        public List<Submission> Submissions { get; set; }
        public Photo Photo { get; set; }

    }
}