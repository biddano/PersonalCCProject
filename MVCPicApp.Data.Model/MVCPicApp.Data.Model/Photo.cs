using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MVCPicApp.Data.Model
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }
        //public DateTime DateCreated { get; set; }

        
        //[ForeignKey("Submission")]
        public int SubmissionId { get; set; }
        //public virtual Submission Submission { get; set; }

        //public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
